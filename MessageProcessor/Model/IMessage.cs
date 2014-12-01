using System;
using System.Threading.Tasks;

namespace AcmeEmail.MessageProcessor.Model
{
    /// <summary>
    /// Message Interface
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// get or set message id
        /// </summary>
        Guid MessageId { get; set; }

        /// <summary>
        /// get or set message type
        /// </summary>
        MessageType MessageType { get; set; }

        /// <summary>
        /// get or set recipient name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// get or set message text
        /// </summary>
        string MessageText { get; set; }

        /// <summary>
        /// proceed message method
        /// </summary>
        /// <returns></returns>
        MessageProceedResult ProceedMessage();
    }
}
