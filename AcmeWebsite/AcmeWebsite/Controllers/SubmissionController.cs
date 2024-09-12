using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PrizeDrawLogic;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;

namespace AcmeWebsite.Controllers
{
    [Route("/submission")]
    public class SubmissionController : ControllerBase
    {
        private IDatabase database;
        private Validator validator;
        private AuthenticationConfig? authenticationConfig;
        private const int PAGESIZE = 10;

        public SubmissionController(IDatabase database, IOptions<AuthenticationConfig> options)
        {
            this.database = database;
            validator = new Validator(database);
            authenticationConfig = options?.Value;
        }

        [HttpPost("")]
        public async Task<ActionResult> ReceiveSubmission([FromBody] Client.Submission submission)
        {
            (bool valid, string response) = await validator.IsValidSubmission(submission.SerialNumber);
            if (!valid)
            {
                return BadRequest(response);
            }

            try
            {
                await database.AddSubmission(ConvertToDatabaseSubmission(submission));

            } catch (DbException e)
            {
                return Problem(e.Message);
            }

            return Ok();
        }

        [HttpGet("{page}")]
        public async Task<ActionResult<List<Client.Submission>>> FetchSubmissions(int page)
        {
            if (!IsUserAuthenticated())
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }   
            var databaseSubmissions = await database.GetPaginatedSubmissions(PAGESIZE, page);
            List<Client.Submission> submissions = databaseSubmissions.Select((submission, _) =>
            {
                return ConvertToClientSubmission(submission);
            }).ToList();
            return submissions;
        }

        [HttpGet("draw/")]
        public async Task<ActionResult<Client.Submission>> DrawWinner()
        {
            if (!IsUserAuthenticated())
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            var submissions = await database.GetAllSubmissions();
            Random random = new Random();
            var winningSubmission = submissions.OrderBy(en => random.Next()).FirstOrDefault();
            if (winningSubmission == null)
            {
                return BadRequest("There are no submissions yet.");
            }
            return ConvertToClientSubmission(winningSubmission);
        }

        private Submission ConvertToDatabaseSubmission(Client.Submission submission)
        {
            Submission newSubmission = new Submission();
            newSubmission.FirstName = submission.FirstName;
            newSubmission.LastName = submission.LastName;
            newSubmission.Email = submission.Email;
            newSubmission.SerialNumber = submission.SerialNumber;
            return newSubmission;
        }

        private Client.Submission ConvertToClientSubmission(ISubmission submission)
        {
            Client.Submission newSubmission = new Client.Submission();
            newSubmission.FirstName = submission.FirstName;
            newSubmission.LastName = submission.LastName;
            newSubmission.Email = submission.Email;
            newSubmission.SerialNumber = submission.SerialNumber;
            return newSubmission;
        }

        private bool IsUserAuthenticated()
        {
            if(authenticationConfig == null)
            {
                return true;
            }

            if (!HttpContext.Request.Headers.TryGetValue("password", out var authHeader))
            {
                return false;
            }
            using var sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(authHeader + authenticationConfig.PasswordSalt));
            if (GetHashString(hash) != authenticationConfig.PasswordHash)
            {
                return false;
            }

            return true;
        }

        public static string GetHashString(byte[] hash)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }
    }
}
