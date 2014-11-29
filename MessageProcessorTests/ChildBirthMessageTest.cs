using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcmeEmail.MessageProcessor.Model;

namespace AcmeEmail.MessageProcessorTests
{
    /// <summary>
    /// test cases for ChildBirthMessage
    /// </summary>
    [TestClass]
    public class ChildBirthMessageTest
    {
        /// <summary>
        /// test constructor
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            // create new message
            var message = new ChildBirthMessage();

            // test
            Assert.AreEqual(message.MessageType, MessageType.ChildBirth);
        }
    }
}
