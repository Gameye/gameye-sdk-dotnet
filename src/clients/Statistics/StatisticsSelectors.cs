using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Gameye.Sdk
{
    public static class StatisticsSelectors
    {
        /// <summary>
        /// Select the raw statistics Json. Use this as an extension method on StatisticsState
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <returns>A Newtonsoft JObject containing the current statistics snapshot</returns>
        public static JObject SelectRawStatistics(this StatisticsState statisticsState)
            => statisticsState.Statistics.GetAt<JObject>("");

        /// <summary>
        /// Select the list of all players. Use this as an extension method on StatisticsState
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <returns>An ImmutableArray of Players</returns>
        public static ImmutableArray<Player> SelectPlayerList(this StatisticsState statisticsState)
        {
            var players = statisticsState.Statistics.GetAt<Dictionary<string, Player>>("statistic.player");
            if (players == null)
            {
                return new ImmutableArray<Player>();
            }

            return players
                .Values
                .OrderBy(player => player.PlayerKey)
                .ToImmutableArray();
        }

        /// <summary>
        /// Select the list of players on a given team. Use this as an extension method on StatisticsState
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <param name="teamKey">Key of the team</param>
        /// <returns>An ImmutableArray of Players</returns>
        public static ImmutableArray<Player> SelectPlayerListForTeam(this StatisticsState statisticsState, string teamKey)
        {
            var team = statisticsState.Statistics.GetAt<Team>($"statistic.team.{teamKey}");
            var players = statisticsState.Statistics.GetAt<Dictionary<string, Player>>("statistic.player");
            if(team == null || players == null)
            {
                return new ImmutableArray<Player>();
            }
            var teamPlayers = team.Player
                .Where(kvp => kvp.Value)
                .Select(kvp => players[kvp.Key])
                .OrderBy(player => player.PlayerKey);

            return teamPlayers.ToImmutableArray();
        }

        /// <summary>
        /// Select a single player by key. Use this as an extension method on StatisticsState
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <param name="playerKey">Key of the player</param>
        /// <returns>A player object or null if not found</returns>
        public static Player SelectPlayer(this StatisticsState statisticsState, string playerKey)
            => statisticsState.Statistics.GetAt<Player>($"statistic.player.{playerKey}");

        /// <summary>
        /// Select the list of all teams. Use this as an extension method on StatisticsState
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <returns>An ImmutableArray of Teams</returns>
        public static ImmutableArray<Team> SelectTeamList(this StatisticsState statisticsState)
        {
            var teams = statisticsState.Statistics.GetAt<Dictionary<string, Team>>($"statistic.team");
            if (teams == null)
            {
                return new ImmutableArray<Team>();
            }

            return teams
                .Values
                .OrderBy(team => team.TeamKey)
                .ToImmutableArray();
        }

        /// <summary>
        /// Select a single team by key. Use this as an extension method on StatisticsState
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <param name="teamKey">Key of the team</param>
        /// <returns>A Team object or null if not found</returns>
        public static Team SelectTeam(this StatisticsState statisticsState, string teamKey)
            => statisticsState.Statistics.GetAt<Team>($"statistic.team.{teamKey}");

        /// <summary>
        /// Select the number of started rounds. Use this as an extension method on StatisticsState
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <returns>A long representing the number of started rounds</returns>
        public static long SelectRounds(this StatisticsState statisticsState)
            => statisticsState.Statistics.GetAt<long>($"statistic.startedRounds");
    }
}
