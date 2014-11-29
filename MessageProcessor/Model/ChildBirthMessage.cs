using System;
using System.Threading.Tasks;

namespace AcmeEmail.MessageProcessor.Model
{
    /// <summary>
    /// child birth message
    /// </summary>
    public class ChildBirthMessage : BaseMessage
    {
        /// <summary>
        /// child gender
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// baby birthday
        /// </summary>
        public DateTime BabyBirthDay { get; set; }

        /// <summary>
        /// base constructor
        /// </summary>
        public ChildBirthMessage()
        {
            // set message type
            this.MessageType = Model.MessageType.ChildBirth;
        }

        /// <summary>
        /// proceed message
        /// </summary>
        /// <returns></returns>
        public override MessageProceedResult ProceedMessage()
        {
            return MessageProceedResult.FailedResult("not implemented");
        }

        /// <summary>
        /// proceed message async method
        /// </summary>
        /// <returns></returns>
        async public override Task<MessageProceedResult> ProceedMessageAsync()
        {
            return MessageProceedResult.FailedResult("not implemented");
        }
    }
}
