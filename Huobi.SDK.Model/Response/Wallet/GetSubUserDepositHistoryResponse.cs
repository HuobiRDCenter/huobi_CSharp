using System;
namespace Huobi.SDK.Model.Response.Wallet
{
    public class GetSubUserDepositHistoryResponse
    {
        /// <summary>
        /// Status code
        /// </summary>
        public int code;

        /// <summary>
        /// Error message (if any)
        /// </summary>
        public string message;

        /// <summary>
        /// Response body
        /// </summary>
        public DepositHistory[] data;

        /// <summary>
        /// First record in next page (only valid if exceeded page size)
        /// </summary>
        public long nextId;

        public class DepositHistory
        {
            /// <summary>
            /// Deposit id
            /// </summary>
            public long id;

            /// <summary>
            /// Cryptocurrency
            /// </summary>
            public string currency;

            /// <summary>
            /// The on-chain transaction hash
            /// </summary>
            public string txHash;

            /// <summary>
            /// Block chain name
            /// </summary>
            public string chain;

            /// <summary>
            /// The number of crypto asset transferred
            /// </summary>
            public decimal amount;

            /// <summary>
            /// The deposit source address
            /// </summary>
            public string address;

            /// <summary>
            /// The deposit source address tag
            /// </summary>
            public string addressTag;

            /// <summary>
            /// The state of this transfer
            /// Possible values: unknown, confirming, confirmed, safe, orphan
            /// </summary>
            public string state;

            /// <summary>
            /// The timestamp in milliseconds for the transfer creation
            /// </summary>
            public long createTime;

            /// <summary>
            /// The timestamp in milliseconds for the transfer's latest update
            /// </summary>
            public long updateTime;
        }
    }
}
