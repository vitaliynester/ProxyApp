using Newtonsoft.Json;

namespace ProxyApp.DTOs
{
    public class PhoneConfirmationRequest
    {
        [JsonProperty("medorgId")] public int MedOrgId { get; set; }

        [JsonProperty("phone")] public string Phone { get; set; }
    }
}