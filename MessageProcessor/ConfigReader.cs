using System.Configuration;

namespace AcmeEmail.MessageProcessor
{
    /// <summary>
    /// application configuration reader
    /// </summary>
    internal class ConfigReader
    {
        /// <summary>
        /// get birthday folder
        /// </summary>
        public static readonly string BirthdayFolder = ConfigurationManager.AppSettings["birthdayFolder"];

        /// <summary>
        /// get child birth folder
        /// </summary>
        public static readonly string ChildBirthFolder = ConfigurationManager.AppSettings["childBirthFolder"];

        /// <summary>
        /// get log folder
        /// </summary>
        public static readonly string LogFolder = ConfigurationManager.AppSettings["logFolder"];
    }
}
