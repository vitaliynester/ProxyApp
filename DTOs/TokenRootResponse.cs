using Newtonsoft.Json;

namespace ProxyApp.DTOs
{
    public class TokenRootResponse
    {
        [JsonProperty("access_token")]
        [JsonRequired]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        [JsonRequired]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        [JsonRequired]
        public int ExpiresIn { get; set; }

        [JsonProperty("userName")]
        [JsonRequired]
        public string UserName { get; set; }

        [JsonProperty(".issued")]
        [JsonRequired]
        public string Issued { get; set; }

        [JsonProperty(".expires")]
        [JsonRequired]
        public string Expires { get; set; }
    }
}