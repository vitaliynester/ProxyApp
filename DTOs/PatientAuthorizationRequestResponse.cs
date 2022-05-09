using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProxyApp.DTOs
{
    public class PatientAuthorizationRequestResponse
    {
        [JsonProperty("$id")] public string Id { get; set; }

        public PatientData Patient { get; set; }
        public string Date { get; set; }
        public string ActionGUID { get; set; }
        public int BranchId { get; set; }
        public string Barcode { get; set; }

        public static PatientAuthorizationRequestResponse FromJson(string json)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<PatientAuthorizationRequestResponse>(json);
                var n = JObject.Parse(json);
                result.Id = n.GetValue("$id").ToString();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}