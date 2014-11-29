
namespace AcmeEmail.MessageProcessor.Model
{
    /// <summary>
    /// message proceed result
    /// </summary>
    public class MessageProceedResult
    {
        /// <summary>
        /// get or set status
        /// </summary>
        public MessageProceedStatus Status { get; set; }

        /// <summary>
        /// get or set failure message
        /// </summary>
        public string FailureMessage { get; set; }

        /// <summary>
        /// get or set success file path
        /// </summary>
        public string SuccessFilePath { get; set; }

        /// <summary>
        /// create failed result
        /// </summary>
        /// <param name="message">failed message</param>
        /// <returns>failed result</returns>
        public static MessageProceedResult FailedResult(string message)
        {
            return new MessageProceedResult
            {
                Status = MessageProceedStatus.Failed,
                FailureMessage = message
            };
        }

        /// <summary>
        /// create success result
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>success result</returns>
        public static MessageProceedResult SuccessResult(string filePath)
        {
            return new MessageProceedResult
            {
                Status = MessageProceedStatus.Success,
                SuccessFilePath = filePath
            };
        }
    }
}
