using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProxyApp.DTOs
{
    public class PhoneConfirmationRequestResponse
    {
        [JsonProperty("$id")] public string Id { get; set; }

        [JsonProperty("medorgId")]
        [JsonRequired]
        public int MedOrgId { get; set; }

        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("phone")] [JsonRequired] public string Phone { get; set; }

        [JsonProperty("accountExist")]
        [JsonRequired]
        public bool AccountExist { get; set; }

        [JsonProperty("password_test")] public string PasswordTest { get; set; }

        public static PhoneConfirmationRequestResponse FromJson(string json)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<PhoneConfirmationRequestResponse>(json);
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