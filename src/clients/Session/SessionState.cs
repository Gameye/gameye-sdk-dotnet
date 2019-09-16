using System.Collections.Generic;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    public class SessionState
    {
        public ImmutableDictionary<string, Session> Sessions { get; private set; }

        private SessionState() { }

        public static SessionState WithSessions(Dictionary<string, Session> sessions)
        {
            return new SessionState
            {
                Sessions = sessions.ToImmutableDictionary()
            };
        }
    }
}
