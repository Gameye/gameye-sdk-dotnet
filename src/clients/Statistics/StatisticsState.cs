using System.Collections.Generic;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    internal class Statistics
    {
    }

    internal class StatisticsState
    {
        public ImmutableDictionary<string, Statistics> Statistics { get; private set; }

        private StatisticsState() { }

        public static StatisticsState WithStatistics(Dictionary<string, Statistics> statistics)
        {
            return new StatisticsState
            {
                Statistics = statistics.ToImmutableDictionary()
            };
        }
    }
}
