using System.ComponentModel.DataAnnotations.Schema;

namespace ProxyApp.Models
{
    public class UserProfile
    {
        [Column("user_profile_id")] public int ID { get; set; }

        [Column("user_profile_first_name")] public string FirstName { get; set; }

        [Column("user_profile_surname")] public string Surname { get; set; }

        [Column("user_profile_patronymic")] public string Patronymic { get; set; }

        [Column("user_profile_phone")] public string Phone { get; set; }

        [Column("user_profile_code")] public string Code { get; set; }

        [Column("user_profile_guid")] public string GUID { get; set; }

        [Column("user_profile_med_org_id")] public int MedOrgId { get; set; }
    }
}