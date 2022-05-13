using Newtonsoft.Json;
using System;

namespace ProxyApp.DTOs
{
    public class ConfirmForgotPasswordRequestResponse
    {
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        public static ConfirmForgotPasswordRequestResponse FromJson(string json)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<ConfirmForgotPasswordRequestResponse>(json);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}