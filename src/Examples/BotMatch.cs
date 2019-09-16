using Gameye.Messaging.Client;
using Gameye.Sdk;
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
            var config = new GameyeClientConfig("https://api.gameye.org");
            var client = new GameyeClient(config);
            var sessionId = Guid.NewGuid().ToString();

            Console.WriteLine($"Creating session with id {sessionId}");

            client.SessionStore.OnChange += (SessionState state) =>
            {
                session = SessionSelectors.SelectSession(state, sessionId);
            };

            client.StatisticsStore.OnChange += (StatisticsState state) =>
            {
            };

            var currentLine = 0;
            client.LogStore.OnChange += (LogState state) =>
            {
                var lastLogs = LogSelectors.SelectSince(state, currentLine);
                foreach(var log in lastLogs)
                {
                    Console.WriteLine($"{log.LineKey}: {log.Payload}");
                }
                currentLine += lastLogs.Count();
            };

            await client.SubscribeSessionEvents();
            
            await client.CommandStartMatch(sessionId,
                "csgo-dem",
                new[] { "frankfurt" },
                "bots",
                new Dictionary<string, object> { { "maxRounds", 2 } });

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

            Console.WriteLine($"Session Destroyed");
        }
    }
}
