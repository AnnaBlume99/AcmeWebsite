using PrizeDrawLogic;

namespace AcmeUnitTests
{
    [TestClass]
    public class ValidatorTest
    {
        private IDatabase mockDb;
        private Validator validator;

        [TestInitialize]
        public void Setup()
        {
            mockDb = new MockDatabase(
                ["abc123", "q7f9w0", "pw7y1"],
                [new TestSubmission("q7f9w0"), new TestSubmission("pw7y1"), new TestSubmission("pw7y1")]
                );
            validator = new Validator(mockDb);
        }
        
        [TestMethod]
        public async Task AcceptsValidSerialNumber()
        {
            (bool valid, string comment) = await validator.IsValidSubmission("abc123");
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public async Task DoesNotAcceptInvalidSerialNumber()
        {
            (bool valid, string _) = await validator.IsValidSubmission("invalid");
            Assert.IsFalse(valid);
        }

        [TestMethod]
        public async Task AcceptsSerialNumberAddedOnce()
        {
            (bool valid, string _) = await validator.IsValidSubmission("q7f9w0");
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public async Task DoesNotAcceptSerialNumberAddedTwice()
        {
            (bool valid, string _) = await validator.IsValidSubmission("pw7y1");
            Assert.IsFalse(valid);
        }
    }
}