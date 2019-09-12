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
    }
}
