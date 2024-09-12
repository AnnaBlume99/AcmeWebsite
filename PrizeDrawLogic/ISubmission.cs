namespace PrizeDrawLogic
{
    public interface ISubmission
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string SerialNumber { get; set; }
    }
}
