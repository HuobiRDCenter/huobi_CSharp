namespace Huobi.SDK.Model.Response.Market
{
    /// <summary>
    /// GetDepth response
    /// </summary>
    public class GetDepthResponse
    {
        /// <summary>
        /// Response status
        /// </summary>
        public string status;

        /// <summary>
        /// The data stream
        /// </summary>
        public string ch;

        /// <summary>
        /// The timestamp (millisecond) when API respond
        /// </summary>
        public long ts;

        /// <summary>
        /// The response body
        /// </summary>
        public tickData tick;

        /// <summary>
        /// The tick data
        /// </summary>
        public class tickData
        {
            /// <summary>
            /// The UNIX timestamp in milliseconds adjusted to Singapore time
            /// </summary>
            public long ts;

            /// <summary>
            /// The internal data
            /// </summary>
            public float version;

            /// <summary>
            /// The current all ask in format [price, quote volume]
            /// </summary>
            public float[][] asks;

            /// <summary>
            /// The current all bit in format [price, quote volume]
            /// </summary>
            public float[][] bids;
        }
    }
}
