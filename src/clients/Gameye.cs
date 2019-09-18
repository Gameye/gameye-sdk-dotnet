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
        public SessionStore SessionStore { get; private set; }
        public StatisticsStore StatisticsStore { get; private set; }
        public LogStore LogStore { get; private set; }

        /// <summary>
        /// Create a new client
        /// </summary>
        /// <param name="clientConfig"></param>
        public GameyeClient(GameyeClientConfig clientConfig = null)
        {
            this.clientConfig = clientConfig ?? new GameyeClientConfig();
            SessionStore = new SessionStore();
            StatisticsStore = new StatisticsStore();
            LogStore = new LogStore();
        }

        private const int HEARTBEAT_INTERVAL = 10 * 1000;

        private Dictionary<string, string> StreamHeaders
             => new Dictionary<string, string>
                 {
                            { "Authorization", $"Bearer {clientConfig.Token}" },
                            { "Accept", "application/x-ndjson" },
                            { "x-heartbeat-interval", $"{HEARTBEAT_INTERVAL}" },
                 };

        private Dictionary<string, string> CommandHeaders 
            => new Dictionary<string, string>
                {
                    { "Authorization", $"Bearer {clientConfig.Token}" },
                };


        /// <summary>
        /// Start a match
        /// </summary>
        /// <param name="matchKey"></param>
        /// <param name="gameKey"></param>
        /// <param name="locationKeys"></param>
        /// <param name="templateKey"></param>
        /// <param name="config"></param>
        /// <param name="endCallbackUrl"></param>
        /// <returns>An awaitable task that finishes when the command is executed</returns>
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

            await Command.Invoke($"{clientConfig.Endpoint}/action/{command.Type}", command.Payload, CommandHeaders);
        }

        /// <summary>
        /// Stop a match
        /// </summary>
        /// <param name="matchKey"></param>
        /// <returns>An awaitable task that finishes when the command is executed</returns>
        public async Task CommandStopMatch(string matchKey)
        {
            var command = new StopMatchCommand
            {
                Payload =
                {
                    MatchKey = matchKey
                }
            };

            await Command.Invoke($"{clientConfig.Endpoint}/action/{command.Type}", command.Payload, CommandHeaders);
        }

        /// <summary>
        /// Subscribe to all session events
        /// </summary>
        /// <param name="onStreamClosed"></param>
        /// <returns>An awaitable task that finishes when the stream is opened</returns>
        public async Task SubscribeSessionEvents(Action onStreamClosed = null)
        {
            var command = new SessionQuery();

            var eventStream = await EventStream.Create($"{clientConfig.Endpoint}/fetch/{command.Type}", null, StreamHeaders);

            eventStream.OnDataReceived += SessionStore.Dispatch;
            eventStream.Start();
            eventStream.OnEventsFinished += () =>
            {
                onStreamClosed?.Invoke();
            };
        }

        /// <summary>
        /// Subscribe to all statistic events for a given match
        /// </summary>
        /// <param name="matchKey"></param>
        /// <param name="onStreamClosed"></param>
        /// <returns>An awaitable task that finishes when the stream is opened</returns>
        public async Task SubscribeStatisticsEvents(string matchKey, Action onStreamClosed = null)
        {
            var eventStream = await EventStream.Create($"{clientConfig.Endpoint}/fetch/statistic", new { matchKey }, StreamHeaders);
            eventStream.OnDataReceived += StatisticsStore.Dispatch;
            eventStream.Start();
            eventStream.OnEventsFinished += () =>
            {
                onStreamClosed?.Invoke();
            };
        }

        /// <summary>
        /// Subscribe to all log events for a given match
        /// </summary>
        /// <param name="matchKey"></param>
        /// <param name="onStreamClosed"></param>
        /// <returns>An awaitable task that finishes when the stream is opened</returns>
        public async Task SubscribeLogEvents(string matchKey, Action onStreamClosed = null)
        {
            var eventStream = await EventStream.Create($"{clientConfig.Endpoint}/fetch/log", new { matchKey }, StreamHeaders);
            eventStream.OnDataReceived += LogStore.Dispatch;
            eventStream.Start();
            eventStream.OnEventsFinished += () =>
            {
                onStreamClosed?.Invoke();
            };
        }
    }
}
