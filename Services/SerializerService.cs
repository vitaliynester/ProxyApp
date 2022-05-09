using System;
using System.Collections.Specialized;
using System.Web;
using Newtonsoft.Json;
using ProxyApp.DTOs;

namespace ProxyApp.Services
{
    public static class SerializerService
    {
        public static NameValueCollection ConvertFormDataToDict(string formData)
        {
            try
            {
                return HttpUtility.ParseQueryString(formData);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static object DeserializeObject(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject(json);
            }
            catch (Exception)
            {
                try
                {
                    return JsonConvert.DeserializeObject<ErrorResponse>(json);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static string SerializeObject(object item)
        {
            try
            {
                return JsonConvert.SerializeObject(item);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}