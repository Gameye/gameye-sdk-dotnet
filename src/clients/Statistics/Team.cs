using System.Collections.Generic;

namespace Gameye.Sdk
{
    /// <summary>
    /// Team object for Statistics purposes
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Team key
        /// </summary>
        public string TeamKey { get; set; }
        /// <summary>
        /// Team name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Team statistics
        /// </summary>
        public Dictionary<string, float> Statistic { get; set; }
        /// <summary>
        /// Dictionary of players and whether they are currently on this team
        /// </summary>
        public Dictionary<string, bool> Player { get; set; }
    }
}
