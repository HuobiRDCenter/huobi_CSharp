using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Response.SubUser;
using Huobi.SDK.Model.Response.Transfer;
using Huobi.SDK.Model.Response.Wallet;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to operate sub user
    /// </summary>
    public class SubUserClient
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
        public SubUserClient(string accessKey, string secretKey, string host = DEFAULT_HOST)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host);
        }

        /// <summary>
        /// Lock a specific user
        /// </summary>
        /// <param name="subUserId">sub user id</param>
        /// <returns>LockUnLockSubUserResponse</returns>
        public async Task<LockUnLockSubUserResponse> LockSubUserAsync(string subUserId)
        {
            return await LockUnlockSubUserAsync(subUserId, "lock");
        }

        /// <summary>
        /// Unlock a specific user
        /// </summary>
        /// <param name="subUserId">sub user id</param>
        /// <returns>LockUnLockSubUserResponse</returns>
        public async Task<LockUnLockSubUserResponse> UnlockSubUserAsync(string subUserId)
        {
            return await LockUnlockSubUserAsync(subUserId, "unlock");
        }

        /// <summary>
        /// Lock or unlock a specific user
        /// </summary>
        /// <param name="subUserId">sub user id</param>
        /// <param name="action">lock or unlock action</param>
        /// <returns>LockUnLockSubUserResponse</returns>
        private async Task<LockUnLockSubUserResponse> LockUnlockSubUserAsync(string subUserId, string action)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v2/sub-user/management");

            string content = $"{{ \"subUid\": \"{subUserId}\", \"action\":\"{action}\" }}";

            return await HttpRequest.PostAsync<LockUnLockSubUserResponse>(url, content);
        }

        /// <summary>
        /// Transfer currency from sub to parent account
        /// </summary>
        /// <param name="subUserId">The target sub account uid to transfer from</param>
        /// <param name="currency">The crypto currency to transfer</param>
        /// <param name="amount">The amount of asset to transfer</param>
        /// <returns></returns>
        public async Task<TransferResponse> TransferCurrencyFromSubToMasterAsync(string subUserId, string currency, decimal amount)
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
        public async Task<TransferResponse> TransferCurrencyFromMasterToSubAsync(string subUserId, string currency, decimal amount)
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
        public async Task<TransferResponse> TransferPointFromSubToMasterAsync(string subUserId, string currency, decimal amount)
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
        public async Task<TransferResponse> TransferPointFromMasterToSubAsync(string subUserId, string currency, decimal amount)
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
        private async Task<TransferResponse> TransferMasterAndSubAsync(string subUserId, string currency, decimal amount, string type)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/subuser/transfer");

            string content = $"{{ \"sub-uid\": {subUserId}, \"currency\":\"{currency}\", \"amount\":{amount}, \"type\":\"{type}\" }}";
            
            return await HttpRequest.PostAsync<TransferResponse>(url, content);
        }

        /// <summary>
        /// Parent user get sub user deposit address of corresponding chain, for a specific crypto currency (except IOTA)
        /// </summary>
        /// <param name="subUserId">Sub user id</param>
        /// <param name="currency">Crytpo currency</param>
        /// <returns>GetDepositAddressResponse</returns>
        public async Task<GetDepositAddressResponse> GetSubUserDepositAddressAsync(string subUserId, string currency)
        {
            GetRequest request = new GetRequest()
                .AddParam("subUid", subUserId)
                .AddParam("currency", currency);

            string url = _urlBuilder.Build(GET_METHOD, "/v2/sub-user/deposit-address", request);

            return await HttpRequest.GetAsync<GetDepositAddressResponse>(url);
        }

        /// <summary>
        /// Parent user get sub user deposit history
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetDepositWithdrawHistoryResponse</returns>
        public async Task<GetSubUserDepositHistoryResponse> GetSubUserDepositHistoryAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v2/sub-user/query-deposit", request);

            return await HttpRequest.GetAsync<GetSubUserDepositHistoryResponse>(url);
        }

        /// <summary>
        /// Returns the aggregated balance from all the sub-users.
        /// </summary>
        /// <returns>GetSubUserAccountBalance response</returns>
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
        public async Task<GetSubUserAccountBalanceResponse> GetSubUserAccountBalanceAsync(string subUserId)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v1/account/accounts/{subUserId}");

            return await HttpRequest.GetAsync<GetSubUserAccountBalanceResponse>(url);
        }
    }
}
