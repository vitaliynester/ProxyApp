using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProxyApp.DTOs;
using ProxyApp.Models;
using ProxyApp.Services;

namespace ProxyApp.Controllers
{
    [RoutePrefix("api/Registration")]
    public class RegistrationController : BaseApiController
    {
        [HttpPost]
        [ResponseType(typeof(PatientAuthorizationRequestResponse))]
        [Route("Authorization")]
        public async Task<IHttpActionResult> Authorization(PatientAuthorizationRequest patientAuthorizationRequest)
        {
            var url = _baseUrl + "/api/Registration/Authorization";

            var response = await HttpService.Post(url, SerializerService.SerializeObject(patientAuthorizationRequest), ContentType.JSON);

            try
            {
                var responseModel = PatientAuthorizationRequestResponse.FromJson(response.Body);

                try
                {
                    var userProfile = new UserProfile();
                    userProfile.CreatedAt = DateTime.Now;
                    userProfile.GUID = responseModel.ActionGUID;
                    await UserProfileService.Add(userProfile);
                }
                catch (Exception ex)
                {
                    return new JsonHttpStatusResult<ErrorResponse>(ErrorResponse.FromJson(ex.Message), response.StatusCode, this);
                }
                
                return new JsonHttpStatusResult<PatientAuthorizationRequestResponse>(responseModel, response.StatusCode, this);
            }
            catch (Exception)
            {
                return new JsonHttpStatusResult<ErrorResponse>(ErrorResponse.FromJson(response.Body), response.StatusCode, this);
            }
        }

        [HttpPost]
        [ResponseType(typeof(PatientAuthorizationResponse))]
        [Route("CheckAuthorization")]
        public async Task<IHttpActionResult> CheckAuthorization(GuidInformation guid)
        {
            var url = _baseUrl + "/api/Registration/CheckAuthorization";

            var response = await HttpService.Post(url, SerializerService.SerializeObject(guid), ContentType.JSON);

            try
            {
                var responseModel = PatientAuthorizationResponse.FromJson(response.Body);

                try
                {
                    var GUID = guid.GUID;

                    if (responseModel.Success && responseModel.Processed)
                    {
                        var userProfile = await UserProfileService.FindByActionGuid(GUID);

                        var findedUsers = UserProfileService.FindAllByPhoneAndMedOrgId(responseModel.Patient.Phone, responseModel.Clinic.ClinicId);
                        foreach (var findedUser in findedUsers)
                        {
                            if (findedUser.FirstName == responseModel.Patient.Name && 
                                findedUser.Surname == responseModel.Patient.Surname[0].ToString() && 
                                findedUser.Patronymic == responseModel.Patient.Patronymic && 
                                findedUser.Barcode == responseModel.Clinic.Barcode && 
                                findedUser.ID != userProfile.ID)
                            {
                                await UserProfileService.Delete(findedUser);
                            }
                        }

                        userProfile.ConfirmedAt = DateTime.Now;
                        userProfile.Barcode = responseModel.Clinic.Barcode;
                        userProfile.MedOrgId = responseModel.Clinic.ClinicId;
                        userProfile.Phone = responseModel.Patient.Phone;
                        userProfile.Surname = responseModel.Patient.Surname[0].ToString();
                        userProfile.FirstName = responseModel.Patient.Name;
                        userProfile.Patronymic = responseModel.Patient.Patronymic;
                        userProfile.Birthdate = DateTime.Parse(responseModel.Patient.Birthdate);
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
        public async Task<IHttpActionResult> CurrentRegistration(GuidInformation guid)
        {
            var url = _baseUrl + "/api/Registration/CurrentRegistration";

            var response = await HttpService.Post(url, SerializerService.SerializeObject(guid), ContentType.JSON);

            return new JsonHttpStatusResult<object>(null, response.StatusCode, this);
        }
    }
}