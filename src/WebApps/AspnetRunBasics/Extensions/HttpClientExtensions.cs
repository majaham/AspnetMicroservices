using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspnetRunBasics.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode && response.StatusCode != System.Net.HttpStatusCode.NotFound)
                throw new ApplicationException($"Something wrong happened while calling API. {response.ReasonPhrase}");
            var dataString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        
        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataString = JsonSerializer.Serialize(data);
            var dataContent = new StringContent(dataString);
            dataContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpClient.PostAsync(url, dataContent);
        }

        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataString = JsonSerializer.Serialize(data);
            var dataContent = new StringContent(dataString);
            dataContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpClient.PutAsync(url, dataContent);
        }
    }
}
