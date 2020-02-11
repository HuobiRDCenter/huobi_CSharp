using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Response.Account;
using Huobi.SDK.Model.Response.Transfer;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to operate account
    /// </summary>
    public class AccountClient
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
        public AccountClient(string accessKey, string secretKey, string host = DEFAULT_HOST)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host);
        }

        /// <summary>
        /// Returns a list of accounts owned by this API user
        /// </summary>
        /// <returns>GetAccountInfoResponse</returns>
        public async Task<GetAccountInfoResponse> GetAccountInfoAsync()
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/account/accounts");

            return await HttpRequest.GetAsync<GetAccountInfoResponse>(url);
        }

        /// <summary>
        /// Returns the balance of an account specified by account id
        /// </summary>
        /// <param name="accountId">account id</param>
        /// <returns>GetAccountBalanceResponse</returns>
        public async Task<GetAccountBalanceResponse> GetAccountBalanceAsync(string accountId)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v1/account/accounts/{accountId}/balance");

            return await HttpRequest.GetAsync<GetAccountBalanceResponse>(url);
        }

        /// <summary>
        /// Returns the amount changes of specified user's account
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetAccountHistoryResponse</returns>
        public async Task<GetAccountHistoryResponse> GetAccountHistoryAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/account/history", request);

            return await HttpRequest.GetAsync<GetAccountHistoryResponse>(url);
        }

        /// <summary>
        /// Transfer fund from spot account to futrue contract account.
        /// </summary>
        /// <param name="currency">Currency name</param>
        /// <param name="amount">Amount of fund to transfer	</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> TransferFromSpotToFutureAsync(string currency, decimal amount)
        {
            return await TransferSpotAndFutureAsync(currency, amount, "pro-to-futures");
        }

        /// <summary>
        /// Transfer fund from future contract account spot account.
        /// </summary>
        /// <param name="currency">Currency name</param>
        /// <param name="amount">Amount of fund to transfer</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> TransferFromFutureToSpotAsync(string currency, decimal amount)
        {
            return await TransferSpotAndFutureAsync(currency, amount, "futures-to-pro");
        }

        /// <summary>
        /// transfer fund between spot account and futrue contract account
        /// </summary>
        /// <param name="currency">Currency name</param>
        /// <param name="amount">Amount of fund to transfer</param>
        /// <param name="type">Type of the transfer, possible values: [futures-to-pro, pro-to-futures]</param>
        /// <returns>TransferResponse</returns>
        private async Task<TransferResponse> TransferSpotAndFutureAsync(string currency, decimal amount, string type)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/futures/transfer");

            string content = $"{{ \"currency\": \"{currency}\", \"amount\":\"{amount}\", \"type\":\"{type}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, content);
        }

        /// <summary>
        /// Transfer currency from sub to parent account
        /// </summary>
        /// <param name="subUserId">The target sub account uid to transfer from</param>
        /// <param name="currency">The crypto currency to transfer</param>
        /// <param name="amount">The amount of asset to transfer</param>
        /// <returns></returns>
        public async Task<TransferResponse> TransferCurrencyFromSubToMasterAsync(long subUserId, string currency, decimal amount)
        {
            return await TransferMasterAndSubAsync(subUserId, currency, amount, "master-transfer-in");
        }

        /// <summary>
        /// Transfer currency from parent to sub account
        /// </summary>
        /// <param name="subUserId">The target sub account uid to transfer to</param>
        /// <param name="currency">The crypto currency to transfer</param>
        /// <param name="amount">The amount of asset to transfer</param>
        /// <returns></returns>
        public async Task<TransferResponse> TransferCurrencyFromMasterToSubAsync(long subUserId, string currency, decimal amount)
        {
            return await TransferMasterAndSubAsync(subUserId, currency, amount, "master-transfer-out");
        }

        /// <summary>
        /// Transfer point from parent to sub account.
        /// </summary>
        /// <param name="subUserId">The target sub account uid to transfer to or from</param>
        /// <param name="currency">The crypto currency to transfer</param>
        /// <param name="amount">The amount of asset to transfer</param>
        /// <returns></returns>
        public async Task<TransferResponse> TransferPointFromSubToMasterAsync(long subUserId, string currency, decimal amount)
        {
            return await TransferMasterAndSubAsync(subUserId, currency, amount, "master-point-transfer-in");
        }

        /// <summary>
        ///  transfer point from sub to parent account.
        /// </summary>
        /// <param name="subUserId">The target sub account uid to transfer to or from</param>
        /// <param name="currency">The crypto currency to transfer</param>
        /// <param name="amount">The amount of asset to transfer</param>
        /// <returns></returns>
        public async Task<TransferResponse> TransferPointFromMasterToSubAsync(long subUserId, string currency, decimal amount)
        {
            return await TransferMasterAndSubAsync(subUserId, currency, amount, "master-point-transfer-out");
        }

        /// <summary>
        /// Transfer asset between parent and sub account.
        /// </summary>
        /// <param name="subUserId">The target sub account uid to transfer to or from</param>
        /// <param name="currency">The crypto currency to transfer</param>
        /// <param name="amount">The amount of asset to transfer</param>
        /// <param name="type">The type of transfer. Possible values: [master-transfer-in, master-transfer-out, master-point-transfer-in, master-point-transfer-out]</param>
        /// <returns></returns>
        private async Task<TransferResponse> TransferMasterAndSubAsync(long subUserId, string currency, decimal amount, string type)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/subuser/transfer");

            string content = $"{{ \"sub-uid\": \"{subUserId}\", \"currency\":\"{currency}\", \"amount\":\"{amount}\", \"type\":\"{type}\" }}";
            
            return await HttpRequest.PostAsync<TransferResponse>(url, content);
        }

        /// <summary>
        /// GetSubUserAccountBalance response
        /// </summary>
        /// <returns></returns>
        public async Task<GetSubUserAccountBalancesResponse> GetSubUserAccountBalancesAsync()
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/subuser/aggregate-balance");

            return await HttpRequest.GetAsync<GetSubUserAccountBalancesResponse>(url);
        }

        /// <summary>
        /// Returns the balance of a sub-account specified by sub-uid.
        /// </summary>
        /// <param name="subUserId">Sub user id</param>
        /// <returns>GetAccountBalanceResponse</returns>
        public async Task<GetSubUserAccountBalanceResponse> GetSubUserAccountBalanceAsync(long subUserId)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v1/account/accounts/{subUserId}");

            return await HttpRequest.GetAsync<GetSubUserAccountBalanceResponse>(url);
        }
    }
}
