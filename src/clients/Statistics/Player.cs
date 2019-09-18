using System.Collections.Generic;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    public class Player
    {
        public string PlayerKey { get; set; }
        public string Uid { get; set; }
        public bool? Connected { get; set; }
        public string Name { get; set; }
        public ImmutableDictionary<string, float> Statistic { get; set; }
    }
}
