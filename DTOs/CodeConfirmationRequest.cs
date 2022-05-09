using Newtonsoft.Json;

namespace ProxyApp.DTOs
{
    public class CodeConfirmationRequest
    {
        [JsonProperty("medorgId")] public int MedOrgId { get; set; }

        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("phone")] public string Phone { get; set; }
    }
}