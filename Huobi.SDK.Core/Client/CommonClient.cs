using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Response.Common;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to get common information
    /// </summary>
    public class CommonClient
    { 
        private const string DEFAULT_HOST = "api.huobi.pro";

        private PublicUrlBuilder _urlBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">the host that the client connects to</param>
        public CommonClient(string host = DEFAULT_HOST)
        {
            _urlBuilder = new PublicUrlBuilder(host);
        }

        /// <summary>
        /// Get all Huobi's supported trading symbol.
        /// </summary>
        /// <returns>GetSymbolsResponse</returns>
        public async Task<GetSymbolsResponse> GetSymbolsAsync()
        {
            string url = _urlBuilder.Build("/v1/common/symbols");

            return await HttpRequest.GetAsync<GetSymbolsResponse>(url);
        }


        /// <summary>
        /// Get all Huobi's supported trading currencies
        /// </summary>
        /// <returns>GetCurrencysResponse</returns>
        public async Task<GetCurrencysResponse> GetCurrencysAsync()
        {
            string url = _urlBuilder.Build("/v1/common/currencys");

            return await HttpRequest.GetAsync<GetCurrencysResponse>(url);
        }

        /// <summary>
        /// Get currency information
        /// </summary>
        /// <param name="currency">currency name</param>
        /// <returns>GetCurrencyResponse</returns>
        public async Task<GetCurrencyResponse> GetCurrencyAsync(string currency, bool authorizedUser)
        {
            string url = _urlBuilder.Build($"/v2/reference/currencies?currency={currency}&authorizedUser={authorizedUser}");

            return await HttpRequest.GetAsync<GetCurrencyResponse>(url);
        }

        /// <summary>
        /// The current system time in milliseconds adjusted to Singapore time zone.
        /// </summary>
        /// <returns>GetTimestampResponse</returns>
        public async Task<GetTimestampResponse> GetTimestampAsync()
        {
            string url = _urlBuilder.Build("/v1/common/timestamp");

            return await HttpRequest.GetAsync<GetTimestampResponse>(url);
        }
    }
}
