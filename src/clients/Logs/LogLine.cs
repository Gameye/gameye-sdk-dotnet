namespace Gameye.Sdk
{
    /// <summary>
    /// Log Line Object
    /// </summary>
    public class LogLine
    {
        /// <summary>
        /// The line number
        /// </summary>
        public string LineKey { get; set; }
        
        /// <summary>
        /// The log message
        /// </summary>
        public string Payload { get; set; }

        /// <summary>
        /// Print this LogLine object in the format $"{LineKey}: {Payload}"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{LineKey}: {Payload}";
        }
    }
}
