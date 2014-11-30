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
        public BirthdayMessage() { }

        /// <summary>
        /// values constructor
        /// </summary>
        /// <param name="messageId">message id</param>
        /// <param name="name">name</param>
        /// <param name="messageText">message text</param>
        /// <param name="birthDate">birth date</param>
        /// <param name="gift">gift</param>
        public BirthdayMessage(Guid messageId, string name, string messageText, DateTime birthDate, string gift) : 
            base(messageId, MessageType.Birthday, name, messageText)
        {
            this.BirthDate = birthDate;
            this.Gift = gift;
        }

        /// <summary>
        /// proceed message method
        /// </summary>
        /// <returns></returns>
        public override MessageProceedResult ProceedMessage()
        {
            // change to uppercase
            this.MessageText = this.MessageText.ToUpper();
            
            // serialize
            return Serializer.SerializeMessage(this, MessageSerializeFormat.Json, 
                this.getFileNameForSerializer(ConfigReader.BirthdayFolder));
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
