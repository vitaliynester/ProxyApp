using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ProxyApp.DTOs;

namespace ProxyApp.Services
{
    public enum ContentType
    {
        JSON,
        FormData
    }

    public static class HttpService
    {
        private static readonly HttpClient _client = new HttpClient();

        public static async Task<ResponseData> Post(string url, string payload, ContentType contentType)
        {
            var response = string.Empty;

            var httpContent = new StringContent(payload, Encoding.UTF8,
                contentType == ContentType.JSON ? "application/json" : "application/x-www-form-urlencoded");
            var result = await _client.PostAsync(url, httpContent);

            if (result != null) response = await result.Content.ReadAsStringAsync();

            return new ResponseData
            {
                StatusCode = (int)result.StatusCode,
                Body = response
            };
        }

        public static async Task<ResponseData> Post(string url, string payload, string contentType)
        {
            var response = string.Empty;

            var httpContent = new StringContent(payload, Encoding.UTF8, contentType);
            var result = await _client.PostAsync(url, httpContent);

            if (result != null) response = await result.Content.ReadAsStringAsync();

            return new ResponseData
            {
                StatusCode = (int)result.StatusCode,
                Body = response
            };
        }
    }
}