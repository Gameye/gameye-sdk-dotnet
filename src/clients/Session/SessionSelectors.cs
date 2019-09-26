using System.Linq;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    public static class SessionSelectors
    {
        /// <summary>
        /// Select <see cref="Session"/>s with the given game key. Use this as an extension method on <see cref="SessionState"/>
        /// </summary>
        /// <param name="sessionState"></param>
        /// <param name="gameKey">Key of the game (eg: csgo)</param>
        /// <returns>An <see cref="ImmutableArray"/> of <see cref="Session"/></returns>
        public static ImmutableArray<Session> SelectSessionListForGame(this SessionState sessionState, string gameKey)
        {
            return sessionState.Sessions.Values.Where(session => session.Image == gameKey).ToImmutableArray();
        }

        /// <summary>
        /// Select all the active <see cref="Session"/>s. Use this as an extension method on <see cref="SessionState"/>
        /// </summary>
        /// <param name="sessionState"></param>
        /// <returns>An <see cref="ImmutableArray"/> of <see cref="Session"/></returns>
        public static ImmutableArray<Session> SelectSessionList(this SessionState sessionState)
        {
            return sessionState.Sessions.Values.ToImmutableArray();
        }

        /// <summary>
        /// Select a single <see cref="Session"/> with the given id. Use this as an extension method on <see cref="SessionState"/>
        /// </summary>
        /// <param name="sessionState"></param>
        /// <param name="sessionId">Unique identifier of the <see cref="Session"/>. Also known as Match Key</param>
        /// <returns>A <see cref="Session"/> object or null if not found</returns>
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
