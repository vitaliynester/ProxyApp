using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProxyApp.DTOs;
using ProxyApp.Services;

namespace ProxyApp.Controllers
{
    [RoutePrefix("api/Registration")]
    public class RegistrationController : BaseApiController
    {
        [HttpPost]
        [ResponseType(typeof(PatientAuthorizationRequestResponse))]
        [Route("Authorization")]
        public async Task<IHttpActionResult> Authorization()
        {
            var requestString = GetBodyFromRequest();

            var url = _baseUrl + "/api/Registration/Authorization";

            var response = await HttpService.Post(url, requestString,
                requestString.Contains("\"") ? ContentType.JSON : ContentType.FormData);

            try
            {
                var responseModel = PatientAuthorizationRequestResponse.FromJson(response.Body);

                try
                {
                    var userProfile =
                        await UserProfileService.FindByPhoneAndMedOrgId(responseModel.Patient.Phone,
                            responseModel.BranchId);
                    userProfile.Surname = responseModel.Patient.Surname[1].ToString();
                    userProfile.FirstName = responseModel.Patient.Name;
                    userProfile.Patronymic = responseModel.Patient.Patronymic;
                    userProfile.GUID = responseModel.ActionGUID;
                    await UserProfileService.Update(userProfile);
                }
                catch (Exception)
                {
                }

                return new JsonHttpStatusResult<PatientAuthorizationRequestResponse>(responseModel, response.StatusCode,
                    this);
            }
            catch (Exception)
            {
                return new JsonHttpStatusResult<ErrorResponse>(ErrorResponse.FromJson(response.Body),
                    response.StatusCode, this);
            }
        }

        [HttpPost]
        [ResponseType(typeof(PatientAuthorizationResponse))]
        [Route("CheckAuthorization")]
        public async Task<IHttpActionResult> CheckAuthorization()
        {
            var requestString = GetBodyFromRequest();

            var url = _baseUrl + "/api/Registration/CheckAuthorization";

            var response = await HttpService.Post(url, requestString,
                requestString.Contains("\"") ? ContentType.JSON : ContentType.FormData);

            try
            {
                var responseModel = PatientAuthorizationResponse.FromJson(response.Body);

                try
                {
                    var GUID = requestString.Contains("\"")
                        ? (SerializerService.DeserializeObject(requestString) as GuidInformation).GUID
                        : SerializerService.ConvertFormDataToDict(requestString).Get("GUID");

                    if (responseModel.Success && responseModel.Processed)
                    {
                        var userProfile = await UserProfileService.FindByActionGuid(GUID);
                        userProfile.Surname = responseModel.Patient.Surname[1].ToString();
                        userProfile.FirstName = responseModel.Patient.Name;
                        userProfile.Patronymic = responseModel.Patient.Patronymic;
                        await UserProfileService.Update(userProfile);
                    }
                }
                catch (Exception)
                {
                }

                return new JsonHttpStatusResult<PatientAuthorizationResponse>(
                    PatientAuthorizationResponse.FromJson(response.Body), response.StatusCode, this);
            }
            catch (Exception)
            {
                return new JsonHttpStatusResult<ErrorResponse>(ErrorResponse.FromJson(response.Body),
                    response.StatusCode, this);
            }
        }

        [HttpPost]
        [Route("CurrentRegistration")]
        public async Task<IHttpActionResult> CurrentRegistration()
        {
            var requestString = GetBodyFromRequest();

            var url = _baseUrl + "/api/Registration/CurrentRegistration";

            var response = await HttpService.Post(url, requestString,
                requestString.Contains("\"") ? ContentType.JSON : ContentType.FormData);

            return new JsonHttpStatusResult<object>(null, response.StatusCode, this);
        }
    }
}