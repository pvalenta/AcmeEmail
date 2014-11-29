using System;
using System.Threading.Tasks;

namespace AcmeEmail.MessageProcessor.Model
{
    /// <summary>
    /// base message fields implementation
    /// </summary>
    public abstract class BaseMessage : IMessage
    {
        /// <summary>
        /// get or set message id
        /// </summary>
        public Guid MessageId { get; set; }

        /// <summary>
        /// get or set message type
        /// </summary>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// get or set recipient name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// get or set message text
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// proceed message method
        /// </summary>
        /// <returns></returns>
        public abstract MessageProceedResult ProceedMessage();

        /// <summary>
        /// proceed message async method
        /// </summary>
        /// <returns></returns>
        public abstract Task<MessageProceedResult> ProceedMessageAsync();
    }
}
