﻿using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Transfer
{
    /// <summary>
    /// Transfer response
    /// </summary>
    public class TransferResponse
    {
        /// <summary>
        /// Response status
        /// </summary>
        public string status;

        /// <summary>
        /// Transfer id
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public long data;

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
