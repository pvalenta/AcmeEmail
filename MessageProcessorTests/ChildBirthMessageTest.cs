using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcmeEmail.MessageProcessor.Model;
using System.IO;
using System.Configuration;

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
        public void TestChildBirthConstructor()
        {
            // create new message
            var id = Guid.NewGuid();
            var name = "recipient";
            var text = "text";
            var gender = Gender.Male;
            var birthDay = DateTime.Today;
            var message = new ChildBirthMessage(id, name, text, gender, birthDay);

            // test
            Assert.AreEqual(id, message.MessageId);
            Assert.AreEqual(MessageType.ChildBirth, message.MessageType);
            Assert.AreEqual(name, message.Name);
            Assert.AreEqual(text, message.MessageText);
            Assert.AreEqual(gender, message.Gender);
            Assert.AreEqual(birthDay, message.BabyBirthDay);
        }

        /// <summary>
        /// test proceed method
        /// </summary>
        [TestMethod]
        public void TestChildBirthProceedMethod()
        {
            // create new message
            var id = new Guid("12345678-1234-1234-1234-123456789012");
            var name = "recipient";
            var text = "text";
            var gender = Gender.Male;
            var birthDay = DateTime.Today;
            var message = new ChildBirthMessage(id, name, text, gender, birthDay);
            var path = ConfigurationManager.AppSettings["childBirthFolder"];
            var result = MessageProceedResult.SuccessResult(Path.Combine(path, "12345678-1234-1234-1234-123456789012.xml"));

            // proceed
            var proceedResult = message.ProceedMessage();

            // test
            Assert.AreEqual("cgBlAGMAaQBwAGkAZQBuAHQA", message.Name);
            Assert.AreEqual("01 Dec 2014", message.FormattedBabyBirthDay);
            Assert.AreEqual(result.Status, proceedResult.Status);
            Assert.AreEqual(result.SuccessFilePath, proceedResult.SuccessFilePath);
            Assert.AreEqual(true, File.Exists(proceedResult.SuccessFilePath));
        }
    }
}
