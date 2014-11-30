using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcmeEmail.MessageProcessor.Model;
using System.IO;

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
        public void TestBirthDayMessageConstructor()
        {
            // create new message
            var id = Guid.NewGuid();
            var name = "recipient";
            var text = "text";
            var birthDate = DateTime.Today.AddYears(-10);
            var gift = "gift";
            var message = new BirthdayMessage(id, name, text, birthDate, gift);

            // test
            Assert.AreEqual(id, message.MessageId);
            Assert.AreEqual(MessageType.Birthday, message.MessageType);
            Assert.AreEqual(name, message.Name);
            Assert.AreEqual(text, message.MessageText);
            Assert.AreEqual(birthDate, message.BirthDate);
            Assert.AreEqual(gift, message.Gift);
        }

        /// <summary>
        /// test proceed method
        /// </summary>
        [TestMethod]
        public void TestBirthDayMessageProceedMethod()
        {
            // create new message
            var id = new Guid("12345678-1234-1234-1234-123456789012");
            var name = "recipient";
            var text = "text";
            var birthDate = DateTime.Today.AddYears(-10);
            var gift = "gift";
            var message = new BirthdayMessage(id, name, text, birthDate, gift);
            var result = MessageProceedResult.SuccessResult("D:\\AcmeEmail\\Birthday\\12345678-1234-1234-1234-123456789012.json");

            // proceed
            var proceedResult = message.ProceedMessage();

            // test
            Assert.AreEqual(text.ToUpper(), message.MessageText);
            Assert.AreEqual(result.Status, proceedResult.Status);
            Assert.AreEqual(result.SuccessFilePath, proceedResult.SuccessFilePath);
            Assert.AreEqual(true, File.Exists(proceedResult.SuccessFilePath));
        }
    }
}
