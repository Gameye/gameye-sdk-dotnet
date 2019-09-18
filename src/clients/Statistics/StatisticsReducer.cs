using Newtonsoft.Json.Linq;

namespace Gameye.Sdk
{
    internal class StatisticsReducer
    { 
        public static StatisticsState Reduce(StatisticsState state, JArray actions) 
        {
            var statistics = state.Statistics.Clone();

            foreach (JObject action in actions)
            {
                statistics.Patch(action.ToObject<Patch>());
            }
            
            return StatisticsState.WithStatistics(statistics);
        }
    }
}
