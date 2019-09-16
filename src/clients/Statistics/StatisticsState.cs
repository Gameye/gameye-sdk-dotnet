using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    public class StatisticsState
    {
        public Statistics Statistics { get; private set; }

        private StatisticsState() { }

        public static StatisticsState WithStatistics(Statistics statistics)
        {
            return new StatisticsState
            {
                Statistics = statistics
            };
        }
    }
}
