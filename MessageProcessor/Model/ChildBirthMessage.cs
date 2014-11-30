using System;
using System.Text;
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
        /// formatted baby birthday
        /// </summary>
        public string FormattedBabyBirthDay { get; set; }

        /// <summary>
        /// base constructor
        /// </summary>
        public ChildBirthMessage() { }

        /// <summary>
        /// base constructor
        /// </summary>
        public ChildBirthMessage(Guid messageId, string name, string messageText, Gender gender, DateTime babyBirthDay) :
            base(messageId, MessageType.ChildBirth, name, messageText)
        {
            this.Gender = gender;
            this.BabyBirthDay = babyBirthDay;
        }

        /// <summary>
        /// proceed message
        /// </summary>
        /// <returns></returns>
        public override MessageProceedResult ProceedMessage()
        {
            // encode name without using encoding
            // we can use UTF8 encofing as well:
            // this.Name = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(this.Name))
            this.Name = Convert.ToBase64String(getBytes(this.Name));

            // format baby birthday
            this.FormattedBabyBirthDay = this.BabyBirthDay.ToString("dd MMM yyyy");

            // serialize
            return Serializer.SerializeMessage(this, MessageSerializeFormat.Xml,
                this.getFileNameForSerializer(ConfigReader.ChildBirthFolder));
        }

        /// <summary>
        /// get string bytes
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>byte array</returns>
        private byte[] getBytes(string value)
        {
            // setup array
            byte[] bytes = new byte[value.Length * sizeof(char)];

            // copy string into it
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
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
