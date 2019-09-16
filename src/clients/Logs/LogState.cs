using System;

namespace Gameye.Sdk
{
    public class LogLine
    {
        public string LineKey { get; set; }
        public string Payload { get; set; }

        public override string ToString()
        {
            return $"{LineKey}: ${Payload}";
        }
    }

    public class LogState
    {
        public PatchDocument Logs { get; private set; }

        private LogState() { }

        public static LogState WithLogs(PatchDocument logs)
        {
            return new LogState
            {
                Logs = logs.Clone()
            };
        }
    }
}
