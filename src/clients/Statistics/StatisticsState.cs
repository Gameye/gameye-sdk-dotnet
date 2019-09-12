using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    public class Statistic
    {
        public ImmutableArray<string> Path { get; private set; }
        public object Value { get; private set; }

        public Statistic(string[] path, object value)
        {
            Path = path.ToImmutableArray();
            Value = value;
        }
    }

    public class StatisticsState
    {
        public ImmutableDictionary<string, Statistic> Statistics { get; private set; }

        private StatisticsState() { }

        public static StatisticsState WithStatistics(Dictionary<string, Statistic> statistics)
        {
            return new StatisticsState
            {
                Statistics = statistics.ToImmutableDictionary()
            };
        }
    }
}
