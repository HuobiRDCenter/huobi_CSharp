using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Huobi.SDK.Core
{
    /// <summary>
    /// The staic class that wrap the GET and POST Http request
    /// </summary>
    public class HttpRequest
    {

        public static ILogger logger=NullLogger.Instance;

        /// <summary>
        /// Send Http GET request
        /// </summary>
        /// <typeparam name="T">The response type</typeparam>
        /// <param name="url">Request url</param>
        /// <returns>The generic response type</returns>
        public static async Task<T> GetAsync<T>(string url)
        {
            var httpClient = new HttpClient();
            logger.LogInformation($"RquestStart:{url}");

            string response = await httpClient.GetStringAsync(url);
            logger.LogInformation($"RequestEnd:{url}");


            T t = JsonConvert.DeserializeObject<T>(response);

            return t;
        }

        /// <summary>
        /// Send Http GET request
        /// </summary>
        /// <typeparam name="T">The response type</typeparam>
        /// <param name="url">Request url</param>
        /// <returns>The generic response type</returns>
        public static async Task<string> GetStringAsync(string url)
        {
            var httpClient = new HttpClient();
            logger.LogInformation($"RquestStart:{url}");



            string response = await httpClient.GetStringAsync(url);
            logger.LogInformation($"RequestEnd:{url}");

            return response;
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

            logger.LogInformation($"RquestStart:{url}");


            var response = await httpClient.PostAsync(url, httpContent);

            string result = await response.Content.ReadAsStringAsync();

            logger.LogInformation($"RequestEnd:{url}");

            T t = JsonConvert.DeserializeObject<T>(result);

            return t;
        }
    }
}
