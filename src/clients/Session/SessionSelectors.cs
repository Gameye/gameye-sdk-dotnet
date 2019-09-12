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
        public static ImmutableArray<Session> SelectSessionListForGame(SessionState sessionState, string gameKey)
        {
            return sessionState.Sessions.Values.Where(session => session.Image == gameKey).ToImmutableArray();
        }

        /// <summary>
        /// Select all the active sessions
        /// </summary>
        /// <param name="sessionState"></param>
        /// <returns>An ImmutableArray of sessions</returns>
        public static ImmutableArray<Session> SelectSessionList(SessionState sessionState)
        {
            return sessionState.Sessions.Values.ToImmutableArray();
        }

        /// <summary>
        /// Select a single session with the given id
        /// </summary>
        /// <param name="sessionState"></param>
        /// <param name="sessionId"></param>
        /// <returns>A Session instance</returns>
        public static Session SelectSession(SessionState sessionState, string sessionId)
        {
            if (!sessionState.Sessions.ContainsKey(sessionId))
            {
                return null;
            }

            return sessionState.Sessions[sessionId];
        }
    }
}
