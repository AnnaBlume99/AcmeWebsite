using AcmeWebsite.Client;
using Microsoft.EntityFrameworkCore;
using PrizeDrawLogic;
using System.Runtime.CompilerServices;

namespace AcmeWebsite
{
    public class SQLDatabase(DatabaseContext context) : IDatabase
    {
        private DatabaseContext context = context;

        public async Task AddSubmission(ISubmission submission)
        {
            Submission newSubmission = new Submission
            {
                FirstName = submission.FirstName,
                LastName = submission.LastName,
                Email = submission.Email,
                SerialNumber = submission.SerialNumber
            };

            context.Submissions.Add(newSubmission);
            await context.SaveChangesAsync();
        }

        public async Task<List<ISubmission>> GetAllSubmissions()
        {
            var submissions = await context.Submissions.ToListAsync();
            return submissions.Cast<ISubmission>().ToList();
        }

        public async Task<List<ISubmission>> GetPaginatedSubmissions(int pageSize, int page)
        {
            var submissions = await context.Submissions.Skip((page-1) * pageSize).Take(pageSize).ToListAsync();
            return submissions.Cast<ISubmission>().ToList();
        }

        public async Task<int> GetUsage(string serialNumber)
        {
            return await context.Submissions.CountAsync(s => s.SerialNumber == serialNumber);
        }

        public async Task<bool> IsValidSerialNumber(string serialNumber)
        {
            return await context.SerialNumbers.AnyAsync(s => s.Number == serialNumber);
        }
    }
}
