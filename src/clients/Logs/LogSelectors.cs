using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Gameye.Sdk
{
    public static class LogSelectors
    {
        public static IReadOnlyList<LogLine> SelectAllLogs(LogState logState)
        {
            var lines = logState.Logs.GetAt<JObject>("line");
            if (lines == null)
            {
                return null;
            }

            var logs = new List<LogLine>();
            foreach (var log in lines)
            {
                logs.Add(log.Value.ToObject<LogLine>());
            }
            return logs;
        }

        public static IReadOnlyList<LogLine> SelectLogsSince(LogState logState, int lineNumber)
        {
            var lines = logState.Logs.GetAt<JObject>("line");
            var logs = new List<LogLine>();

            if (lines == null)
            {
                return logs;
            }

            for (var i = lineNumber; i < lines.Count; i++)
            {
                var log = logState.Logs.GetAt<LogLine>($"line.{i}"); ;
                if (log != null)
                {
                    logs.Add(log);
                }
            }

            return logs;
        }
    }
}
