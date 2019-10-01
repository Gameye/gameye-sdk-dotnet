using System.Collections.Generic;
using System.Collections.Immutable;

namespace Gameye.Sdk
{
    /// <summary>
    /// Session object
    /// </summary>
    public class Session
    {
        /// <summary>
        /// The unique identifier of a session. Also known as the Match Key.
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// Game image used to launch the session. Also known as the Game Key
        /// </summary>
        public string Image { get; private set; }
        /// <summary>
        /// Hosted location of the session
        /// </summary>
        public string Location { get; private set; }
        /// <summary>
        /// IP address of the Host of the session
        /// </summary>
        public string Host { get; private set; }
        /// <summary>
        /// Unix epoch time of when the session was created
        /// </summary>
        public long Created { get; private set; }
        /// <summary>
        /// Dictionary of Ports available for this session
        /// </summary>
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
}
