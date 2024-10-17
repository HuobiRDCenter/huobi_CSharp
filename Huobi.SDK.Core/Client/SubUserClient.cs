using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Request.SubUser;
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
        public SubUserClient(string accessKey, string secretKey,string sign, string host = DEFAULT_HOST)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host,sign);
        }


        /// <summary>
        /// The user get the UID
        /// </summary>
        /// <returns></returns>
        public async Task<GetUIDResponse> GetUIDAsync()
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v2/user/uid");

            return await HttpRequest.GetAsync<GetUIDResponse>(url);
        }

        /// <summary>
        /// The parent user creates sub users
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateSubUserResponse> CreateSubUserAsync(CreateSubUserRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v2/sub-user/creation");

            return await HttpRequest.PostAsync<CreateSubUserResponse>(url, request.ToJson());
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
            return await TransferMasterAndSubAsync(subUserId, currency, amount, "master-transfer-in", "");
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
            return await TransferMasterAndSubAsync(subUserId, currency, amount, "master-transfer-out", "");
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
            return await TransferMasterAndSubAsync(subUserId, currency, amount, "master-point-transfer-in", "");
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
            return await TransferMasterAndSubAsync(subUserId, currency, amount, "master-point-transfer-out", "");
        }

        /// <summary>
        /// Transfer asset between parent and sub account.
        /// </summary>
        /// <param name="subUserId">The target sub account uid to transfer to or from</param>
        /// <param name="currency">The crypto currency to transfer</param>
        /// <param name="amount">The amount of asset to transfer</param>
        /// <param name="type">The type of transfer. Possible values: [master-transfer-in, master-transfer-out, master-point-transfer-in, master-point-transfer-out]</param>
        /// <returns></returns>
        private async Task<TransferResponse> TransferMasterAndSubAsync(string subUserId, string currency, decimal amount, string type, string clientOrderId)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/subuser/transfer");

            string content = $"{{ \"sub-uid\": {subUserId}, \"currency\":\"{currency}\", \"amount\":{amount}, \"type\":\"{type}\", \"client-order-id\":\"{clientOrderId}\" }}";
            
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
        
        /// <summary>
        /// 设置子用户手续费抵扣模式
        /// </summary>
        /// <param name="subUids">subUids</param>
        /// <param name="deductMode">deductMode</param>
        /// <returns>DeductModeSubUserResponse</returns>
        private async Task<DeductModeSubUserResponse> DeductModeSubUserAsync(long subUids, string deductMode)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v2/sub-user/deduct-mode");

            string content = $"{{ \"subUids\": {subUids}, \"deductMode\":\"{deductMode}\" }}";

            return await HttpRequest.PostAsync<DeductModeSubUserResponse>(url, content);
        }
        
        /// <summary>
        /// 母子用户APIkey信息查询
        /// </summary>
        /// <param name="uid">uid</param>
        /// <param name="accessKey">accessKey</param>
        /// <returns>GetSubUserApiKeyResponse</returns>
        public async Task<GetSubUserApiKeyResponse> GetSubUserApiKeyAsync(long uid, string accessKey)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v2/user/api-key?uid={uid}&accessKey={accessKey}");

            return await HttpRequest.GetAsync<GetSubUserApiKeyResponse>(url);
        }
        
        /// <summary>
        /// 获取子用户列表
        /// </summary>
        /// <param name="uid">uid</param>
        /// <param name="accessKey">accessKey</param>
        /// <returns>GetSubUserUserListResponse</returns>
        public async Task<GetSubUserUserListResponse> GetSubUserUserListAsync(long fromId)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v2/sub-user/user-list?fromId={fromId}");

            return await HttpRequest.GetAsync<GetSubUserUserListResponse>(url);
        }
        
        /// <summary>
        /// 设置子用户交易权限
        /// </summary>
        /// <param name="subUids">subUids</param>
        /// <param name="accountType">accountType</param>
        /// <param name="activation">activation</param>
        /// <returns>SubUserTradableMarketResponse</returns>
        private async Task<SubUserTradableMarketResponse> SubUserTradableMarketAsync(string subUids, string accountType, string activation)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v2/sub-user/tradable-market");

            string content = $"{{ \"subUids\": \"{subUids}\", \"accountType\":\"{accountType}\", \"activation\":\"{activation}\"}}";

            return await HttpRequest.PostAsync<SubUserTradableMarketResponse>(url, content);
        }
        
        /// <summary>
        /// 设置子用户资产转出权限
        /// </summary>
        /// <param name="subUids">subUids</param>
        /// <param name="accountType">accountType</param>
        /// <param name="transferrable">transferrable</param>
        /// <returns>SubUserTransferabilityResponse</returns>
        private async Task<SubUserTransferabilityResponse> SubUserTransferabilityAsync(string subUids, string accountType, bool transferrable)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v2/sub-user/transferability");

            string content = $"{{ \"subUids\": \"{subUids}\", \"accountType\":\"{accountType}\", \"transferrable\":\"{transferrable}\"}}";

            return await HttpRequest.PostAsync<SubUserTransferabilityResponse>(url, content);
        }
        
        /// <summary>
        /// 获取特定子用户的账户列表
        /// </summary>
        /// <param name="subUid">subUid</param>
        /// <returns>GetSubUserAccountListResponse</returns>
        public async Task<GetSubUserAccountListResponse> GetSubUserAccountListAsync(long subUid)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v2/sub-user/account-list?subUid={subUid}");

            return await HttpRequest.GetAsync<GetSubUserAccountListResponse>(url);
        }
        
        /// <summary>
        /// 子用户APIkey创建
        /// </summary>
        /// <param name="subUid">subUid</param>
        /// <param name="note">note</param>
        /// <param name="permission">permission</param>
        /// <param name="otpToken">otpToken</param>
        /// <param name="ipAddresses">ipAddresses</param>
        /// <returns>SubUserApiKeyGenerationResponse</returns>
        private async Task<SubUserApiKeyGenerationResponse> SubUserApiKeyGenerationAsync(long subUid, string note, string permission, string otpToken = null, string ipAddresses = null)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v2/sub-user/api-key-generation");

            string content = $"{{ \"subUid\": {subUid}, \"note\":\"{note}\", \"permission\":\"{permission}\", \"otpToken\":\"{otpToken}\", \"ipAddresses\":\"{ipAddresses}\"}}";

            return await HttpRequest.PostAsync<SubUserApiKeyGenerationResponse>(url, content);
        }
        
        /// <summary>
        /// 修改子用户APIkey
        /// </summary>
        /// <param name="subUid">subUid</param>
        /// <param name="note">note</param>
        /// <param name="permission">permission</param>
        /// <param name="accessKey">accessKey</param>
        /// <param name="ipAddresses">ipAddresses</param>
        /// <returns>SubUserApiKeyModificationResponse</returns>
        private async Task<SubUserApiKeyModificationResponse> SubUserApiKeyModificationAsync(long subUid, string accessKey, string note = null, string permission = null, string ipAddresses = null)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v2/sub-user/api-key-modification");

            string content = $"{{ \"subUid\": {subUid}, \"note\":\"{note}\", \"permission\":\"{permission}\", \"accessKey\":\"{accessKey}\", \"ipAddresses\":\"{ipAddresses}\"}}";

            return await HttpRequest.PostAsync<SubUserApiKeyModificationResponse>(url, content);
        }
        
        /// <summary>
        /// 删除子用户APIkey
        /// </summary>
        /// <param name="subUid">subUid</param>
        /// <param name="accessKey">accessKey</param>
        /// <returns>SubUserApiKeyDeletionResponse</returns>
        private async Task<SubUserApiKeyDeletionResponse> SubUserApiKeyDeletionAsync(long subUid, string accessKey)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v2/sub-user/api-key-deletion");

            string content = $"{{ \"subUid\": {subUid}, \"accessKey\":\"{accessKey}\"}}";

            return await HttpRequest.PostAsync<SubUserApiKeyDeletionResponse>(url, content);
        }
        
        /// <summary>
        /// 用户主动授信
        /// </summary>
        /// <param name="currency">subUid</param>
        /// <param name="amount">accessKey</param>
        /// <param name="accountId">accessKey</param>
        /// <returns>SubUserApiKeyDeletionResponse</returns>
        private async Task<SubUserTrustCreditResponse> SubUserTrustCreditAsync(string currency, double amount, long accountId)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/trust/user/active/credit");

            string content = $"{{ \"currency\": \"{currency}\", \"amount\":{amount}, \"accountId\":{accountId}}}";

            return await HttpRequest.PostAsync<SubUserTrustCreditResponse>(url, content);
        }
    }
}
