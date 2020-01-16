using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Order
{
    /// <summary>
    /// GetFee response
    /// </summary>
    public class GetFeeResponse
    {
        /// <summary>
        /// Response status
        /// </summary>
        public string status;

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

        /// <summary>
        /// Response body
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Fee[] data;

        /// <summary>
        /// Match result of an order
        /// </summary>
        public class Fee
        {
            /// <summary>
            /// Trading symbol
            /// </summary>
            public string symbol;

            /// <summary>
            /// Maker fee rate
            /// </summary>
            [JsonProperty("maker-fee")]
            public string makerFee;

            /// <summary>
            /// Taker fee rate
            /// </summary>
            [JsonProperty("taker-fee")]
            public string takerFee;
        }
    }
}
