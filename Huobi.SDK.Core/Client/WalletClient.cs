using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Response.Wallet;
using Huobi.SDK.Model.Request.Wallet;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to operate wallet
    /// </summary>
    public class WalletClient
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
        public WalletClient(string accessKey, string secretKey,string sign, string host = DEFAULT_HOST)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host,sign);
        }

        /// <summary>
        /// Get deposit address of corresponding chain, for a specific crypto currency (except IOTA)
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetDepositAddressResponse</returns>
        public async Task<GetDepositAddressResponse> GetDepositAddressAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v2/account/deposit/address", request);

            return await HttpRequest.GetAsync<GetDepositAddressResponse>(url);
        }

        /// <summary>
        /// Query withdraw quota for currencies
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetWithdrawQuotaResponse</returns>
        public async Task<GetWithdrawQuotaResponse> GetWithdrawQuotaAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v2/account/withdraw/quota", request);

            return await HttpRequest.GetAsync<GetWithdrawQuotaResponse>(url);
        }

        /// <summary>
        /// Get withdraw address
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetDepositAddressResponse</returns>
        public async Task<GetDepositAddressResponse> GetWithdrawAddressAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v2/account/withdraw/address", request);

            return await HttpRequest.GetAsync<GetDepositAddressResponse>(url);
        }


        /// <summary>
        /// Withdraw from spot trading account to an external address.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>WithdrawCurrencyResponse</returns>
        public async Task<WithdrawCurrencyResponse> WithdrawCurrencyAsync(WithdrawRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/dw/withdraw/api/create");

            return await HttpRequest.PostAsync<WithdrawCurrencyResponse>(url, request.ToJson());
        }

        /// <summary>
        /// Cancels a previously created withdraw request by its transfer id.
        /// </summary>
        /// <param name="withdrawId">The transfer id returned when create withdraw request</param>
        /// <returns>CancelWithdrawCurrencyResponse</returns>
        public async Task<CancelWithdrawCurrencyResponse> CancelWithdrawCurrencyAsync(long withdrawId)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/v1/dw/withdraw-virtual/{withdrawId}/cancel");

            return await HttpRequest.PostAsync<CancelWithdrawCurrencyResponse>(url);
        }

        /// <summary>
        /// Returns all existed withdraws and deposits and return their latest status.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetDepositWithdrawHistoryResponse</returns>
        public async Task<GetDepositWithdrawHistoryResponse> GetDepositWithdrawHistoryAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/query/deposit-withdraw", request);

            return await HttpRequest.GetAsync<GetDepositWithdrawHistoryResponse>(url);
        }
        
        /// <summary>
        /// 通过clientOrderId查询提币订单
        /// </summary>
        /// <param name="clientOrderId"></param>
        /// <returns>GetDepositWithdrawHistoryResponse</returns>
        public async Task<GetWithdrawByClientOrderIdResponse> GetWithdrawByClientOrderIdAsync(string clientOrderId)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v1/query/withdraw/client-order-id?clientOrderId={clientOrderId}");

            return await HttpRequest.GetAsync<GetWithdrawByClientOrderIdResponse>(url);
        }
    }
}
