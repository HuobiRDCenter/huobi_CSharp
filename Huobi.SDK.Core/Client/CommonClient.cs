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
        /// Get system status, Incidents and planned maintenance.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetSystemStatus()
        {
            string url = "https://status.huobigroup.com/api/v2/summary.json";

            return await HttpRequest.GetStringAsync(url);
        }

        /// <summary>
        /// Returns current market status
        /// </summary>
        /// <returns>GetMarketStatusResponse</returns>
        public async Task<GetMarketStatusResponse> GetMarketStatusAsync()
        {
            string url = _urlBuilder.Build("/v2/market-status");

            return await HttpRequest.GetAsync<GetMarketStatusResponse>(url);
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
        
        /// <summary>
        /// 获取所有交易对(V2)
        /// </summary>
        /// <param name="ts">ts</param>
        /// <returns>GetSymbolsAsync</returns>
        public async Task<GetSymbolsV2Response> GetSymbolsV2Async(long ts)
        {
            string url = _urlBuilder.Build($"/v2/settings/common/symbols?ts={ts}");

            return await HttpRequest.GetAsync<GetSymbolsV2Response>(url);
        }
        
        /// <summary>
        /// 获取所有币种(V2)
        /// </summary>
        /// <param name="ts">ts</param>
        /// <returns>GetCurrenciesV2Async</returns>
        public async Task<GetCurrenciesV2Response> GetCurrenciesV2Async(long ts)
        {
            string url = _urlBuilder.Build($"/v2/settings/common/currencies?ts={ts}");

            return await HttpRequest.GetAsync<GetCurrenciesV2Response>(url);
        }
        
        /// <summary>
        /// 获取币种配置
        /// </summary>
        /// <param name="ts">ts</param>
        /// <returns>GetCurrencysV1Async</returns>
        public async Task<GetCurrencysv1Response> GetCurrencysV1Async(long ts)
        {
            string url = _urlBuilder.Build($"/v1/settings/common/currencys?ts={ts}");

            return await HttpRequest.GetAsync<GetCurrencysv1Response>(url);
        }
        
        /// <summary>
        /// 获取交易对配置
        /// </summary>
        /// <param name="ts">ts</param>
        /// <returns>GetSymbolsV1Async</returns>
        public async Task<GetSymbolsV1Response> GetSymbolsV1Async(long ts)
        {
            string url = _urlBuilder.Build($"/v1/settings/common/symbols?ts={ts}");

            return await HttpRequest.GetAsync<GetSymbolsV1Response>(url);
        }
        
        /// <summary>
        /// 获取市场交易对配置
        /// </summary>
        /// <param name="ts">ts</param>
        /// <param name="symbols">symbols</param>
        /// <returns>GetMarketSymbolsAsync</returns>
        public async Task<GetMarketSymbolsResponse> GetMarketSymbolsAsync(string symbols, long ts)
        {
            string url = _urlBuilder.Build($"/v1/settings/common/market-symbols?symbols={symbols}&ts={ts}");

            return await HttpRequest.GetAsync<GetMarketSymbolsResponse>(url);
        }
        
        /// <summary>
        /// 获取市场交易对配置
        /// </summary>
        /// <param name="ts">ts</param>
        /// <param name="showDesc">showDesc</param>
        /// <param name="currency">currency</param>
        /// <returns>GetMarketSymbolsAsync</returns>
        public async Task<GetChainsResponse> GetChainsAsync(string showDesc, string currency, long ts)
        {
            string url = _urlBuilder.Build($"/v1/settings/common/chains?show-desc={showDesc}&currency={currency}&ts={ts}");

            return await HttpRequest.GetAsync<GetChainsResponse>(url);
        }
    }
}
