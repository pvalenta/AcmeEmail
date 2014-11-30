using Newtonsoft.Json;
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
        /// <param name="format">format</param>
        /// <returns>file name</returns>
        protected string getFileNameForSerializer(string folder, MessageSerializeFormat format)
        {
            // set it to {folder}\{MessageId}.{format in lowercase}
            return Path.Combine(folder, string.Format("{0}.{1}", this.MessageId.ToString(), format.ToString().ToLower()));
        }
    }
}
