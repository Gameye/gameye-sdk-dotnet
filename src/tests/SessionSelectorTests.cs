using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Gameye.Sdk.Tests
{
    [TestClass]
    public class SessionSelectorTests
    {
        private (string, Session) CreateSession(string gameKey = null, string sessionId = null)
        {
            var id = sessionId ?? Guid.NewGuid().ToString();
            var session = new Session(
                id,
                gameKey ?? Guid.NewGuid().ToString(),
                "amsterdam",
                "127.0.0.1",
                DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                new Dictionary<string, long>() { { "game", 1234 } });

            return (id, session);
        }

        [TestMethod]
        public void SelectsAllSessions()
        {
            const int unnamedSessions = 15;
            var sessions = new Dictionary<string, Session>();
            for (var i = 0; i < unnamedSessions; i++)
            {
                var (id, session) = CreateSession();
                sessions.Add(id, session);
            }

            var sessionState = SessionState.WithSessions(sessions);

            var filtered = SessionSelectors.SelectSessionList(sessionState);
            Assert.AreEqual(unnamedSessions, filtered.Length);
        }

        [TestMethod]
        public void SelectsOnlyRequestedSessions()
        {
            const int namedSessions = 3;
            const int unnamedSessions = 5;
            var sessions = new Dictionary<string, Session>();
            for (var i = 0; i < namedSessions; i++)
            {
                var (id, session) = CreateSession("game-two");
                sessions.Add(id, session);
            }
            for (var i = 0; i < unnamedSessions; i++)
            {
                var (id, session) = CreateSession();
                sessions.Add(id, session);
            }

            var sessionState = SessionState.WithSessions(sessions);

            var filtered = SessionSelectors.SelectSessionListForGame(sessionState, "game-two");
            Assert.AreEqual(namedSessions, filtered.Length);
        }

        [TestMethod]
        public void SelectsASession()
        {
            const int unnamedSessions = 15;
            var sessions = new Dictionary<string, Session>();
            for (var i = 0; i < unnamedSessions; i++)
            {
                var (id, session) = CreateSession();
                sessions.Add(id, session);
            }
            var (specificId, specificSession) = CreateSession("specific-game", "session-id-one");
            sessions.Add(specificId, specificSession);

            var sessionState = SessionState.WithSessions(sessions);

            var foundSession = SessionSelectors.SelectSession(sessionState, "session-id-one");
            Assert.AreEqual("specific-game", foundSession.Image);

            var shouldBeNull = SessionSelectors.SelectSession(sessionState, "some-key-that-shouldnt-exist");
            Assert.AreEqual(null, shouldBeNull);
        }
    }
}
