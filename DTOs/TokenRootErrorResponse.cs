using System;
using Newtonsoft.Json;

namespace ProxyApp.DTOs
{
    public class TokenRootErrorResponse
    {
        [JsonProperty("error")] public string Error { get; set; }

        [JsonProperty("error_description")] public string Description { get; set; }

        public static TokenRootErrorResponse FromJson(string json)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<TokenRootErrorResponse>(json);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}