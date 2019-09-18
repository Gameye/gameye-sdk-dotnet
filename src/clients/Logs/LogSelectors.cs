using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    public static class LogSelectors
    {
        /// <summary>
        /// Select all the logs in the store
        /// </summary>
        /// <param name="logState"></param>
        /// <returns>An ImmutableArray of LogLines</returns>
        public static ImmutableArray<LogLine> SelectAllLogs(this LogState logState)
        {
            var lines = logState.Logs.GetAt<JObject>("line") ?? new JObject();
            var logs = new List<LogLine>();

            foreach (var log in lines)
            {
                logs.Add(log.Value.ToObject<LogLine>());
            }

            return logs.ToImmutableArray();
        }

        /// <summary>
        /// Select all the logs since a given line number
        /// </summary>
        /// <param name="logState"></param>
        /// <returns>An ImmutableArray of LogLines</returns>
        public static ImmutableArray<LogLine> SelectLogsSince(this LogState logState, int lineNumber)
        {
            var lines = logState.Logs.GetAt<JObject>("line") ?? new JObject();
            var logs = new List<LogLine>();

            for (var i = lineNumber; i < lines.Count; i++)
            {
                var log = logState.Logs.GetAt<LogLine>($"line.{i}"); ;
                if (log != null)
                {
                    logs.Add(log);
                }
            }

            return logs.ToImmutableArray();
        }
    }
}
