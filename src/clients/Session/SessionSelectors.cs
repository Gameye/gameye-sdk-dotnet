using System.Linq;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    public static class SessionSelectors
    {
        public static ImmutableArray<Session> SelectSessionListForGame(SessionState sessionState, string gameKey)
        {
            return sessionState.Sessions.Values.Where(session => session.Image == gameKey).ToImmutableArray();
        }

        public static ImmutableArray<Session> SelectSessionList(SessionState sessionState)
        {
            return sessionState.Sessions.Values.ToImmutableArray();
        }

        public static Session SelectSession(SessionState sessionState, string sessionId)
        {
            return sessionState.Sessions[sessionId];
        }
    }
}
