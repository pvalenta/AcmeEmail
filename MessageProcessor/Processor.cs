using AcmeEmail.MessageProcessor.Model;
using System;
using System.Collections.Generic;
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
        /// proceed queue
        /// </summary>
        public void ProceedQueue()
        {
            // loop and execute
            foreach(var message in queue)
            {
                // get result
                var result = message.ProceedMessage();

                // log it
                this.logResult(result, message);
            }
        }

        /// <summary>
        /// log result
        /// </summary>
        /// <param name="result">result state</param>
        /// <param name="message">message</param>
        private void logResult(MessageProceedResult result, IMessage message)
        {

        }

        /// <summary>
        /// proceed queue async
        /// </summary>
        async public void ProceedQueueAsync()
        {
            // loop and execute
            foreach (var message in queue)
            {
                // get result
                var result = await message.ProceedMessageAsync();

                // log it
                await logResultAsync(result, message);
            }
        }

        /// <summary>
        /// log result
        /// </summary>
        /// <param name="result">result state</param>
        /// <param name="message">message</param>
        async private Task<bool> logResultAsync(MessageProceedResult result, IMessage message)
        {
            return true;
        }
    }
}
