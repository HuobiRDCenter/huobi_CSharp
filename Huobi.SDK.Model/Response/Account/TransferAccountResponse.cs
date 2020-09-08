using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Account
{
    public class TransferAccountResponse
    {
        public string status;

        [JsonProperty("err-code")]
        public string errCode;

        [JsonProperty("err-msg")]
        public string errMessage;

        public TransferResponse data;

        public class TransferResponse
        {
            [JsonProperty("transact-id")]
            public int transactId;

            [JsonProperty("transact-time")]
            public long transactTime;
        }
    }
}
