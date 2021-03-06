﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

namespace Gameye.Sdk.Tests
{
    [TestClass]
    public class StatisticsSelectorTests
    {
        private PatchDocument CreateStatistics()
        {
            var json = File.ReadAllText("Content/stats.json");
            var document = JsonConvert.DeserializeObject(json) as JObject;
            return new PatchDocument(document);
        }

        [TestMethod]
        public void SelectsAllPlayers()
        {
            var statisticsState = StatisticsState.WithStatistics(CreateStatistics());
            var filtered = statisticsState.SelectPlayerList();

            Assert.AreEqual(10, filtered.Length);
            Assert.AreEqual("Ivan", filtered.First(player => player.PlayerKey == "11").Name);
        }

        [TestMethod]
        public void SelectsOnlyRequestedPlayers()
        {
            var statisticsState = StatisticsState.WithStatistics(CreateStatistics());
            var filtered = statisticsState.SelectPlayerListForTeam("1");

            Assert.AreEqual(5, filtered.Length);
            Assert.IsNotNull(filtered.FirstOrDefault(player => player.PlayerKey == "7"));
            Assert.IsNotNull(filtered.FirstOrDefault(player => player.Name == "Seth"));
            Assert.IsNull(filtered.FirstOrDefault(player => player.Name == "Zane"));
            Assert.IsNull(filtered.FirstOrDefault(player => player.PlayerKey == "8"));

            var selected = statisticsState.SelectPlayer("5");
            Assert.AreEqual("John", selected.Name);
        }

        [TestMethod]
        public void SelectsAllTeams()
        {
            var statisticsState = StatisticsState.WithStatistics(CreateStatistics());
            var filtered = statisticsState.SelectTeamList();

            Assert.AreEqual(2, filtered.Length);
            Assert.AreEqual("Terrorists", filtered.First(team => team.TeamKey== "2").Name);
        }

        [TestMethod]
        public void SelectsOnlyRequestedTeams()
        {
            var statisticsState = StatisticsState.WithStatistics(CreateStatistics());
            var team = statisticsState.SelectTeam("1");

            Assert.IsNotNull(team);
            Assert.AreEqual("1", team.TeamKey);
            Assert.AreEqual("Counter Terrorists", team.Name);
        }

        [TestMethod]
        public void SelectsRounds()
        {
            var statisticsState = StatisticsState.WithStatistics(CreateStatistics());
            var rounds = statisticsState.SelectRounds();

            Assert.AreEqual(2, rounds);
        }

        [TestMethod]
        public void SelectsRawStatistics()
        {
            var statisticsState = StatisticsState.WithStatistics(CreateStatistics());
            var raw = statisticsState.SelectRawStatistics();

            var json = File.ReadAllText("Content/stats.json");
            Assert.AreEqual(json, raw.ToString());
        }
    }
}
