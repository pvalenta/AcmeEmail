using System;
using System.IO;
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
        /// base constructor
        /// </summary>
        public BaseMessage() { }

        /// <summary>
        /// values constructor
        /// </summary>
        /// <param name="messageId">message id</param>
        /// <param name="messageType">message type</param>
        /// <param name="name">name</param>
        /// <param name="MessageText">message text</param>
        public BaseMessage(Guid messageId, MessageType messageType, string name, string messageText)
        {
            this.MessageId = messageId;
            this.MessageType = messageType;
            this.Name = name;
            this.MessageText = messageText;
        }

        /// <summary>
        /// proceed message method
        /// </summary>
        /// <returns>result</returns>
        public abstract MessageProceedResult ProceedMessage();

        /// <summary>
        /// proceed message async method
        /// </summary>
        /// <returns>result</returns>
        public abstract Task<MessageProceedResult> ProceedMessageAsync();

        /// <summary>
        /// get file name
        /// </summary>
        /// <param name="folder">folder</param>
        /// <returns>file name</returns>
        protected string getFileNameForSerializer(string folder)
        {
            // set it to {folder}\{MessageId} without extension
            return Path.Combine(folder, this.MessageId.ToString());
        }
    }
}
