using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProxyApp.DTOs;
using ProxyApp.Models;
using ProxyApp.Services;

namespace ProxyApp.Controllers
{
    [RoutePrefix("api/Mobile")]
    public class MobileController : BaseApiController
    {
        [HttpPost]
        [ResponseType(typeof(PhoneConfirmationRequestResponse))]
        [Route("PhoneConfirmation")]
        public async Task<IHttpActionResult> PhoneConfirmation()
        {
            var requestString = GetBodyFromRequest();

            var url = _baseUrl + "/api/Mobile/PhoneConfirmation";

            var response = await HttpService.Post(url, requestString,
                requestString.Contains("\"") ? ContentType.JSON : ContentType.FormData);

            try
            {
                return new JsonHttpStatusResult<PhoneConfirmationRequestResponse>(
                    PhoneConfirmationRequestResponse.FromJson(response.Body), response.StatusCode, this);
            }
            catch (Exception)
            {
                return new JsonHttpStatusResult<ErrorResponse>(ErrorResponse.FromJson(response.Body),
                    response.StatusCode, this);
            }
        }

        [HttpPost]
        [ResponseType(typeof(CodeConfirmationRequestResponse))]
        [Route("CodeConfirmation")]
        public async Task<IHttpActionResult> CodeConfirmation()
        {
            var requestString = GetBodyFromRequest();

            var url = _baseUrl + "/api/Mobile/CodeConfirmation";

            var response = await HttpService.Post(url, requestString,
                requestString.Contains("\"") ? ContentType.JSON : ContentType.FormData);

            try
            {
                var responseModel = CodeConfirmationRequestResponse.FromJson(response.Body);
                return new JsonHttpStatusResult<CodeConfirmationRequestResponse>(responseModel, response.StatusCode, this);
            }
            catch (Exception)
            {
                return new JsonHttpStatusResult<ErrorResponse>(ErrorResponse.FromJson(response.Body),
                    response.StatusCode, this);
            }
        }
    }
}