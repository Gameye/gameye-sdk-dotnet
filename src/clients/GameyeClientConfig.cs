using System;

namespace Gameye.Sdk
{
    /// <summary>
    /// Client config for the Gameye SDK
    /// </summary>
    public class GameyeClientConfig
    {
        public string Endpoint { get; }
        public string Token { get; }

        /// <summary>
        /// Create a new client config
        /// </summary>
        /// <param name="endpoint">The endpoint provided to you by Gameye</param>
        /// <param name="token">The API token provided to you by Gameye</param>
        /// <exception cref="MissingConfigException">When a required element is missing from the config</exception>
        public GameyeClientConfig(string endpoint = null, string token = null)
        {
            var endpointEnvVar = Environment.GetEnvironmentVariable("GAMEYE_API_ENDPOINT");
            var fallbackEndpoint = string.IsNullOrEmpty(endpointEnvVar) ? "https://api.gameye.com" : endpointEnvVar;

            var fallbackToken = Environment.GetEnvironmentVariable("GAMEYE_API_TOKEN");
            Endpoint = string.IsNullOrWhiteSpace(endpoint) ? fallbackEndpoint : endpoint;
            Token = string.IsNullOrWhiteSpace(token) ? fallbackToken : token;

            if (Token == null)
            {
                throw new MissingConfigException("Token");
            }
        }
    }

    /// <summary>
    /// Exception representing a missing field in the GameyeClientConfig
    /// </summary>
    public class MissingConfigException : Exception
    {
        public MissingConfigException(string field) : base($"The field {field} is missing from the config") { }
    }

}
