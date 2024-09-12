using AcmeWebsite.Client;
using AcmeWebsite.Controllers;
using PrizeDrawLogic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace AcmeUnitTests
{
    [TestClass]
    public class SubmissionControllerTest
    {
        private IDatabase mockDb;
        private SubmissionController controller;
        private Submission submission;

        [TestInitialize]
        public void Setup()
        {
            mockDb = new MockDatabase(
                ["abc123", "q7f9w0", "pw7y1"],
                [new TestSubmission("q7f9w0"), new TestSubmission("pw7y1"), new TestSubmission("pw7y1")]
                );
            controller = new SubmissionController(mockDb, null);
            submission = new Submission();
            submission.FirstName = "TestName";
            submission.LastName = "Test";
            submission.Email = "test@test.dk";
            submission.SerialNumber = "abc123";
        }

        //Test ReceiveSubmission
        [TestMethod]
        public async Task ReturnsOkOnCorrectSubmission()
        {
            var result = await controller.ReceiveSubmission(submission);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task AddsCorrectSubmission()
        {
            await controller.ReceiveSubmission(submission);
            Assert.AreEqual(1, await mockDb.GetUsage(submission.SerialNumber));
        }

        [TestMethod]
        public async Task ReturnsBadRequestOnIncorrectSubmission()
        {
            submission.SerialNumber = "invalid";
            var result = await controller.ReceiveSubmission(submission);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        //Test FetchSubmissions
        [TestMethod]
        public async Task GetsCompletePage()
        {
            mockDb = new MockDatabase(
                ["abc123", "q7f9w0", "pw7y1", "9nbw3l", "n9h5gk", "hs92mng"],
                [
                    new TestSubmission("abc123"), new TestSubmission("abc123"),
                    new TestSubmission("q7f9w0"), new TestSubmission("q7f9w0"),
                    new TestSubmission("pw7y1"), new TestSubmission("pw7y1"),
                    new TestSubmission("9nbw3l"), new TestSubmission("9nbw3l"),
                    new TestSubmission("n9h5gk"), new TestSubmission("n9h5gk"),
                    new TestSubmission("hs92mng"), new TestSubmission("hs92mng")]
                );
            controller = new SubmissionController(mockDb, null);
            var result = await controller.FetchSubmissions(1);
            Assert.AreEqual(10, result.Value.Count());
        }

        [TestMethod]
        public async Task GetsIncompletePage()
        {
            mockDb = new MockDatabase(
                ["abc123", "q7f9w0", "pw7y1", "9nbw3l", "n9h5gk", "hs92mng"],
                [
                    new TestSubmission("abc123"), new TestSubmission("abc123"),
                    new TestSubmission("q7f9w0"), new TestSubmission("q7f9w0"),
                    new TestSubmission("pw7y1"), new TestSubmission("pw7y1"),
                    new TestSubmission("9nbw3l"), new TestSubmission("9nbw3l"),
                    new TestSubmission("n9h5gk"), new TestSubmission("n9h5gk"),
                    new TestSubmission("hs92mng"), new TestSubmission("hs92mng")]
                );
            controller = new SubmissionController(mockDb, null);
            var result = await controller.FetchSubmissions(2);
            Assert.AreEqual(2, result.Value.Count());
        }

        [TestMethod]
        public async Task ReturnsEmptyListOnEmptyPage()
        {
            mockDb = new MockDatabase(
                ["abc123", "q7f9w0", "pw7y1", "9nbw3l", "n9h5gk", "hs92mng"],
                [
                    new TestSubmission("abc123"), new TestSubmission("abc123"),
                    new TestSubmission("q7f9w0"), new TestSubmission("q7f9w0"),
                    new TestSubmission("pw7y1"), new TestSubmission("pw7y1"),
                    new TestSubmission("9nbw3l"), new TestSubmission("9nbw3l"),
                    new TestSubmission("n9h5gk"), new TestSubmission("n9h5gk"),
                    new TestSubmission("hs92mng"), new TestSubmission("hs92mng")]
                );
            controller = new SubmissionController(mockDb, null);
            var result = await controller.FetchSubmissions(5);
            Assert.AreEqual(0, result.Value.Count());
        }

        [TestMethod]
        public async Task ReturnsEmptyListWhenNoSubmissions()
        {
            mockDb = new MockDatabase([], []);
            controller = new SubmissionController(mockDb, null);
            var result = await controller.FetchSubmissions(1);
            Assert.AreEqual(0, result.Value.Count());
        }

        //Test DrawWinner
        [TestMethod]
        public async Task GetsRandomSubmission()
        {
            var result = await controller.DrawWinner();
            var allSubmissions = await mockDb.GetAllSubmissions();
            var allSubmissionsClient = allSubmissions.Select(s => ConvertToClientSubmission(s));
            Assert.IsTrue(allSubmissionsClient.Contains(result.Value));
        }

        [TestMethod]
        public async Task ReturnsBadRequestWhenThereAreNoSubmissions()
        {
            mockDb = new MockDatabase([], []);
            controller = new SubmissionController(mockDb, null);
            var result = await controller.DrawWinner();
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }

        private Submission ConvertToClientSubmission(ISubmission submission)
        {
            Submission newSubmission = new Submission();
            newSubmission.FirstName = submission.FirstName;
            newSubmission.LastName = submission.LastName;
            newSubmission.Email = submission.Email;
            newSubmission.SerialNumber = submission.SerialNumber;
            return newSubmission;
        }
    }
}
