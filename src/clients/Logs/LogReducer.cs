using Newtonsoft.Json.Linq;

namespace Gameye.Sdk
{
    internal class LogReducer
    {
        public static LogState Reduce(LogState state, JArray actions) 
        {
            var logs = state.Logs.Clone();

            foreach (JObject action in actions)
            {
                logs.Patch(action.ToObject<Patch>());
            }

            return LogState.WithLogs(logs);
        }
    }
}
