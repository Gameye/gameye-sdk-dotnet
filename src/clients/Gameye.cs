using System.Threading.Tasks;
using Gameye.PublicApi.Commands;
using Gameye.PublicApi.Queries;
using Gameye.Messaging.Client;
using System.Collections.Generic;
using System;

namespace Gameye.Sdk
{
    public partial class GameyeClient
    {
        private readonly GameyeClientConfig clientConfig;
        private readonly ClientStore store;

        public GameyeClient(GameyeClientConfig clientConfig = null)
        {
            this.clientConfig = clientConfig ?? new GameyeClientConfig();
            store = new ClientStore();
        }

        private const int HEARTBEAT_INTERVAL = 10 * 1000;

        private Dictionary<string, string> Headers 
            => new Dictionary<string, string>
                {
                    { "Authorization", $"Bearer {clientConfig.Token}" },
                    { "Accept", "application/x-ndjson" },
                    { "x-heartbeat-interval", $"{HEARTBEAT_INTERVAL}" },
                };


        public async Task CommandStartMatch(string matchKey,
            string gameKey,
            string[] locationKeys,
            string templateKey,
            Dictionary<string, object> config,
            string endCallbackUrl = null)
        {
            var command = new StartMatchCommand
            {
                Payload =
                {
                    MatchKey = matchKey,
                    GameKey = gameKey,
                    LocationKeys = locationKeys,
                    TemplateKey = templateKey,
                    Config = config,
                    EndCallbackUrl = endCallbackUrl
                }
            };

            await Command.Invoke($"{clientConfig.Endpoint}/action/{command.Type}", command.Payload, Headers);
        }

        public async Task CommandStopMatch(string matchKey)
        {
            var command = new StopMatchCommand
            {
                Payload =
                {
                    MatchKey = matchKey
                }
            };

            await Command.Invoke($"{clientConfig.Endpoint}/action/{command.Type}", command.Payload, Headers);
        }

        public async Task SubscribeSessionEvents(Action onStreamClosed = null)
        {
            var command = new SessionQuery();

            var eventStream = await EventStream.Create($"{clientConfig.Endpoint}/fetch/{command.Type}", null, Headers);

            eventStream.OnDataReceived += store.Dispatch;
            eventStream.Start();
            eventStream.OnEventsFinished += () =>
            {
                onStreamClosed?.Invoke();
            };
        }

        public async Task SubscribeStatisticsEvents(Action onStreamClosed = null)
        {
            var payload = new Dictionary<string, string>
            {
                    { "matchKey", "8f5e5744-3fe9-4d2d-a425-95bfddac13af" }
            };
            var eventStream = await EventStream.Create($"{clientConfig.Endpoint}/fetch/statistics", payload, Headers);
            eventStream.OnDataReceived += store.Dispatch;
            eventStream.Start();
            eventStream.OnEventsFinished += () =>
            {
                onStreamClosed?.Invoke();
            };
        }
    }
}
