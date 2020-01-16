using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Huobi.SDK.Core
{
    /// <summary>
    /// Wrap the GET and POST Http request
    /// </summary>
    public class HttpRequest
    {
        /// <summary>
        /// Send Http GET request
        /// </summary>
        /// <typeparam name="T">The response type</typeparam>
        /// <param name="url">Request url</param>
        /// <returns>The generic response type</returns>
        public static async Task<T> GetAsync<T>(string url)
        {
            var httpClient = new HttpClient();

            string response = await httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<T>(response);
        }

        /// <summary>
        /// Send Http POST request
        /// </summary>
        /// <typeparam name="T">The response type</typeparam>
        /// <param name="url">Request url</param>
        /// <param name="body">Request body</param>
        /// <param name="mediaTyp">Meida type, default value is "application/json"</param>
        /// <returns>The response type</returns>
        public static async Task<T> PostAsync<T>(string url, string body = null, string mediaTyp = "application/json")
        {
            StringContent httpContent;

            if (string.IsNullOrEmpty(body))
            {
                httpContent = null;
            }
            else
            {
                httpContent = new StringContent(body, Encoding.UTF8, mediaTyp);
            }

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(url, httpContent);

            string result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
