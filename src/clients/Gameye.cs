using System.Threading.Tasks;
using Gameye.PublicApi.Commands;
using Gameye.PublicApi.Queries;
using Gameye.Messaging.Client;
using System.Collections.Generic;

namespace Gameye.Sdk
{
    public partial class GameyeClient
    {
        private readonly GameyeClientConfig clientConfig;
        private readonly ClientStore store;
        private readonly List<EventStream> activeStreams;

        public GameyeClient(GameyeClientConfig clientConfig = null)
        {
            this.clientConfig = clientConfig ?? new GameyeClientConfig();
            store = new ClientStore();
        }

        private Dictionary<string, string> Headers 
            => new Dictionary<string, string>
                {
                    { "Authorization", $"Bearer {clientConfig.Token}" },
                    { "Accept", "application/x-ndjson" }
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

        public async Task SubscribeSessionEvents()
        {
            var command = new SessionQuery();

            var eventStream = await EventStream.Create($"{clientConfig.Endpoint}/fetch/{command.Type}", null, Headers);
            activeStreams.Add(eventStream);

            eventStream.OnDataReceived += store.Dispatch;
            eventStream.Start();
            eventStream.OnEventsFinished += () =>
            {
                activeStreams.Remove(eventStream);
            };
        }

        public async Task SubscribeStatisticsEvents()
        {
            var payload = new Dictionary<string, string>
            {
                    { "matchKey", "8f5e5744-3fe9-4d2d-a425-95bfddac13af" }
            };
            var eventStream = await EventStream.Create($"{clientConfig.Endpoint}/fetch/statistics", payload, Headers);
            eventStream.OnDataReceived += store.Dispatch;
            eventStream.Start();
        }
    }
}
