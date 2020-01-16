using Huobi.SDK.Core;
using Huobi.SDK.Core.RequestBuilder;
using Xunit;

namespace Huobi.SDK.Core.Test.RequestBuilder
{
    public class PublicUrlBuilderTest
    {
        [Fact]
        public void Build_NoRequestParameter_Success()
        {
            var builder = new PublicUrlBuilder("api.huobi.pro");

            string result = builder.Build("/common/symbols");

            Assert.Equal("https://api.huobi.pro/common/symbols", result);
        }

        [Fact]
        public void Build_RequestParameter_Success()
        {
            var builder = new PublicUrlBuilder("api.huobi.pro");
            var reqParams = new RequestParammeters()
                .AddParam("symbol", "btcusdt")
                .AddParam("period", "1min")
                .AddParam("size", "1");

            string result = builder.Build("/market/history/kline", reqParams);

            Assert.Equal("https://api.huobi.pro/market/history/kline?period=1min&size=1&symbol=btcusdt", result);
        }
    }
}
