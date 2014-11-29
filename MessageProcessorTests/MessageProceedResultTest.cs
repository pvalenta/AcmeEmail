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
            Assert.AreEqual(result.Status, MessageProceedStatus.Failed);
            Assert.AreEqual(result.FailureMessage, "message");
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
            Assert.AreEqual(result.Status, MessageProceedStatus.Success);
            Assert.AreEqual(result.SuccessFilePath, "c:\file.txt");
        }
    }
}
