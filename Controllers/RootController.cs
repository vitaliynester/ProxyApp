using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using ProxyApp.DTOs;
using ProxyApp.Services;

namespace ProxyApp.Controllers
{
    [RoutePrefix("")]
    public class RootController : BaseApiController
    {
        [HttpPost]
        [ResponseType(typeof(TokenRootResponse))]
        [Route("Token")]
        public async Task<IHttpActionResult> Authorization()
        {
            var requestString = GetBodyFromRequest();

            var url = _baseUrl + "/Token";

            var response = await HttpService.Post(url, requestString,
                requestString.Contains("\"") ? ContentType.JSON : ContentType.FormData);

            try
            {
                return new JsonHttpStatusResult<TokenRootResponse>(
                    JsonConvert.DeserializeObject<TokenRootResponse>(response.Body), response.StatusCode, this);
            }
            catch (Exception)
            {
                return new JsonHttpStatusResult<TokenRootErrorResponse>(TokenRootErrorResponse.FromJson(response.Body),
                    response.StatusCode, this);
            }
        }
    }
}