using Newtonsoft.Json;

namespace ProxyApp.DTOs
{
    public class ConfirmForgotPasswordRequest
    {
        [JsonProperty("medorgId")]
        public int MedOrgId { get; set; } = 0;

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}