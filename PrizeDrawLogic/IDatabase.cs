
namespace PrizeDrawLogic
{
    public interface IDatabase
    {
        Task<bool> IsValidSerialNumber(string serialNumber);

        Task<int> GetUsage(string serialNumber);

        Task AddSubmission(ISubmission submission);

        Task<List<ISubmission>> GetAllSubmissions();

        Task<List<ISubmission>> GetPaginatedSubmissions(int pageSize, int page);
    }
}
