using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Response.ETF;
using Microsoft.Extensions.Logging;
namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to operate ETF
    /// </summary>
    public class ETFClient
    {
        private const string GET_METHOD = "GET";
        private const string POST_METHOD = "POST";

        private const string DEFAULT_HOST = "api.huobi.pro";

        private const string ETF_NAME = "hb10";

        private readonly PrivateUrlBuilder _urlBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">Access Key</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="host">the host that the client connects to</param>
        public ETFClient(string accessKey, string secretKey, string host = DEFAULT_HOST, ILogger logger = null)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host);
            if (logger != null && HttpRequest.logger != null)
            {
                HttpRequest.logger = logger;
            }
        }

        /// <summary>
        /// Return the basic information of ETF creation and redemption, as well as ETF constituents
        /// </summary>
        /// <returns>GetETFInfoResponse</returns>
        public async Task<GetETFInfoResponse> GetETFInfoAsync()
        {
            var request = new GetRequest()
                .AddParam("etf_name", ETF_NAME);
            string url = _urlBuilder.Build(GET_METHOD, "/etf/swap/config", request);

            return await HttpRequest.GetAsync<GetETFInfoResponse>(url);
        }

        /// <summary>
        /// Swap in ETF
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>SwapETFResponse</returns>
        public async Task<SwapETFResponse> SwapETFInAsync(int amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/etf/swap/in");

            string body = $"{{ \"etf_name\":\"{ETF_NAME}\", \"amount\":{amount} }}";

            return await HttpRequest.PostAsync<SwapETFResponse>(url, body);
        }

        /// <summary>
        /// Swap out ETF
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>SwapETFResponse</returns>
        public async Task<SwapETFResponse> SwapETFOutAsync(int amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/etf/swap/out");

            string body = $"{{ \"etf_name\":\"{ETF_NAME}\", \"amount\":{amount} }}";

            return await HttpRequest.PostAsync<SwapETFResponse>(url, body);
        }

        /// <summary>
        /// Get past creation and redemption.(up to 100 records)
        /// </summary>
        /// <param name="offset">The offset of the records, set to 0 for the latest records</param>
        /// <param name="limit">The number of records to return, max is 100</param>
        /// <returns>GetETFSwapHistoryResponse</returns>
        public async Task<GetETFSwapHistoryResponse> GetETFSwapHistory(int offset, int limit)
        {
            var request = new GetRequest()
                .AddParam("etf_name", ETF_NAME)
                .AddParam("offset", offset.ToString())
                .AddParam("limit", limit.ToString());
            string url = _urlBuilder.Build(GET_METHOD, "/etf/swap/list", request);

            return await HttpRequest.GetAsync<GetETFSwapHistoryResponse>(url);
        }
    }
}
