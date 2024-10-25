using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Request.Margin;
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
        public CrossMarginClient(string accessKey, string secretKey,string sign, string host = DEFAULT_HOST)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host,sign);
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
        public async Task<GetCrossLoanOrdersResponse> GetLoanOrders(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/cross-margin/loan-orders", request);

            return await HttpRequest.GetAsync<GetCrossLoanOrdersResponse>(url);
        }

        /// <summary>
        /// Returns the balance of the margin loan account.
        /// </summary>
        /// <returns>GetCrossMarginAccountResponse</returns>
        public async Task<GetCrossMarginAccountResponse> GetMarginAccount(string subUserId)
        {
            GetRequest request = new GetRequest()
                .AddParam("sub-uid", subUserId);
            string url = _urlBuilder.Build(GET_METHOD, "/v1/cross-margin/accounts/balance", request);

            return await HttpRequest.GetAsync<GetCrossMarginAccountResponse>(url);
        }

        /// <summary>
        /// General repays margin loan.
        /// </summary>
        /// <param name="request">GeneralRepayRequest</param>
        /// <returns>TransferResponse</returns>
        public async Task<GeneralRepayResponse> GeneralRepay(GeneralRepayRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/v2/account/repayment");

            return await HttpRequest.PostAsync<GeneralRepayResponse>(url, request.ToJson());
        }

        /// <summary>
        /// Returns the repayment records
        /// </summary>
        /// <returns>GetCrossMarginAccountResponse</returns>
        public async Task<GetRepaymentResponse> GetRepayment(GetRepaymentRequest request)
        {
            GetRequest getRequest = new GetRequest()
                .AddParam("repayId", request.repayId)
                .AddParam("accountId", request.accountId)
                .AddParam("currency", request.currency)
                .AddParam("startTime", request.startTime.ToString())
                .AddParam("endTime", request.endTime.ToString())
                .AddParam("sort", request.sort)
                .AddParam("limit", request.limit.ToString())
                .AddParam("fromId", request.fromId.ToString());

            string url = _urlBuilder.Build(GET_METHOD, "/v2/account/repayment", getRequest);

            return await HttpRequest.GetAsync<GetRepaymentResponse>(url);
        }
        
        /// <summary>
        /// 获取杠杆持仓限额（全仓）
        /// </summary>
        /// <param name="currency">currency</param>
        /// <returns>GetSubMarginLimitResponse</returns>
        public async Task<GetSubMarginLimitResponse> GetSubMarginLimitAsync(string currency)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v2/margin/limit?currency={currency}");

            return await HttpRequest.GetAsync<GetSubMarginLimitResponse>(url);
        }
    }
}
