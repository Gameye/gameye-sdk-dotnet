using System.Linq;
using System.Collections.Immutable;
using Newtonsoft.Json.Linq;

namespace Gameye.Sdk
{
    public static class StatisticsSelectors
    {
        public static JObject SelectRawStatistics(StatisticsState statisticsState)
        {
            return statisticsState.Statistics.GetAt<JObject>("");
        }
    }
}
