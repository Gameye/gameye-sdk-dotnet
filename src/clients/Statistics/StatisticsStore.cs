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
            var startStats = new Dictionary<string, JToken>();
            statisticsState = StatisticsState.WithStatistics(new Statistics(startStats));
        }

        internal void Dispatch(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                var action = JArray.Parse(json);

                statisticsState = StatisticsReducer.Reduce(statisticsState, action);

                OnChange?.Invoke(statisticsState);
            }
        }
    }
}
