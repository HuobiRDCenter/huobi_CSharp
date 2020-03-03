using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Response.Margin;
using Huobi.SDK.Model.Response.Transfer;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to operate cross margin
    /// </summary>
    public class CrossMarginClient
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
        public CrossMarginClient(string accessKey, string secretKey, string host = DEFAULT_HOST)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host);
        }

        /// <summary>
        /// Transfer specific asset from spot trading account to cross margin account
        /// </summary>
        /// <param name="currency">The currency to transfer</param>
        /// <param name="amount">The amount of currency to transfer</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> TransferIn(string currency, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/cross-margin/transfer-in");

            string body = $"{{ \"currency\":\"{currency}\", \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Transfer specific asset from cross margin account to spot trading account
        /// </summary>
        /// <param name="currency">The currency to transfer</param>
        /// <param name="amount">The amount of currency to transfer</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> TransferOut(string currency, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/cross-margin/transfer-out");

            string body = $"{{ \"currency\":\"{currency}\", \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Returns loan interest rates and quota applied on the user
        /// </summary>
        /// <returns>GetCrossLoanInfoResponse</returns>
        public async Task<GetCrossLoanInfoResponse> GetLoanInfo()
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/cross-margin/loan-info");

            return await HttpRequest.GetAsync<GetCrossLoanInfoResponse>(url);
        }

        /// <summary>
        /// Place an order to apply a margin loan.
        /// </summary>
        /// <param name="currency">The currency to borrow</param>
        /// <param name="amount">The amount of currency to borrow (precision: 3 decimal places)</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> ApplyLoan(string currency, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/cross-margin/orders");

            string body = $"{{ \"currency\":\"{currency}\", \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Repays margin loan with you asset in your margin account.
        /// </summary>
        /// <param name="orderId">The previously returned order id when loan order was created</param>
        /// <param name="amount">The amount of currency to repay</param>
        /// <returns>TransferResponse</returns>
        public async Task<TransferResponse> Repay(string orderId, string amount)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/v1/cross-margin/orders/{orderId}/repay");

            string body = $"{{ \"amount\":\"{amount}\" }}";

            return await HttpRequest.PostAsync<TransferResponse>(url, body);
        }

        /// <summary>
        /// Returns margin orders based on a specific searching criteria.
        /// </summary>
        /// <returns>GetCrossLoanOrdersResponse</returns>
        public async Task<GetCrossLoanOrdersResponse> GetLoanOrders()
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/cross-margin/loan-orders");

            return await HttpRequest.GetAsync<GetCrossLoanOrdersResponse>(url);
        }

        /// <summary>
        /// Returns the balance of the margin loan account.
        /// </summary>
        /// <returns>GetCrossMarginAccountResponse</returns>
        public async Task<GetCrossMarginAccountResponse> GetMarginAccount()
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/cross-margin/accounts/balance");

            return await HttpRequest.GetAsync<GetCrossMarginAccountResponse>(url);
        }
    }
}
