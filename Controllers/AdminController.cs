using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using ProxyApp.Data;
using ProxyApp.Models;

namespace ProxyApp.Controllers
{
    public class AdminController : BaseApiController
    {
        private UserProfileContext db = new UserProfileContext();

        // GET: api/Admin
        public HttpResponseMessage GetUserProfiles()
        {
            if (!IsAuthorized())
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            var userProfiles = db.UserProfiles;
            var response = Request.CreateResponse(HttpStatusCode.OK, userProfiles);
            response.Headers.Add("Access-Control-Expose-Headers", "X-Total-Count");
            response.Headers.Add("X-Total-Count", userProfiles.Count().ToString());
            return response;
        }

        // GET: api/Admin/5
        [ResponseType(typeof(UserProfile))]
        public async Task<HttpResponseMessage> GetUserProfile(int id)
        {
            if (!IsAuthorized())
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            UserProfile userProfile = await db.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, userProfile);
        }

        // PUT: api/Admin/5
        [ResponseType(typeof(void))]
        public async Task<HttpResponseMessage> PutUserProfile(int id, UserProfile userProfile)
        {
            if (!IsAuthorized())
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            if (!ModelState.IsValid)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                return response;
            }

            if (id != userProfile.ID)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }

            db.Entry(userProfile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileExists(id))
                {
                    var response = Request.CreateResponse(HttpStatusCode.NotFound);
                    return response;
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, userProfile);
        }

        // DELETE: api/Admin/5
        [ResponseType(typeof(UserProfile))]
        public async Task<HttpResponseMessage> DeleteUserProfile(int id)
        {
            if (!IsAuthorized())
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            UserProfile userProfile = await db.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.UserProfiles.Remove(userProfile);
            await db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, userProfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserProfileExists(int id)
        {
            return db.UserProfiles.Count(e => e.ID == id) > 0;
        }

        private bool IsAuthorized()
        {
            var re = Request;
            var headers = re.Headers;
            var targetHeader = "5d194a71-f5e4-4618-9367-4a1dcd39c5e2";

            return headers.Contains("Admin-Header") && headers.GetValues("Admin-Header").First() == targetHeader;
        }
    }
}