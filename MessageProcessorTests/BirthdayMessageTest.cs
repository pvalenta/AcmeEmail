using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcmeEmail.MessageProcessor.Model;

namespace AcmeEmail.MessageProcessorTests
{
    /// <summary>
    /// test cases for BirthdayMessage
    /// </summary>
    [TestClass]
    public class BirthdayMessageTest
    {
        /// <summary>
        /// test constructor
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            // create new message
            var message = new BirthdayMessage();

            // test
            Assert.AreEqual(message.MessageType, MessageType.Birthday);
        }
    }
}
