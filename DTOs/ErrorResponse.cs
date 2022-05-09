using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProxyApp.DTOs
{
    public class ErrorResponse
    {
        [JsonProperty("$id")] public string Id { get; set; }

        [JsonRequired] public string Message { get; set; }

        public static ErrorResponse FromJson(string json)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<ErrorResponse>(json);
                var n = JObject.Parse(json);
                result.Id = n.GetValue("$id").ToString();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}