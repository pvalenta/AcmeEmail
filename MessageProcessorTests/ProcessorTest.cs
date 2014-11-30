using AcmeEmail.MessageProcessor;
using AcmeEmail.MessageProcessor.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;

namespace AcmeEmail.MessageProcessorTests
{
    /// <summary>
    /// processor class test
    /// </summary>
    [TestClass]
    public class ProcessorTest
    {
        /// <summary>
        /// message queue test
        /// </summary>
        [TestMethod]
        public void TestProcessorQueue()
        {
            // setup classes
            var processor = new Processor();
            var birthMessage = getSampleBirthMessage();
            var childMessage = getSampleChildBirthMessage();
            var messageList = getSampleMessageArray();

            // test empty queue
            Assert.AreEqual(0, processor.QueueLength);

            // add birth message
            processor.AddMessage(birthMessage);

            // test queue
            Assert.AreEqual(1, processor.QueueLength);

            // add child message
            processor.AddMessage(childMessage);

            // test queue
            Assert.AreEqual(2, processor.QueueLength);

            // add message list
            processor.AddMessages(messageList);

            // test queue
            Assert.AreEqual(4, processor.QueueLength);
        }

        /// <summary>
        /// proceed method test
        /// </summary>
        [TestMethod]
        public void TestProcessorProceedQueueMethod()
        {
            // setup classes
            var processor = new Processor();
            var messageList = getSampleMessageArray();
            var logPath = ConfigurationManager.AppSettings["logFolder"];
            processor.AddMessages(messageList);

            // proceed
            processor.ProceedQueue();

            // test log
            Assert.AreEqual(true, File.Exists(Path.Combine(logPath, string.Format("{0}.log", DateTime.Today.ToString("yyyy-MM-dd")))));
        }

        /// <summary>
        /// get sample birth message
        /// </summary>
        /// <returns>birthday message</returns>
        private BirthdayMessage getSampleBirthMessage()
        {
            var id = new Guid("12345678-1234-1234-1234-123456789012");
            var name = "recipient";
            var text = "text";
            var birthDate = DateTime.Today.AddYears(-10);
            var gift = "gift";
            return new BirthdayMessage(id, name, text, birthDate, gift);
        }

        /// <summary>
        /// get sample child birth message
        /// </summary>
        /// <returns>child birth message</returns>
        private ChildBirthMessage getSampleChildBirthMessage()
        {
            var id = new Guid("12345678-1234-1234-1234-123456789012");
            var name = "recipient";
            var text = "text";
            var gender = Gender.Male;
            var birthDay = DateTime.Today;
            return new ChildBirthMessage(id, name, text, gender, birthDay);
        }

        /// <summary>
        /// get sample message array
        /// </summary>
        /// <returns></returns>
        private IMessage[] getSampleMessageArray()
        {
            return new IMessage[] 
            {
                getSampleBirthMessage(),
                getSampleChildBirthMessage()
            };
        }
    }
}
