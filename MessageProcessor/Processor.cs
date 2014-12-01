using AcmeEmail.MessageProcessor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeEmail.MessageProcessor
{
    /// <summary>
    /// message processor
    /// </summary>
    public class Processor
    {
        /// <summary>
        /// message queue
        /// </summary>
        private List<IMessage> queue = new List<IMessage>();

        /// <summary>
        /// add message in queue
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(IMessage message)
        {
            // add to queue
            queue.Add(message);
        }

        /// <summary>
        /// add messages in queue
        /// </summary>
        /// <param name="messages"></param>
        public void AddMessages(IEnumerable<IMessage> messages)
        {
            // add to queue
            queue.AddRange(messages);
        }

        /// <summary>
        /// get queue length
        /// </summary>
        public int QueueLength
        {
            get
            {
                return queue.Count;
            }
        }

        /// <summary>
        /// proceed queue
        /// </summary>
        public void ProceedQueue()
        {
            // loop and execute
            while (queue.Count > 0)
            {
                // get first message
                var message = queue[0];

                // get result
                var result = message.ProceedMessage();

                // log it
                this.logResult(result, message);

                // remove it from queue
                queue.RemoveAt(0);
            }
        }

        /// <summary>
        /// get file name for log
        /// </summary>
        /// <returns>file name</returns>
        private string getFileNameForLog()
        {
            // set it to {folder}\{yyyy-MM-dd}.log 
            return Path.Combine(ConfigReader.LogFolder, string.Format("{0}.log", DateTime.Today.ToString("yyyy-MM-dd")));
        }

        /// <summary>
        /// get log text
        /// </summary>
        /// <param name="result">result state</param>
        /// <param name="message">message</param>
        /// <returns></returns>
        private string getLogText(MessageProceedResult result, IMessage message)
        {
            if (result.Status == MessageProceedStatus.Success)
            {
                // set it to {messageId}\t{messageType}\t{outputFile}\t{status}
                return string.Format("{0}\t{1}\t{2}\t{3}" + Environment.NewLine,
                    message.MessageId.ToString(), message.MessageType.ToString(), result.SuccessFilePath, result.Status.ToString());
            }
            else
            {
                // set it to {messageId}\t{messageType}\t{failedMessage}\t{status}
                return string.Format("{0}\t{1}\t{2}\t{3}" + Environment.NewLine,
                    message.MessageId.ToString(), message.MessageType.ToString(), result.FailureMessage, result.Status.ToString());
            }
        }

        /// <summary>
        /// log result
        /// </summary>
        /// <param name="result">result state</param>
        /// <param name="message">message</param>
        private void logResult(MessageProceedResult result, IMessage message)
        {
            File.AppendAllText(getFileNameForLog(), getLogText(result, message));
        }
    }
}
