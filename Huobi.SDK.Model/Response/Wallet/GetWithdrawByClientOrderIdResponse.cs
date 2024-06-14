using Huobi.SDK.Model.Response.Common;
using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Wallet
{
    public class GetWithdrawByClientOrderIdResponse
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public WithdrawByClientOrderId Data;
        
        public class WithdrawByClientOrderId
        {
            [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
            public string Address;

            [JsonProperty("client-order-id", NullValueHandling = NullValueHandling.Ignore)]
            public string ClientOrderID;

            [JsonProperty("address-tag", NullValueHandling = NullValueHandling.Ignore)]
            public string AddressTag;

            [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Amount;

            [JsonProperty("blockchain-confirm", NullValueHandling = NullValueHandling.Ignore)]
            public int BlockchainConfirm;

            [JsonProperty("chain", NullValueHandling = NullValueHandling.Ignore)]
            public string Chain;

            [JsonProperty("created-at", NullValueHandling = NullValueHandling.Ignore)]
            public long CreatedAt;

            [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
            public string Currency;

            [JsonProperty("error-code", NullValueHandling = NullValueHandling.Ignore)]
            public string ErrorCode;

            [JsonProperty("error-msg", NullValueHandling = NullValueHandling.Ignore)]
            public string ErrorMsg;

            [JsonProperty("fee", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Fee;

            [JsonProperty("from-addr-tag", NullValueHandling = NullValueHandling.Ignore)]
            public string FromAddrTag;

            [JsonProperty("from-address", NullValueHandling = NullValueHandling.Ignore)]
            public string FromAddress;

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public long Id;

            [JsonProperty("request-id", NullValueHandling = NullValueHandling.Ignore)]
            public string RequestID;

            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public string State;

            [JsonProperty("tx-hash", NullValueHandling = NullValueHandling.Ignore)]
            public string TxHash;

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type;

            [JsonProperty("updated-at", NullValueHandling = NullValueHandling.Ignore)]
            public long UpdatedAt;

            [JsonProperty("user-id", NullValueHandling = NullValueHandling.Ignore)]
            public long UserId;

            [JsonProperty("wallet-confirm", NullValueHandling = NullValueHandling.Ignore)]
            public int WalletConfirm;
        }
    }
}