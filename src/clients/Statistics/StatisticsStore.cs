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
            statisticsState = StatisticsState.WithStatistics(new PatchDocument());
        }

        internal void Dispatch(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                var actions = JArray.Parse(json);
                statisticsState = StatisticsReducer.Reduce(statisticsState, actions);
                OnChange?.Invoke(statisticsState);
            }
        }
    }
}
