using Gameye.Messaging.Client;
using Gameye.Sdk;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Examples
{
    public class BotMatch
    {
        private void Sleep(int ms) => Task.Delay(ms).Wait();

        private Session session = null;
        
        public async Task Run()
        {
            var config = new GameyeClientConfig();
            var client = new GameyeClient(config);
            var sessionId = Guid.NewGuid().ToString();

            Console.WriteLine($"Creating session with id {sessionId}");

            JObject finalStats = null;
            IEnumerable<LogLine> allLogs = null;

            client.SessionStore.OnChange += (SessionState state) =>
            {
                session = state.SelectSession(sessionId);
            };

            client.StatisticsStore.OnChange += (StatisticsState state) =>
            {
                finalStats = state.SelectRawStatistics();
            };

            var currentLine = 0;
            client.LogStore.OnChange += (LogState state) =>
            {
                var lastLogs = state.SelectLogsSince(currentLine);
                foreach(var log in lastLogs)
                {
                    Console.WriteLine(log);
                }
                currentLine += lastLogs.Count();

                allLogs = state.SelectAllLogs();
            };

            await client.SubscribeSessionEvents();
            
            await client.CommandStartMatch(sessionId,
                "csgo-dem",
                new[] { "frankfurt" },
                "bots",
                new Dictionary<string, object> {{ "maxRounds", 2 }});

            while (session == null)
            {
                Sleep(10);
            }

            Console.WriteLine($"Got Session at {session.Host}");

            await client.SubscribeStatisticsEvents(sessionId);
            await client.SubscribeLogEvents(sessionId);

            while (session != null)
            {
                Sleep(10);
            }

            File.WriteAllText("Stats.txt", finalStats.ToString());
            File.WriteAllText("Logs.txt", string.Join("", allLogs));

            Console.WriteLine($"Session Destroyed");
        }
    }
}
