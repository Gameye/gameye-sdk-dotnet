using Gameye.PublicApi.Queries;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Gameye.Sdk
{
    internal class StatisticsReducer
    { 
        public static StatisticsState Reduce(StatisticsState state, JArray action) 
        {
            Dictionary<string, Statistic> statistics = new Dictionary<string, Statistic>(state.Statistics);

            foreach(var statistic in action)
            {
                
            }

            
            return StatisticsState.WithStatistics(statistics);
        }
    }
}
