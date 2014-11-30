using AcmeEmail.MessageProcessor.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;

namespace AcmeEmail.MessageProcessor
{
    /// <summary>
    /// serializer class
    /// </summary>
    internal class Serializer
    {
        /// <summary>
        /// serialize message
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="format">serialize format</param>
        /// <param name="outputFile">output filename</param>
        /// <returns>result</returns>
        public static MessageProceedResult SerializeMessage(IMessage message, MessageSerializeFormat format, string outputFile)
        {
            // continue by format
            switch (format)
            {
                case MessageSerializeFormat.Json:
                    return serializeToJson(message, outputFile);
                case MessageSerializeFormat.Xml:
                    return serializeToXml(message, outputFile);
                default:
                    // do nothing
                    return MessageProceedResult.SuccessResult(null);
            }
        }

        /// <summary>
        /// serialize to json
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="outputFile">output filename</param>
        /// <returns>result</returns>
        private static MessageProceedResult serializeToJson(IMessage message, string outputFile)
        {
            try
            {
                // convert to json
                string json = JsonConvert.SerializeObject(message);

                // write to a file
                File.WriteAllText(outputFile, json);

                // success
                return MessageProceedResult.SuccessResult(outputFile);
            }
            catch (Exception e)
            {
                // failed
                return MessageProceedResult.FailedResult(e.Message);
            }
        }

        /// <summary>
        /// serialize to xml
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="outputFile">output filename</param>
        /// <returns></returns>
        private static MessageProceedResult serializeToXml(IMessage message, string outputFile)
        {
            try
            {
                // setup serializer
                var xmlSerializer = new XmlSerializer(message.GetType());
                
                // write out
                using(var file = new StreamWriter(outputFile))
                {
                    xmlSerializer.Serialize(file, message);

                    // flush and close
                    file.Flush();
                    file.Close();
                }

                // success
                return MessageProceedResult.SuccessResult(outputFile);
            }
            catch (Exception e)
            {
                // failed
                return MessageProceedResult.FailedResult(e.Message);
            }
        }
    }
}
