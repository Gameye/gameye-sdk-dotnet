using System.Collections.Generic;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    /// <summary>
    /// Player object for Statistics purposes
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Player key
        /// </summary>
        public string PlayerKey { get; set; }
        /// <summary>
        /// Unique identifier of a player
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// Is the player currently connected
        /// </summary>
        public bool? Connected { get; set; }
        /// <summary>
        /// Player name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Player statistics
        /// </summary>
        public ImmutableDictionary<string, float> Statistic { get; set; }
    }
}
