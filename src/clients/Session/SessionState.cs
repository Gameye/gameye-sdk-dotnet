using System.Collections.Generic;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    public class Session
    {
        public string Id { get; private set; }
        public string Image { get; private set; }
        public string Location { get; private set; }
        public string Host { get; private set; }
        public long Created { get; private set; }
        public ImmutableDictionary<string, long> Port { get; private set; }

        public Session(string id, string image, string location, string host, long created, Dictionary<string,long> port)
        {
            Id = id;
            Image = image;
            Location = location;
            Host = host;
            Created = created;
            Port = port.ToImmutableDictionary();
        }
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
