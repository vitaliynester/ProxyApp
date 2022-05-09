using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using ProxyApp.Data;
using ProxyApp.Models;

namespace ProxyApp.Services
{
    public static class UserProfileService
    {
        private static readonly UserProfileContext _db = new UserProfileContext();

        public static async Task Add(UserProfile userProfile)
        {
            _db.UserProfiles.Add(userProfile);
            await _db.SaveChangesAsync();
        }

        public static async Task Update(UserProfile userProfile)
        {
            _db.UserProfiles.AddOrUpdate(userProfile);
            await _db.SaveChangesAsync();
        }

        public static async Task<UserProfile> FindByActionGuid(string actionGuid)
        {
            return await _db.UserProfiles.FirstOrDefaultAsync(up => up.GUID == actionGuid);
        }

        public static IQueryable<UserProfile> FindAllByPhoneAndMedOrgId(string phoneNumber, int medOrgId)
        {
            return _db.UserProfiles.Where(up =>
                up.Phone == phoneNumber && up.MedOrgId == medOrgId && up.FirstName != null);
        }

        public static async Task<UserProfile> FindByPhoneAndMedOrgId(string phoneNumber, int medOrgId)
        {
            return await _db.UserProfiles.FirstOrDefaultAsync(up => up.Phone == phoneNumber && up.MedOrgId == medOrgId);
        }
    }
}