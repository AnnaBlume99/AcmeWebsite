using PrizeDrawLogic;

namespace AcmeUnitTests
{
    class TestSubmission : ISubmission
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SerialNumber { get; set; }

        public TestSubmission(string serialNumber)
        {
            FirstName = "Test";
            LastName = "Testman";
            Email = "test@test.dk";
            SerialNumber = serialNumber;
        }
    }
}
