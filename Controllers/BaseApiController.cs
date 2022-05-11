using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProxyApp.Controllers
{
    [EnableCors("*", "*", "*")]
    public class BaseApiController : ApiController
    {
        protected readonly string _baseUrl = ConfigurationManager.AppSettings["BaseUrl"];

        protected string GetBodyFromRequest()
        {
            var requestString = string.Empty;

            using (var reader = new StreamReader(HttpContext.Current.Request.InputStream))
            {
                requestString = reader.ReadToEnd();
            }

            return requestString;
        }
    }
}
