using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.SubUser
{
    public class GetSubUserAccountListResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public AccountList Data;
        
        public class AccountList
        {
            [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
            public long Uid;

            [JsonProperty("deductMode", NullValueHandling = NullValueHandling.Ignore)]
            public object DeductMode;

            [JsonProperty("list", NullValueHandling = NullValueHandling.Ignore)]
            public ListObject[] List;
        }

        public class ListObject
        {
            [JsonProperty("accountType", NullValueHandling = NullValueHandling.Ignore)]
            public string AccountType;

            [JsonProperty("activation", NullValueHandling = NullValueHandling.Ignore)]
            public string Activation;

            [JsonProperty("transferrable", NullValueHandling = NullValueHandling.Ignore)]
            public bool Transferrable;

            [JsonProperty("accountIds", NullValueHandling = NullValueHandling.Ignore)]
            public AccountIdsObject[] AccountIds;
        }

        public class AccountIdsObject
        {
            [JsonProperty("accountId", NullValueHandling = NullValueHandling.Ignore)]
            public long AccountId;

            [JsonProperty("subType", NullValueHandling = NullValueHandling.Ignore)]
            public string SubType;

            [JsonProperty("accountStatus", NullValueHandling = NullValueHandling.Ignore)]
            public string AccountStatus;
        }
    }
}