using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Huobi.SDK.Core
{
    /// <summary>
    /// The staic class that wrap the GET and POST Http request
    /// </summary>
    public class HttpRequest
    {
        //public static bool LogPerformanceEnabled = false;

        public static PerformanceLogger logger = new PerformanceLogger();

        /// <summary>
        /// Send Http GET request
        /// </summary>
        /// <typeparam name="T">The response type</typeparam>
        /// <param name="url">Request url</param>
        /// <returns>The generic response type</returns>
        public static async Task<T> GetAsync<T>(string url)
        {
            logger.Start();
            
            var httpClient = new HttpClient();

            string response = await httpClient.GetStringAsync(url);

            T t = JsonConvert.DeserializeObject<T>(response);

            logger.StopAndLog<T>("GET", url);

            return t;
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
            logger.Start();

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

            T t = JsonConvert.DeserializeObject<T>(result);

            logger.StopAndLog<T>("POST", url);

            return t;
        }
    }
}
