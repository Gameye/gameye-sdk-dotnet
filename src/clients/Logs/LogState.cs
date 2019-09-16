using System;

namespace Gameye.Sdk
{
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
