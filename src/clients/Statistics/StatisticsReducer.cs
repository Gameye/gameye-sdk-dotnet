using Gameye.PublicApi.Queries;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Gameye.Sdk
{
    internal class StatisticsReducer
    { 
        public static StatisticsState Reduce(StatisticsState state, JToken action) 
        {
            Dictionary<string, Statistics> statistics = new Dictionary<string, Statistics>(state.Statistics);

            switch (action["type"].ToString())
            {
                case "statistic":

                    statistics.Clear();
                    
                    break;
            }

            return StatisticsState.WithStatistics(statistics);
        }
    }
}
