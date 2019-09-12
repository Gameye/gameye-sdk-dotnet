using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gameye.Sdk
{
    public class StatisticsStore
    {
        private StatisticsState statisticsState;
        /// <summary>
        /// Triggered when a statistics subsciption receieves new events
        /// </summary>
        public Action<StatisticsState> OnChange { get; set; }

        internal StatisticsStore()
        {
            statisticsState = StatisticsState.WithStatistics(new Dictionary<string, Statistic>());
        }

        internal void Dispatch(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine(json);
                var action = JArray.Parse(json);

                statisticsState = StatisticsReducer.Reduce(statisticsState, action);

                OnChange?.Invoke(statisticsState);
            }
        }
    }
}
