using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.SubUser
{
    public class SubUserTradableMarketResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public TradableMarket[] Data;
        
        public class TradableMarket
        {
            [JsonProperty("subUid", NullValueHandling = NullValueHandling.Ignore)]
            public string SubUid;

            [JsonProperty("accountType", NullValueHandling = NullValueHandling.Ignore)]
            public string AccountType;

            [JsonProperty("activation", NullValueHandling = NullValueHandling.Ignore)]
            public string Activation;

            [JsonProperty("errCode", NullValueHandling = NullValueHandling.Ignore)]
            public int ErrCode;

            [JsonProperty("errMessage", NullValueHandling = NullValueHandling.Ignore)]
            public string ErrMessage;
        }
    }
}