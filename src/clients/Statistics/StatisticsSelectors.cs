using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Gameye.Sdk
{
    public static class StatisticsSelectors
    {
        public static JObject SelectRawStatistics(StatisticsState statisticsState)
        {
            return statisticsState.Statistics.GetAt<JObject>("");
        }

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

        public static Player SelectPlayer(StatisticsState statisticsState, string playerKey)
            => statisticsState.Statistics.GetAt<Player>($"statistic.player.{playerKey}");

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

        public static Team SelectTeam(StatisticsState statisticsState, string teamKey)
            => statisticsState.Statistics.GetAt<Team>($"statistic.team.{teamKey}");

        public static long SelectRounds(StatisticsState statisticsState)
            => statisticsState.Statistics.GetAt<long>($"statistic.startedRounds");
    }
}
