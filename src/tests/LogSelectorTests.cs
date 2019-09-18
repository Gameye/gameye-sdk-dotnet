using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Gameye.Sdk.Tests
{
    [TestClass]
    public class LogSelectorTests
    {
        private PatchDocument CreateLogs()
        {
            var json = File.ReadAllText("Content/logs.json");
            var document = JsonConvert.DeserializeObject(json) as JObject;
            return new PatchDocument(document);
        }

        [TestMethod]
        public void SelectsAllLogs()
        {
            var logState = LogState.WithLogs(CreateLogs());
            var filtered = logState.SelectAllLogs();

            Assert.AreEqual(1095, filtered.Length);
            Assert.AreEqual("561", filtered[560].LineKey);
            Assert.AreEqual("$L 09/16/2019 - 12:39:05: \"Joe<4><BOT><TERRORIST>\" dropped \"vesthelm\"", filtered[896].Payload);
        }

        [TestMethod]
        public void SelectsOnlyRequestedLogs()
        {
            var logState = LogState.WithLogs(CreateLogs());
            var filtered = logState.SelectLogsSince(912);

            Assert.AreEqual(1095 - 912, filtered.Length);
        }

    }
}
