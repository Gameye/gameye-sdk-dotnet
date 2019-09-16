using Newtonsoft.Json.Linq;
using System;

namespace Gameye.Sdk
{
    public class LogStore
    {
        private LogState logState;
        /// <summary>
        /// Triggered when a Log subsciption receieves new events
        /// </summary>
        public Action<LogState> OnChange { get; set; }

        internal LogStore()
        {
            logState = LogState.WithLogs(new PatchDocument());
        }

        internal void Dispatch(string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                var actions = JArray.Parse(json);
                foreach(JObject action in actions)
                {
                    logState = LogReducer.Reduce(logState, action.ToObject<Patch>());
                }

                OnChange?.Invoke(logState);
            }
        }
    }
}
