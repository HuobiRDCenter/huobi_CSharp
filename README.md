# 在appsetings.json文件中，是Hmac256签名方式的变量，SIGN是“256”代表Hmac256签名方式，“25519”代表Ed25519签名方式。

#  * API_KEY和SECRET_KEY是Hmac256方式需要的公钥和私钥。PUBLIC_KEY和PRIVATE_KEY是Ed25519的公钥和私钥。

# *

#  * In the appsetings.json file，The following is the variable of the Hmac256 signature mode.

#  * SIGN indicates the Hmac256 signature mode and 25519 indicates the Ed25519 signature mode.

#  * API_KEY and SECRET_KEY are the public and private keys required for Hmac256 mode.

#  * PUBLIC_KEY and PRIVATE_KEY are the public and private keys of Ed25519.

# Huobi C# SDK For Spot v3

This is Huobi C# SDK v3, this is a lightweight .NET library, you can import to your project and use this SDK to query
all market data, trading and manage your account. The SDK supports RESTful API invoking, and subscribing the market,
account and order update from the WebSocket connection.The SDK supports both synchronous and asynchronous RESTful API
invoking, and subscribe the market, account and order update from the websocket connection.

If you already use SDK v1 or v2, it is strongly suggested migrate to v3 as we refactor the implementation to make it
simpler and easy to maintain. The SDK v3 is completely consistent with the API documentation of the new HTX open
platform. Compared to SDK versions v1 and v2, due to changes in parameters of many interfaces, in order to match the
latest interface parameter situation, v3 version has made adjustments to parameters of more than 80 interfaces to ensure
that requests can be correctly initiated and accurate response data can be obtained. Meanwhile, the v3 version has added
over 130 new interfaces available for use, greatly expanding the number of available interfaces. We will stop the
maintenance of v2 in the near future.

## Table of Contents

- [Quick Start](#Quick-Start)

- [Usage](#Usage)

    - [Configuration](#Configuration)
    - [Folder structure](#Folder-Structure)
    - [Client](#Client)
    - [Response](#Response)

- [Request examples](#Request-examples)

    - [Common data](#Common-data)
    - [Market data](#Market-data)
    - [Account](#account)
    - [Wallet](#wallet)
    - [Trading](#trading)
    - [Margin Loan](#margin-loan)

- [Subscription examples](#Subscription-examples)

    - [Subscribe trade update](#Subscribe-trade-update)
    - [Subscribe candlestick update](#Subscribe-candlestick-update)
    - [Subscribe order update](#subscribe-order-update)
    - [Subscribe account change](#subscribe-account-change)
- [Unsubscribe](#unsubscribe)

## Quick Start

*The SDK is compiled by .NET Standard 2.1*, you can import the source code in C# IDE. If you use Visual Studio, you can open the solution file directly.

The project **Huobi.SDK.Example** is a console application that you can start directly.

If you want to create your own application, you can follow below steps:

* Create a client (under namespace Huobi.SDK.Core.Client) instance.
* Call the method provided by client.

```csharp
// Get the timestamp from Huobi server and print on console
var client = new CommonClient();

var timestampResponse = client.GetTimestampAsync().Result;
Console.WriteLine($"timestamp (ms): {timestampResponse.data}");


// Get the list of accounts owned by this API user and print the detail on console
var accountClient = new AccountClient(APIKey.AccessKey, APIKey.SecretKey);

var getAIResult = accountClient.GetAccountInfoAsync().Result;
if (getAIResult != null && getAIResult.data != null)
{
  foreach (var a in getAIResult.data)
  {
    Console.WriteLine($"account id: {a.id}, type: {a.type}, state: {a.state}");
  }
}
```

## Usage

### Configuration

If you need to access private data, you need to add **key.json** into your solution. The purpose of this file is to prevent submitting SecretKey into repository by accident, so this file is added in the .gitignore file.

Just create a **key.json** file and include it into your solution with below definition

```json
{
    "SecretKey": "xxxx-xxxx-xxxx-xxxx"
}
```

After that you should set the property of **key.json** in your IDE to allow it is copied to output directory.

If you don't need to access private data, you can ignore this.

### Folder Structure

This is the folder and namespace structure of SDK source code and the description

- **Huobi.SDK.Core**: The core of the SDK
    - **Client**: The client classes that are responsible to access data
    - **Log**: The internal logger interface and implementations
    - **Model**: The internal data model used in core
    - **RequestBuilder**: Responsible to build the request with the signature
- **Huobi.SDK.Model**: The data model that user need to care about
    - **Request**: The request data model
    - **Response**: The response data model
- **Huobi.SDK.Core.Test**: The unit test of core
- **Huobi.SDK.Example**: The examples how to use **Core** and **Model** to access  API and read response.

As the example indicates, there are two important namespaces: **Huobi.SDK.Core.Client** and **Huobi.SDK.Model.Response**,  this section will introduce both of them below.

### Client

In this SDK, the client is the object to access the Huobi API. In order to isolate the private data with public data, and isolated different kind of data, the client category is designated to match the API category.

All the client is listed in below table. Each client is very small and simple, it is only responsible to operate its related data, you can pick up multiple clients to create your own application based on your business.

| Data Category   | Client                               | Privacy | Access Type  |
| --------------- | ------------------------------------ | ------- | ------------ |
| Common          | CommonClient                         | Public  | Rest         |
| Market          | MarketClient                         | Public  | Rest         |
|                 | CandlestickWebSocketClient           | Public  | WebSocket v1 |
|                 | DepthWebSocketClient                 | Public  | WebSocket v1 |
|                 | MarketByPriceWebSocketClient         | Public  | WebSocket v1 |
|                 | BestBidOfferWebSocketClient          | Public  | WebSocket v1 |
|                 | TradeWebSocketClient                 | Public  | WebSocket v1 |
|                 | Last24hCandlestickWebSocketClient    | Public  | WebSocket v1 |
|                 | MarketTickerWebSocketClient    | Public  | WebSocket v1 |
| Account         | AccountClient                        | Private | Rest         |
|                 | RequestAccountWebSocketClient        | Private | WebSocket v1 |
|                 | SubscribeAccountWebSocketV1Client    | Private | WebSocket v1 |
|                 | SubscribeAccountWebSocketV2Client    | Private | WebSocket v2 |
| Wallet          | WalletClient                         | Private | Rest         |
| Order           | OrderClient                          | Private | Rest         |
|                 | RequestOrdersWebSocketV1Client       | Private | WebSocket v1 |
|                 | RequestOrderWebSocketV1Client        | Private | WebSocket v1 |
|                 | SubscribeOrderWebSocketV1Client      | Private | WebSocket v1 |
|                 | SubscribeTradeClearWebSocketV2Client | Private | WebSocket v2 |
| Isolated Margin | IsolatedMarginClient                 | Private | Rest         |
| Cross Margin    | CrossMarginClient                    | Private | Rest         |
| Stable Coin     | StableCoinClient                     | Private | Rest         |
| ETF             | ETFClient                            | Private | Rest         |
| Algo Order| AlgoOrderClient                            | Private | Rest         |
| Sub User| SubUserClient                            | Private | Rest         |

#### Public vs. Private

There are two types of privacy that is correspondent with privacy of API:

**Public client**: It invokes public API to get public data (Common data and Market data), therefore you can create a new instance without applying an API Key.

```csharp
// Create a CommonClient instance
var client = new CommonClient();

// Create a CandlestickWebSocketClient instance
var client = new CandlestickWebSocketClient();
```

**Private client**: It invokes private API to access private data, you need to follow the API document to apply an API Key first, and pass the API Key to the constructor.

```csharp
// Create an AccountClient instance with APIKey
var accountClient = new AccountClient("AccessKey", "SecretKey");

// Create a RequestOrdersWebSocketV1Client instance with API Key
var client = new RequestOrdersWebSocketV1Client("AccessKey", "SecretKey");
```

The API key is used for authentication. If the authentication cannot pass, the invoking of private interface will fail.

#### Rest vs. WebSocket

**Rest Client**: It invokes Rest API and get once-off response.

The method for all Rest Client is **asynchronism**, it invoke Huobi API asynchronous and returns a Task immediately without blocking further statements. If you would like to get the result **synchronous**, just simply access its *Result* property, it will be blocked until the data is returned.

```csharp
// You can call the method asynchronously
var task = client.GetTimestampAsync();
// do something else
// ...
// wait for the task return
var result = await task;
  

// Or you can call the method synchronously
var result = client.GetTimestampAsync().Result;
```

You can refer to C# programming guide [Asynchronous programming with async and await](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/) to know more details.

**WebSocket Client**: It establishes WebSocket connection with server and data will be pushed from server actively. There are two types of method for WebSocket client:

- Request method: The method name starts with "Request-", it will receive the once-off data after sending the request.
- Subscription: The method name starts with "Subscribe-", it will receive update after sending the subscription.

#### Custom host

Each client constructor support an optional host parameter, by default it is "api.huobi.pro". If you need to use different host, you can specify the custom host.

```csharp
// Use "xxx.yyy.zzz" as custom host to create a public client
var client = new CommonClient("xxx.yyy.zzz");

// Use "xxx.yyy.zzz" as custom host to create a private client
var accountClient = new AccountClient("AccessKey", "SecretKey", "xxx.yyy.zzz");
```

### Response

In this SDK, the response is the object that define the data returned from API, which is deserialized from JSON string. It is the return type from each client method, you can declare the object use keyword *var* and don't need to specify the concrete type.

```csharp
// Use 'var' to declare a variable to hold the response
var symbolsResponse = client.GetSymbolsAsync().Result;
```

After that you can check the value of the response and define your own business logic. The example in this SDK assume the JSON data from API is valid and do a basic validation. To make your application robust, you'd better consider all the possibilities of the data returned from API.

```csharp
// Check the status of response and print some properties
if (symbolsResponse != null && symbolsResponse.status != null && symbolsResponse.status.Equals("ok"))
{
  foreach (var d in symbolsResponse.data)
  {
    Console.WriteLine($"{d.symbol}: {d.baseCurrency} {d.quoteCurrency}");
  }
  Console.WriteLine($"there are total {symbolsResponse.data.Length} symbols");
}
```

## Request Examples

### Common data

#### Exchange timestamp

```csharp
var client = new CommonClient();
var timestampResponse = client.GetTimestampAsync().Result;
```

#### Symbol and currencies

```csharp
var client = new CommonClient();
var symbolsResponse = client.GetSymbolsAsync().Result;

var currencysResponse = client.GetCurrencysAsync().Result;
```

### Market data

#### Candlestick/KLine

```csharp
var marketClient = new MarketClient();
var reqParams = new RequestParammeters()
                .AddParam("symbol", "btcusdt")
                .AddParam("period", "1min")
                .AddParam("size", "10");
var getCResponse = marketClient.GetCandlestickAsync(reqParams).Result;
```

#### Depth

```csharp
var marketClient = new MarketClient();
var depthReqParams = new RequestParammeters()
  .AddParam("symbol", "btcusdt")
  .AddParam("depth", "5")
  .AddParam("type", "step0");
var getDepthResponse = marketClient.GetDepthAsync(depthReqParams).Result;
```

#### Latest trade

```csharp
var marketClient = new MarketClient();
var getLastTradeResponse = marketClient.GetLastTradeAsync("btcusdt").Result;
```

#### Best bid/ask

```csharp
var marketClient = new MarketClient();
var getl24CABResponse = marketClient.GetLast24hCandlestickAskBidAsync("btcusdt").Result;
```

#### Historical trade

```csharp
var marketClient = new MarketClient();
var getLastTradesResponse = marketClient.GetLastTradesAsync("btcusdt", 3).Result;
```

#### 24H statistics

```csharp
var marketClient = new MarketClient();
var getl24CsResponse = marketClient.GetLast24hCandlesticksAsync().Result;
```

### Account

*Authentication is required.*

```csharp
var accountClient = new AccountClient(APIKey.AccessKey, APIKey.SecretKey);
var getAIResult = accountClient.GetAccountInfoAsync().Result;
```

### Wallet

*Authentication is required.*

#### Withdraw

```csharp
var walletClient = new WalletClient(APIKey.AccessKey, APIKey.SecretKey);
var request = new WithdrawRequest
{
  address = ""
};
var withdrawCResult = walletClient.WithdrawCurrencyAsync(request).Result;
```

#### Cancel withdraw

```csharp
var walletClient = new WalletClient(APIKey.AccessKey, APIKey.SecretKey);
var cancelWCResult = walletClient.CancelWithdrawCurrencyAsync(1).Result;
```

#### Withdraw and deposit history

```csharp
var walletClient = new WalletClient(APIKey.AccessKey, APIKey.SecretKey);
var depReqParams = new RequestParammeters()
  .AddParam("type", "deposit");
var getDWHResult = walletClient.GetDepositWithdrawHistoryAsync(depReqParams).Result;
```

### Trading

*Authentication is required.*

#### Create order

```csharp
var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);
var request = new PlaceOrderRequest
{
  AccountId = APIKey.AccountId,
  type = "buy-limit",
  symbol = "btcusdt",
  amount = "1",
  price = "1.1"
};

var response = tradeClient.PlaceOrderAsync(request).Result;
```

#### Cancel order

```csharp
var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);
var response = tradeClient.CancelOrderByIdAsync("1").Result;
```

#### Cancel open orders

```csharp
var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);
var bclbaRequest = new BatchCancelOrdersByAccountIdRequest
{
  AccountId = APIKey.AccountId
};
var response = tradeClient.CancelOrdersByCriteriaAsync(bclbaRequest).Result;
```

#### Get order info

```csharp
var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);
var response = tradeClient.GetOrderByIdAsync("1").Result;
```

#### Historical orders

```csharp
var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);
var reqParams = new RequestParammeters()
  .AddParam("symbol", "btcusdt")
  .AddParam("states", "canceled");
var response = tradeClient.GetHistoryOrdersAsync(reqParams).Result;
```

### Margin Loan

*Authentication is required.*

#### Apply loan

```csharp
var marginClient = new IsolatedMarginClient(APIKey.AccessKey, APIKey.SecretKey);
var response = marginClient.ApplyLoanAsync("eosht", "eos", "0.001").Result;
```

#### Repay loan

```csharp
var marginClient = new IsolatedMarginClient(APIKey.AccessKey, APIKey.SecretKey);
var response = marginClient.RepayAsync("123", "0.001").Result;
```

#### Loan history

```csharp
var marginClient = new IsolatedMarginClient(APIKey.AccessKey, APIKey.SecretKey);
var reqParams = new RequestParammeters()
  .AddParam("symbols", "btcusdt");

var response = marginClient.GetLoanOrdersAsync(reqParams).Result;
```

## Subscription Examples

### Subscribe trade update

*Authentication is required.*

```csharp
// Initialize a new instance
var client = new SubscribeTradeClearWebSocketV2Client(APIKey.AccessKey, APIKey.SecretKey);

// Add the auth receive handler
client.OnAuthenticationReceived += Client_OnAuthReceived;
void Client_OnAuthReceived(WebSocketAuthenticationV2Response response)
{
  if (response.code == 200)
  {
    // Subscribe if authentication passed
    client.Subscribe("btcusdt");
  }
}

// Add the data receive handler
client.OnDataReceived += Client_OnDataReceived;
void Client_OnDataReceived(SubscribeTradeClearResponse response)
{
  if (response != null && response.data != null)
  {
    var t = response.data;
    Console.WriteLine($"trade clear update, symbol: {t.symbol}, id: {t.orderId}, price: {t.tradePrice}, volume: {t.tradeVolume}");
  }
}

// Then connect to server and wait for the handler to handle the response
client.Connect();
```

### Subscribe candlestick update

```csharp
// Initialize a new instance
var client = new Last24hCandlestickWebSocketClient();

// Add the response receive handler
client.OnResponseReceived += Client_OnResponseReceived;
void Client_OnResponseReceived(SubscribeLast24hCandlestickResponse response)
{
  if (response != null)
  {
    if (response.tick != null)
    {
      Console.WriteLine($"id: {response.tick.id}, count: {response.tick.count}, vol: {response.tick.vol}");
    }
  }
}

// Then connect to server and wait for the handler to handle the response
client.Connect();

// Subscribe the specific topic
client.Subscribe("btcusdt");

```

### Subscribe order update

*Authentication is required.*

```csharp
// Initialize a new instance
var client = new SubscribeOrderWebSocketV1Client(APIKey.AccessKey, APIKey.SecretKey);

// Add the auth receive handler
client.OnAuthenticationReceived += Client_OnAuthReceived;
void Client_OnAuthReceived(WebSocketAuthenticationV1Response response)
{
  if (response.errCode == 0)
  {
    // Subscribe if authentication passed
    client.Subscribe("btcusdt");
  }
}

// Add the data receive handler
client.OnDataReceived += Client_OnDataReceived;
void Client_OnDataReceived(SubscribeOrderResponse response)
{
  if (response != null && response.data != null)
  {
    var o = response.data;
    Console.WriteLine($"order update, symbol: {o.symbol}, id: {o.orderId}, role: {o.role}, filled amount: {o.filledAmount}");
  }
}

// Then connect to server and wait for the handler to handle the response
client.Connect();
```

### Subscribe account change

*Authentication is required.*

```csharp
// Initialize a new instance
var client = new SubscribeAccountWebSocketV1Client(APIKey.AccessKey, APIKey.SecretKey);

// Add the auth receive handler
client.OnAuthenticationReceived += Client_OnAuthReceived;
void Client_OnAuthReceived(WebSocketAuthenticationV1Response response)
{
  if (response.errCode == 0)
  {
    // Subscribe the specific topic
    client.Subscribe("1");
  }
}

// Add the data receive handler
client.OnDataReceived += Client_OnDataReceived;
void Client_OnDataReceived(SubscribeAccountV1Response response)
{
  if (response != null && response.data != null)
  {
    Console.WriteLine($"Account update: {response.data.@event}");
    if (response.data.list != null)
    {
      foreach (var b in response.data.list)
      {
        Console.WriteLine($"account id: {b.accountId}, currency: {b.currency}, type: {b.type}, balance: {b.balance}");
      }
    }
  }
}

// Then connect to server and wait for the handler to handle the response
client.Connect();
```

## Unsubscribe

Since each websocket client manage the subscription separately, therefore you can cancel each individual subscription.

