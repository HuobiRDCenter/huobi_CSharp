using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Account
{
    public class GetAccountSwitchUserInfoResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public GetAccountSwitchUserInfo Data { get; set; }
        
        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public bool Success { get; set; }

        public class GetAccountSwitchUserInfo
        {
            [JsonProperty("pointSwitch", NullValueHandling = NullValueHandling.Ignore)]
            public int PointSwitch { get; set; }

            [JsonProperty("currencySwitch", NullValueHandling = NullValueHandling.Ignore)]
            public int CurrencySwitch { get; set; }

            [JsonProperty("deductionCurrency", NullValueHandling = NullValueHandling.Ignore)]
            public string DeductionCurrency { get; set; }
        }
    }
}