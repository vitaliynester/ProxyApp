using System.Linq;
using System.Web.Http;
using ProxyApp.DTOs;
using ProxyApp.Models;
using ProxyApp.Services;

namespace ProxyApp.Controllers
{
    public class UserProfilesController : BaseApiController
    {
        [HttpPost]
        [Route("api/UserProfiles")]
        public IQueryable<UserProfile> GetAll(UserProfileRequest request)
        {
            if (request == null) return Enumerable.Empty<UserProfile>().AsQueryable();
            return UserProfileService.FindAllByPhoneAndMedOrgId(request.Phone, request.MedOrgId);
        }
    }
}