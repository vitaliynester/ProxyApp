using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProxyApp.Models
{
    public class UserProfile
    {
        [JsonProperty("id")]
        [Column("user_profile_id")] 
        public int ID { get; set; }

        [JsonProperty("first_name")]
        [Column("user_profile_first_name")] 
        public string FirstName { get; set; }

        [JsonProperty("surname")]
        [Column("user_profile_surname")] 
        public string Surname { get; set; }

        [JsonProperty("patronymic")]
        [Column("user_profile_patronymic")] 
        public string Patronymic { get; set; }

        [JsonProperty("phone")]
        [Column("user_profile_phone")] 
        public string Phone { get; set; }

        [JsonProperty("barcode")]
        [Column("user_profile_barcode")] 
        public string Barcode { get; set; }

        [JsonProperty("guid")]
        [Column("user_profile_guid")] 
        public string GUID { get; set; }

        [JsonProperty("med_org_id")]
        [Column("user_profile_med_org_id")] 
        public int MedOrgId { get; set; }
    }
}