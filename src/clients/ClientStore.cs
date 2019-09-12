using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Gameye.Sdk
{
    internal class ClientStore
    {
        public SessionState SessionState { get; private set; }
        public StatisticsState StatisticsState { get; private set; }

        public ClientStore()
        {
            SessionState = SessionState.WithSessions(new Dictionary<string, Session>());
            StatisticsState = StatisticsState.WithStatistics(new Dictionary<string, Statistics>());
        }

        public void Dispatch(string json)
        {
            var action = JObject.Parse(json);

            SessionState = SessionReducer.Reduce(SessionState, action);
            StatisticsState = StatisticsReducer.Reduce(StatisticsState, action);
        }

    }
}
