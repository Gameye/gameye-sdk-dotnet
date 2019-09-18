using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gameye.Sdk
{
    public class SessionStore
    {
        private SessionState sessionState;

        /// <summary>
        /// Triggered when a session subsciption receieves new events
        /// </summary>
        public Action<SessionState> OnChange { get; set; }

        internal SessionStore()
        {
            sessionState = SessionState.WithSessions(new Dictionary<string, Session>());
        }

        internal void Dispatch(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                var action = JObject.Parse(json);

                sessionState = SessionReducer.Reduce(sessionState, action);

                OnChange?.Invoke(sessionState);
            }
        }
    }
}
