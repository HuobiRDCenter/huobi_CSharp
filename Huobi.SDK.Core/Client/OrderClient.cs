using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Response.Order;
using Huobi.SDK.Model.Request;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to operate on trade
    /// </summary>
    public class OrderClient
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
        public OrderClient(string accessKey, string secretKey, string host = DEFAULT_HOST)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host);
        }

        /// <summary>
        /// Place a new order and send to the exchange to be matched.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PlaceOrderResponse</returns>
        public async Task<PlaceOrderResponse> PlaceOrderAsync(PlaceOrderRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/order/orders/place");

            return await HttpRequest.PostAsync<PlaceOrderResponse>(url, request.ToJson());
        }

        /// <summary>
        /// Place multipler orders (at most 10 orders)
        /// </summary>
        /// <param name="requests"></param>
        /// <returns>PlaceOrdersResponse</returns>
        public async Task<PlaceOrdersResponse> PlaceOrdersAsync(PlaceOrderRequest[] requests)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/order/batch-orders");

            return await HttpRequest.PostAsync<PlaceOrdersResponse>(url, JsonConvert.SerializeObject(requests));
        }

        /// <summary>
        /// Cancel an order by order id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>CancelOrderByIdResponse</returns>
        public async Task<CancelOrderByIdResponse> CancelOrderByIdAsync(string orderId)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/v1/order/orders/{orderId}/submitcancel");            

            return await HttpRequest.PostAsync<CancelOrderByIdResponse>(url);
        }

        /// <summary>
        /// Cancel an order by client order id
        /// </summary>
        /// <param name="clientOrderId">Client order id</param>
        /// <returns>CancelOrderByClientResponse</returns>
        public async Task<CancelOrderByClientResponse> CancelOrderByClientOrderIdAsync(string clientOrderId)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v1/order/orders/submitCancelClientOrder");

            string body = $"{{ \"client-order-id\":\"{clientOrderId}\" }}";

            return await HttpRequest.PostAsync<CancelOrderByClientResponse>(url, body);
        }

        /// <summary>
        /// Returns all open orders which have not been filled completely.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetOpenOrdersResponse</returns>
        public async Task<GetOpenOrdersResponse> GetOpenOrdersAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v1/order/openOrders", request);

            return await HttpRequest.GetAsync<GetOpenOrdersResponse>(url);
        }

        /// <summary>
        /// Submit cancellation for multiple orders at once with given criteria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>CancelOrdersByCriteriaResponse</returns>
        public async Task<CancelOrdersByCriteriaResponse> CancelOrdersByCriteriaAsync(CancelOrdersByCriteriaRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/v1/order/orders/batchCancelOpenOrders");

            return await HttpRequest.PostAsync<CancelOrdersByCriteriaResponse>(url, request.ToJson());
        }

        /// <summary>
        /// Submit cancellation for multiple orders at once with given ids
        /// </summary>
        /// <param name="request"></param>
        /// <returns>CancelOrdersByIdsResponse</returns>
        public async Task<CancelOrdersByIdsResponse> CancelOrdersByIdsAsync(CancelOrdersByIdsRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/v1/order/orders/batchcancel");

            return await HttpRequest.PostAsync<CancelOrdersByIdsResponse>(url, request.ToJson());
        }

        /// <summary>
        /// Returns the detail of one order by order id
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <returns>GetOrderByIdResponse</returns>
        public async Task<GetOrderResponse> GetOrderByIdAsync(string orderId)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v1/order/orders/{orderId}");

            return await HttpRequest.GetAsync<GetOrderResponse>(url);
        }

        /// <summary>
        /// Returns the detail of one order by client order id
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetOrderByIdResponse</returns>
        public async Task<GetOrderResponse> GetOrderByClientAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v1/order/orders/getClientOrder", request);

            return await HttpRequest.GetAsync<GetOrderResponse>(url);
        }

        /// <summary>
        /// Returns the match result of an order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>GetMatchResultsResponse</returns>
        public async Task<GetMatchResultsResponse> GetMatchResultsByIdAsync(string orderId)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v1/order/orders/{orderId}/matchresults");

            return await HttpRequest.GetAsync<GetMatchResultsResponse>(url);
        }

        /// <summary>
        /// Returns orders based on a specific searching criteria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetHistoryOrdersResponse</returns>
        public async Task<GetHistoryOrdersResponse> GetHistoryOrdersAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v1/order/orders", request);

            return await HttpRequest.GetAsync<GetHistoryOrdersResponse>(url);
        }

        /// <summary>
        /// Returns orders based on a specific searching criteria.
        /// Note: queriable range should be within past 1 day for cancelled order (state = "canceled")
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetHistoryOrdersResponse</returns>
        public async Task<GetHistoryOrdersResponse> GetLast48hOrdersAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v1/order/history", request);

            return await HttpRequest.GetAsync<GetHistoryOrdersResponse>(url);
        }

        /// <summary>
        /// Returns the match results of past and open orders based on specific search criteria.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetMatchResultsResponse</returns>
        public async Task<GetMatchResultsResponse> GetMatchResultsAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v1/order/matchresults", request);

            return await HttpRequest.GetAsync<GetMatchResultsResponse>(url);
        }

        /// <summary>
        /// Returns the current transaction fee rate applied to the user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetFeeResponse</returns>
        public async Task<GetFeeResponse> GetFeeAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v1/fee/fee-rate/get", request);

            return await HttpRequest.GetAsync<GetFeeResponse>(url);
        }
    }
}
