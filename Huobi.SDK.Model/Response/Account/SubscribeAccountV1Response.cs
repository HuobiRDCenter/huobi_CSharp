using Huobi.SDK.Model.Response.WebSocket;
using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Account
{
    /// <summary>
    /// SubscribeAccountV1 response
    /// </summary>
    public class SubscribeAccountV1Response : WebSocketV1ResponseBase
    {
        /// <summary>
        /// Response body from sub
        /// </summary>
        public AccountUpdate data;

        public class AccountUpdate
        {
            /// <summary>
            /// The event type which triggers this balance updates,
            /// Possible values: [oder.place, order.match, order.refund, order.cancel, order.fee-refund,
            /// (other balance transfer event types)]
            /// </summary>
            public string @event;

            /// <summary>
            /// The list of update detail
            /// </summary>
            public UpdateDetail[] list;

            /// <summary>
            /// Update detail
            /// </summary>
            public class UpdateDetail
            {
                /// <summary>
                /// The account id of this individual balance
                /// </summary>
                [JsonProperty("account-id")]
                public int accountId;

                /// <summary>
                /// The crypto currency of this balance
                /// </summary>
                public string currency;

                /// <summary>
                /// The type of this account
                /// Possible values: [including trade, loan, interest]
                /// </summary>
                public string type;

                /// <summary>
                /// The balance of this account, include frozen balance if "model" was set to 1 in subscription
                /// </summary>
                public string balance;
            }
        }
    }
}
