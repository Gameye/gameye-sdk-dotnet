using System.Collections.Generic;

namespace Gameye.Sdk
{
    public class Team
    {
        public string TeamKey { get; set; }
        public string Name { get; set; }
        public Dictionary<string, float> Statistic { get; set; }
        public Dictionary<string, bool> Player { get; set; }
    }
}
