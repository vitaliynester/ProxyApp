using System;
using System.Threading.Tasks;
using System.Web;
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
        public async Task<IHttpActionResult> PhoneConfirmation(PhoneConfirmationRequest phoneConfirmationRequest)
        {
            var url = _baseUrl + "/api/Mobile/PhoneConfirmation";

            var response = await HttpService.Post(url, SerializerService.SerializeObject(phoneConfirmationRequest), ContentType.JSON);

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
        public async Task<IHttpActionResult> CodeConfirmation(CodeConfirmationRequest codeConfirmationRequest)
        {
            var url = _baseUrl + "/api/Mobile/CodeConfirmation";

            var response = await HttpService.Post(url, SerializerService.SerializeObject(codeConfirmationRequest), ContentType.JSON);

            try
            {
                return new JsonHttpStatusResult<CodeConfirmationRequestResponse>(CodeConfirmationRequestResponse.FromJson(response.Body), response.StatusCode, this);
            }
            catch (Exception)
            {
                return new JsonHttpStatusResult<ErrorResponse>(ErrorResponse.FromJson(response.Body), response.StatusCode, this);
            }
        }

        [HttpPost]
        [ResponseType(typeof(ForgorPasswordRequestResponse))]
        [Route("ForgotPassword")]
        public async Task<IHttpActionResult> ForgotPassword(ForgorPasswordRequest forgorPasswordRequest)
        {
            var url = _baseUrl + "/api/Mobile/ForgotPassword";

            var response = await HttpService.Post(url, SerializerService.SerializeObject(forgorPasswordRequest), ContentType.JSON);

            try
            {
                return new JsonHttpStatusResult<ForgorPasswordRequestResponse>(ForgorPasswordRequestResponse.FromJson(response.Body), response.StatusCode, this);
            }
            catch (Exception)
            {
                return new JsonHttpStatusResult<ErrorResponse>(ErrorResponse.FromJson(response.Body), response.StatusCode, this);
            }
        }

        [HttpPost]
        [ResponseType(typeof(ConfirmForgotPasswordRequestResponse))]
        [Route("ConfirmForgotPassword")]
        public async Task<IHttpActionResult> ConfirmForgotPassword(ConfirmForgotPasswordRequest confirmForgotPasswordRequest)
        {
            var url = _baseUrl + "/api/Mobile/ConfirmForgotPassword";

            var response = await HttpService.Post(url, SerializerService.SerializeObject(confirmForgotPasswordRequest), ContentType.JSON);

            try
            {
                return new JsonHttpStatusResult<ConfirmForgotPasswordRequestResponse>(ConfirmForgotPasswordRequestResponse.FromJson(response.Body), response.StatusCode, this);
            }
            catch (Exception)
            {
                return new JsonHttpStatusResult<ErrorResponse>(ErrorResponse.FromJson(response.Body), response.StatusCode, this);
            }
        }
    }
}