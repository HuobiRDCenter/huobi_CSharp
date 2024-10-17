using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.StableCoin
{
    /// <summary>
    /// ExchangeStableCoin response
    /// </summary>
    public class ExchangeStableCoinResponse
    {
        /// <summary>
        /// Response status
        /// </summary>
        public string status;

        /// <summary>
        /// Response body
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Data data;

        public class Data
        {
            [JsonProperty("transact-id")]
            public long transactId;

            public string currency;

            public string amount;

            public string type;

            [JsonProperty("exchange-amount")]
            public string exchangeAmount;

            [JsonProperty("exchange-fee")]
            public string exchangeFee;

            public long time;
        }

        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty("err-code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode;

        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty("err-msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage;
    }
}
