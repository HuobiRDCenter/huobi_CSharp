using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Response.Margin;
using Huobi.SDK.Model.Response.Transfer;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to operate isolated margin
    /// </summary>
    public class IsolatedMarginClient
    {
        private const string GET_METHOD = "GET";
        private const string POST_METHOD = "POST";

        private const string DEFAULT_HOST = "api.huobi.pro";

        private readonly PrivateUrlBuilder _urlBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">Access Key</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="host">the host that the client connects to</param>
        public IsolatedMarginClient(string accessKey, string secretKey, string host = DEFAULT_HOST)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host);
        }

        /// <summary>
        /// Transfer specific asset from spot trading account to isolated margin account
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="currency">The currency to transfer</param>
        /// <param name="amount">The amount of currency to transfer</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> TransferInAsync(string symbol, string currency, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/dw/transfer-in/margin");

            string body = $"{{ \"symbol\":\"{symbol}\", \"currency\":\"{currency}\", \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Transfer specific asset from isolated margin account to spot trading account
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="currency">The currency to transfer</param>
        /// <param name="amount">The amount of currency to transfer</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> TransferOutAsync(string symbol, string currency, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/dw/transfer-out/margin");

            string body = $"{{ \"symbol\":\"{symbol}\", \"currency\":\"{currency}\", \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Returns loan interest rates and quota applied on the user
        /// </summary>
        /// <param name="symbols">Trading symbol (multiple selections acceptable, separated by comma)</param>
        /// <returns>GetLoanInfoResponse</returns>
        public async Task<GetIsolatedLoanInfoResponse> GetLoanInfoAsync(string symbols)
        {
            var request = new GetRequest();

            if (!string.IsNullOrEmpty(symbols))
            {
                request.AddParam("symbols", symbols);
            }

            string url = _urlBuilder.Build(GET_METHOD, "/v1/margin/loan-info", request);

            return await HttpRequest.GetAsync<GetIsolatedLoanInfoResponse>(url);
        }

        /// <summary>
        /// Place an order to apply a margin loan.
        /// </summary>
        /// <param name="symbol">The trading symbol to borrow margin</param>
        /// <param name="currency">The currency to borrow</param>
        /// <param name="amount">The amount of currency to borrow (precision: 3 decimal places)</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> ApplyLoanAsync(string symbol, string currency, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/margin/orders");

            string body = $"{{ \"symbol\":\"{symbol}\", \"currency\":\"{currency}\", \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Repays margin loan with you asset in your margin account.
        /// </summary>
        /// <param name="orderId">The previously returned order id when loan order was created</param>
        /// <param name="amount">The amount of currency to repay</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> RepayAsync(string orderId, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/v1/margin/orders/{orderId}/repay");

            string body = $"{{ \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Returns margin orders based on a specific searching criteria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetLoanOrdersResponse</returns>
        public async Task<GetIsolatedLoanOrdersResponse> GetLoanOrdersAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/margin/loan-orders", request);

            return await HttpRequest.GetAsync<GetIsolatedLoanOrdersResponse>(url);
        }

        /// <summary>
        /// Returns the balance of the margin loan account.
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="subUid">Sub user ID (mandatory field while parent user querying sub user’s margin account details)</param>
        /// <returns>GetMarginAccountResponse</returns>
        public async Task<GetIsolatedMarginAccountResponse> GetMarginAccountAsync(string symbol, int? subUid)
        {
            var request = new GetRequest();

            if (!string.IsNullOrEmpty(symbol))
            {
                request.AddParam("symbol", symbol);
            }

            if (subUid.HasValue)
            {
                request.AddParam("sub-uid", subUid.Value.ToString());
            }

            string url = _urlBuilder.Build(GET_METHOD, "/v1/margin/accounts/balance", request);

            return await HttpRequest.GetAsync<GetIsolatedMarginAccountResponse>(url);
        }
    }
}
