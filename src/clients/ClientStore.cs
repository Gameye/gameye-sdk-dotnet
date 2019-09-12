using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Gameye.Sdk
{
    internal class ClientStore
    {
        private SessionState sessionState;
        private StatisticsState statisticsState;

        public ClientStore()
        {
            sessionState = SessionState.WithSessions(new Dictionary<string, Session>());
            statisticsState = StatisticsState.WithStatistics(new Dictionary<string, Statistics>());
        }

        public void Dispatch(string json)
        {
            var action = JObject.Parse(json);

            sessionState = SessionReducer.Reduce(sessionState, action);
            statisticsState = StatisticsReducer.Reduce(statisticsState, action);
        }

    }
}
