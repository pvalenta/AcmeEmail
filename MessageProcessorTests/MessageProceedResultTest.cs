using AcmeEmail.MessageProcessor.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeEmail.MessageProcessorTests
{
    /// <summary>
    /// Test cases for MessageProceedResult
    /// </summary>
    [TestClass]
    public class MessageProceedResultTest
    {
        /// <summary>
        /// test failure result
        /// </summary>
        [TestMethod]
        public void TestFailureResult()
        {
            // create result
            var result = MessageProceedResult.FailedResult("message");

            // test
            Assert.AreEqual(MessageProceedStatus.Failed, result.Status);
            Assert.AreEqual("message", result.FailureMessage);
        }

        /// <summary>
        /// test success result
        /// </summary>
        [TestMethod]
        public void TestSuccessResult()
        {
            // create result
            var result = MessageProceedResult.SuccessResult("c:\file.txt");

            // test
            Assert.AreEqual(MessageProceedStatus.Success, result.Status);
            Assert.AreEqual("c:\file.txt", result.SuccessFilePath);
        }
    }
}
