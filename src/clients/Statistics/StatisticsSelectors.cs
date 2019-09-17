using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Gameye.Sdk
{
    public static class StatisticsSelectors
    {
        /// <summary>
        /// Select the raw statistics Json
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <returns>A Newtonsoft JObject containing the current statistics snapshot</returns>
        public static JObject SelectRawStatistics(StatisticsState statisticsState)
            => statisticsState.Statistics.GetAt<JObject>("");

        /// <summary>
        /// Select the list of all players
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <returns>An ImmutableArray of Players</returns>
        public static ImmutableArray<Player> SelectPlayerList(StatisticsState statisticsState)
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
        /// Select the list of players on a given team
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <param name="teamKey"></param>
        /// <returns>An ImmutableArray of Players</returns>
        public static ImmutableArray<Player> SelectPlayerListForTeam(StatisticsState statisticsState, string teamKey)
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
        /// Select a single player by key
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <param name="playerKey"></param>
        /// <returns>A player object or null if not found</returns>
        public static Player SelectPlayer(StatisticsState statisticsState, string playerKey)
            => statisticsState.Statistics.GetAt<Player>($"statistic.player.{playerKey}");

        /// <summary>
        /// Select the list of all teams
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <returns>An ImmutableArray of Teams</returns>
        public static ImmutableArray<Team> SelectTeamList(StatisticsState statisticsState)
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
        /// Select a single team by key
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <param name="teamKey"></param>
        /// <returns>A Team object or null if not found</returns>
        public static Team SelectTeam(StatisticsState statisticsState, string teamKey)
            => statisticsState.Statistics.GetAt<Team>($"statistic.team.{teamKey}");

        /// <summary>
        /// Select the number of started rounds
        /// </summary>
        /// <param name="statisticsState"></param>
        /// <returns>A long representing the number of started rounds</returns>
        public static long SelectRounds(StatisticsState statisticsState)
            => statisticsState.Statistics.GetAt<long>($"statistic.startedRounds");
    }
}
