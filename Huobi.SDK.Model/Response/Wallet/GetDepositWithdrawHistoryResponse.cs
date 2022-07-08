using Newtonsoft.Json;

namespace HuobiSDK.Model.Response.Wallet
{
    /// <summary>
    /// GetDepositWithdrawHistory response
    /// </summary>
    public class GetDepositWithdrawHistoryResponse
    {
        /// <summary>
        /// Response status
        /// </summary>
        public string status;

        /// <summary>
        /// Response body
        /// </summary>
        public History[] data;

        /// <summary>
        /// Deposit and withdraw history
        /// </summary>
        public class History
        {
            /// <summary>
            /// Transfer id
            /// </summary>
            public int id;

            /// <summary>
            /// Transfer type
            /// Possible values: [deposit, withdraw]
            /// </summary>
            public string type;

            /// <summary>
            /// The crypto currency
            /// </summary>
            public string currency;

            /// <summary>
            /// The on-chain transaction hash
            /// </summary>
            [JsonProperty("tx-hash")]
            public string txHash;

            /// <summary>
            /// Blockchain name
            /// </summary>
            public string chain;

            /// <summary>
            /// The number of crypto asset transfered in its minimum unit
            /// </summary>
            public double amount;

            /// <summary>
            /// The deposit or withdraw source address
            /// </summary>
            public string address;

            /// <summary>
            /// The user defined address tag
            /// </summary>
            [JsonProperty("address-tag")]
            public string addressTag;

            /// <summary>
            /// Withdraw fee
            /// </summary>
            public float fee;

            /// <summary>
            /// The state of this transfer
            /// Possible values: [verifying, failed, submitted, reexamine, canceled, pass, reject,
            ///     pre-transfer, wallet-transfer, wallet-reject, confirmed, confirm-error, repealed]
            /// </summary>
            public string state;

            /// <summary>
            /// Error code for withdrawal failure, only returned when the type is "withdraw" and
            /// the state is "reject", "wallet-reject" and "failed".
            /// </summary>
            [JsonProperty("error-code")]
            public string errorCode;

            /// <summary>
            /// Error description of withdrawal failure, only returned when the type is "withdraw" and
            /// the state is "reject", "wallet-reject" and "failed".
            /// </summary>
            [JsonProperty("error-msg")]
            public string errorMessage;

            /// <summary>
            /// The timestamp in milliseconds for the transfer creation
            /// </summary>
            public long createdAt;

            /// <summary>
            /// The timestamp in milliseconds for the transfer latest update
            /// </summary>
            public long updatedAt;
        }
    }
}
