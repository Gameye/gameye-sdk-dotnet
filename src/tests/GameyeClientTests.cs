using Gameye.PublicApi.Commands;
using Gameye.Sdk.Tests.TestUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;

namespace Gameye.Sdk.Tests
{
    [TestClass]
    public class GameyeClientTests
    {
        [TestMethod]
        public async Task InvokesStartMatch()
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            var server = new HttpServer(HttpServer.GetNextPort());
            server.Start();

            server.OnRequest += async (Uri endpoint, NameValueCollection headers, Stream stream) =>
            {
                StreamReader reader = new StreamReader(stream);
                var jsonString = await reader.ReadToEndAsync();
                var jsonObject = JsonConvert.DeserializeObject<StartMatchCommandPayload>(jsonString);

                Assert.IsTrue(endpoint.PathAndQuery.Contains("start-match"));
                Assert.AreEqual("Bearer 1234", headers.Get("Authorization"));
                Assert.AreEqual("matchKey", jsonObject.MatchKey);
                var configDictionary = jsonObject.Config as JToken;
                Assert.AreEqual("value", configDictionary["key"]);

                taskCompletionSource.SetResult(true);
            };

            var config = new GameyeClientConfig($"http://127.0.0.1:{server.Port}", "1234");
            var client = new GameyeClient(config);

            var matchConfig = new Dictionary<string, object> { { "key", "value" } };
            await client.CommandStartMatch("matchKey",
                "gameKey",
                new[] { "locationOne", "locationTwo" },
                "templateKey",
                matchConfig);

            taskCompletionSource.Task.Wait();
            server.Stop();
        }

        [TestMethod]
        public async Task InvokesStopMatch()
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            var server = new HttpServer(HttpServer.GetNextPort());
            server.Start();

            server.OnRequest += async (Uri endpoint, NameValueCollection headers, Stream stream) =>
            {
                StreamReader reader = new StreamReader(stream);
                var jsonString = await reader.ReadToEndAsync();
                var jsonObject = JsonConvert.DeserializeObject<StopMatchCommandPayload>(jsonString);

                Assert.IsTrue(endpoint.PathAndQuery.Contains("stop-match"));
                Assert.AreEqual("matchKey", jsonObject.MatchKey);

                taskCompletionSource.SetResult(true);
            };

            var config = new GameyeClientConfig($"http://127.0.0.1:{server.Port}", "1234");
            var client = new GameyeClient(config);

            var matchConfig = new Dictionary<string, object> { { "key", "value" } };
            await client.CommandStopMatch("matchKey");

            taskCompletionSource.Task.Wait();
            server.Stop();
        }

        // TODO: Session, Stats and Logs sub calls!!
    }
}
