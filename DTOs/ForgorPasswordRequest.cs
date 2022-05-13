using Newtonsoft.Json;

namespace ProxyApp.DTOs
{
    public class ForgorPasswordRequest
    {
        [JsonProperty("medorgId")]
        public int MedOrgId { get; set; } = 0;
        
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}