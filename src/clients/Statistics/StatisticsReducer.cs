using Gameye.PublicApi.Queries;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Gameye.Sdk
{
    internal class StatisticsReducer
    { 
        public static StatisticsState Reduce(StatisticsState state, JArray action) 
        {
            Statistics statistics = state.Statistics.Clone();

            foreach(var statistic in action)
            {
                if (statistic is JObject)
                {
                    var path = statistic["path"].ToObject<string[]>();
                    statistics.Add(path, statistic["value"]);
                }
                else
                {
                    Console.WriteLine($"Warning: Got Non-JObject State: {statistic.ToString()}");
                }
            }
            
            return StatisticsState.WithStatistics(statistics);
        }
    }
}
