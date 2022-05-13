using Newtonsoft.Json;
using System;

namespace ProxyApp.DTOs
{
    public class ForgorPasswordRequestResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }

        public static ForgorPasswordRequestResponse FromJson(string json)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<ForgorPasswordRequestResponse>(json);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}