using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ProxyApp.Services
{
    public class JsonHttpStatusResult<T> : JsonResult<T>
    {
        private readonly HttpStatusCode _httpStatus;

        public JsonHttpStatusResult(T content, int httpStatus, JsonSerializerSettings serializer, Encoding encoding,
            ApiController controller) : base(content, serializer, encoding, controller)
        {
            _httpStatus = (HttpStatusCode)httpStatus;
        }

        public JsonHttpStatusResult(T content, int httpStatus, ApiController controller) : base(content,
            new JsonSerializerSettings(), new UTF8Encoding(), controller)
        {
            _httpStatus = (HttpStatusCode)httpStatus;
        }

        public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var returnTask = base.ExecuteAsync(cancellationToken);
            returnTask.Result.StatusCode = _httpStatus;
            return returnTask;
        }
    }
}