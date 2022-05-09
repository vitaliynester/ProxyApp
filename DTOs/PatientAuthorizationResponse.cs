using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProxyApp.DTOs
{
    public class PatientAuthorizationResponse
    {
        [JsonProperty("$id")] public string Id { get; set; }

        public PatientClinicData Clinic { get; set; }
        public PatientData Patient { get; set; }
        public bool Success { get; set; }
        public bool Processed { get; set; }
        public string Message { get; set; }

        public static PatientAuthorizationResponse FromJson(string json)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<PatientAuthorizationResponse>(json);
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

    public class PatientClinicData
    {
        public int ClinicId { get; set; }
        public string Barcode { get; set; }
        public bool IsInetReception { get; set; }
    }
}