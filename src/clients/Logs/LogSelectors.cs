using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    public static class LogSelectors
    {
        /// <summary>
        /// Select all the <see cref="LogLine"/>s in the store. Use this as an extension method on <see cref="LogState"/>
        /// </summary>
        /// <param name="logState"></param>
        /// <returns>An <see cref="ImmutableArray"/> of <see cref="LogLine"/></returns>
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
        /// Select all the <see cref="LogLine"/>s since a given line number. Use this as an extension method on <see cref="LogState"/>
        /// </summary>
        /// <param name="logState"></param>
        /// <param name="lineNumber">The line number after which to select <see cref="LogLine"/>s</param>
        /// <returns>An <see cref="ImmutableArray"/>of <see cref="LogLine"/>s</returns>
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
