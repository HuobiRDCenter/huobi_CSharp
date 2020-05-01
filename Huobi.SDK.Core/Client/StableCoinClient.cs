using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Response.StableCoin;
using Microsoft.Extensions.Logging;
namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to operate stable coin
    /// </summary>
    public class StableCointClient
    {
        private const string GET_METHOD = "GET";
        private const string POST_METHOD = "POST";

        private const string DEFAULT_HOST = "api.huobi.pro";

        private readonly PrivateUrlBuilder _urlBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">Access Key</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="host">the host that the client connects to</param>
        public StableCointClient(string accessKey, string secretKey, string host = DEFAULT_HOST, ILogger logger = null)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host);
            if (logger != null && HttpRequest.logger != null)
            {
                HttpRequest.logger = logger;
            }
        }

        /// <summary>
        /// Get stable coin quote
        /// </summary>
        /// <param name="currency">Stable coin name (USDT/PAX/USDC/TUSD)</param>
        /// <param name="amount">Amount of stable coin to exchange (the value must be an intger)</param>
        /// <param name="type">Type of the exchange (buy/sell)</param>
        /// <returns>GetStableCoinResponse</returns>
        public async Task<GetStableCoinResponse> GetStableCoinAsync(string currency, string amount, string type)
        {
            var request = new GetRequest()
                .AddParam("currency", currency)
                .AddParam("amount", amount)
                .AddParam("type", type);
            string url = _urlBuilder.Build(GET_METHOD, "/v1/stable-coin/quote", request);

            return await HttpRequest.GetAsync<GetStableCoinResponse>(url);
        }

        /// <summary>
        /// Exchange stable coin
        /// </summary>
        /// <param name="quoteId">Stable currency quoteID</param>
        /// <returns>ExchangeStableCoinResponse</returns>
        public async Task<ExchangeStableCoinResponse> ExchangeStableCoinAsync(string quoteId)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/v1/stable-coin/exchange");

            string body = $"{{ \"quote-id\":\"{quoteId}\" }}";

            return await HttpRequest.PostAsync<ExchangeStableCoinResponse>(url, body);
        }
    }
}
