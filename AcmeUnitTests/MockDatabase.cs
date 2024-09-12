using PrizeDrawLogic;
namespace AcmeUnitTests
{
    internal class MockDatabase(List<string> serialNumbers, List<ISubmission> submissions) : IDatabase
    {
        private List<string> serialNumbers = serialNumbers;
        private List<ISubmission> submissions = submissions;

        public Task AddSubmission(ISubmission submission)
        {
            submissions.Add(submission);
            return Task.CompletedTask;
        }

        public Task<List<ISubmission>> GetAllSubmissions()
        {
            return Task.FromResult(submissions);
        }

        public Task<List<ISubmission>> GetPaginatedSubmissions(int pageSize, int page)
        {
            return Task.FromResult(submissions.Skip((page - 1) * pageSize).Take(pageSize).ToList());
        }

        public Task<int> GetUsage(string serialNumber)
        {
            return Task.FromResult(submissions.Count(s => s.SerialNumber == serialNumber));
        }

        public Task<bool> IsValidSerialNumber(string serialNumber)
        {
            return Task.FromResult(serialNumbers.Contains(serialNumber));
        }
    }
}
