using System.ComponentModel.DataAnnotations;

namespace ProxyApp.DTOs
{
    public class UserProfileRequest
    {
        [Required] public int MedOrgId { get; set; }

        [Required] public string Phone { get; set; }
    }
}