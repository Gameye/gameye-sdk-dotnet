using System.Linq;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    public static class SessionSelectors
    {
        /// <summary>
        /// Select sessions with the given game key
        /// </summary>
        /// <param name="sessionState"></param>
        /// <param name="gameKey"></param>
        /// <returns>An ImmutableArray of sessions</returns>
        public static ImmutableArray<Session> SelectSessionListForGame(this SessionState sessionState, string gameKey)
        {
            return sessionState.Sessions.Values.Where(session => session.Image == gameKey).ToImmutableArray();
        }

        /// <summary>
        /// Select all the active sessions
        /// </summary>
        /// <param name="sessionState"></param>
        /// <returns>An ImmutableArray of sessions</returns>
        public static ImmutableArray<Session> SelectSessionList(this SessionState sessionState)
        {
            return sessionState.Sessions.Values.ToImmutableArray();
        }

        /// <summary>
        /// Select a single session with the given id
        /// </summary>
        /// <param name="sessionState"></param>
        /// <param name="sessionId"></param>
        /// <returns>A Session object or null if not found</returns>
        public static Session SelectSession(this SessionState sessionState, string sessionId)
        {
            if (!sessionState.Sessions.ContainsKey(sessionId))
            {
                return null;
            }

            return sessionState.Sessions[sessionId];
        }
    }
}
