using System.Collections.Generic;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    public class Session
    {
        public string Image { get; set; }
        public string Location { get; set; }
        public string Host { get; set; }
        public long Created { get; set; }
        public Dictionary<string, long> Port { get; set; }
    }

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
