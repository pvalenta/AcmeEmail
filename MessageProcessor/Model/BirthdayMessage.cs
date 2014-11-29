using System;
using System.Threading.Tasks;

namespace AcmeEmail.MessageProcessor.Model
{
    /// <summary>
    /// birthday message
    /// </summary>
    public class BirthdayMessage : BaseMessage
    {
        /// <summary>
        /// get or set birth date
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// get or set gift
        /// </summary>
        public string Gift { get; set; }

        /// <summary>
        /// base constructor
        /// </summary>
        public BirthdayMessage()
        {
            // set message type
            this.MessageType = Model.MessageType.Birthday;
        }

        /// <summary>
        /// proceed message method
        /// </summary>
        /// <returns></returns>
        public override MessageProceedResult ProceedMessage()
        {
            // change to uppercase
            this.MessageText = this.MessageText.ToUpper();

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
