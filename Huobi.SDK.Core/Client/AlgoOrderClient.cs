using System.Threading.Tasks;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Response.AlgoOrder;
using Huobi.SDK.Model.Request.AlgoOrder;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to operate on order
    /// </summary>
    public class AlgoOrderClient
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
        public AlgoOrderClient(string accessKey, string secretKey, string host = DEFAULT_HOST)
        {
            _urlBuilder = new PrivateUrlBuilder(accessKey, secretKey, host);
        }

        /// <summary>
        /// Place a new algo order
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PlaceOrderResponse</returns>
        public async Task<PlaceOrderResponse> PlaceOrderAsync(PlaceOrderRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, "/v2/algo-orders");

            return await HttpRequest.PostAsync<PlaceOrderResponse>(url, request.ToJson());
        }

        /// <summary>
        /// Cancel an algo order by client order Ids
        /// </summary>
        /// <param name="request"></param>
        /// <returns>CancelOrdersResponse</returns>
        public async Task<CancelOrdersResponse> CancelOrdersAsync(CancelOrdersRequest request)
        {
            string url = _urlBuilder.Build(POST_METHOD, $"/v2/algo-orders/cancellation");

            return await HttpRequest.PostAsync<CancelOrdersResponse>(url, request.ToJson());
        }

        /// <summary>
        /// Returns all open orders which have not been filled completely.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetOpenOrdersResponse</returns>
        public async Task<GetOpenOrdersResponse> GetOpenOrdersAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, "/v2/algo-orders/opening", request);

            return await HttpRequest.GetAsync<GetOpenOrdersResponse>(url);
        }
        
        /// <summary>
        /// Returns algo orders that have been inactive
        /// </summary>
        /// <param name="request"></param>
        /// <returns>GetHistoryOrdersResponse</returns>
        public async Task<GetHistoryOrdersResponse> GetHistoryOrdersAsync(GetRequest request)
        {
            string url = _urlBuilder.Build(GET_METHOD, $"/v2/algo-orders/history", request);

            return await HttpRequest.GetAsync<GetHistoryOrdersResponse>(url);
        }

        /// <summary>
        /// Returns a specific algo order
        /// </summary>
        /// <param name="clientOrderId"></param>
        /// <returns>GetSpecificOrderResponse</returns>
        public async Task<GetSpecificOrderResponse> GetSpecificOrderAsync(string clientOrderId)
        {
            var request = new GetRequest()
                .AddParam("clientOrderId", clientOrderId);

            string url = _urlBuilder.Build(GET_METHOD, $"/v2/algo-orders/specific", request);

            return await HttpRequest.GetAsync<GetSpecificOrderResponse>(url);
        }


    }
}
