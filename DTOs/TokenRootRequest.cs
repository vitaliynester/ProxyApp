using Newtonsoft.Json;

namespace ProxyApp.DTOs
{
    public class TokenRootRequest
    {
        [JsonProperty("grant_type")]
        [JsonRequired]
        public string Grant_type { get; set; }

        [JsonProperty("username")]
        [JsonRequired]
        public string Username { get; set; }

        [JsonProperty("password")]
        [JsonRequired]
        public string Password { get; set; }
    }
}