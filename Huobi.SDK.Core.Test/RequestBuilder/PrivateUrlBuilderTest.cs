using System;
using Huobi.SDK.Core.RequestBuilder;
using Xunit;

namespace Huobi.SDK.Core.Test.RequestBuilder
{
    public class PrivateUrlBuilderTest
    {
        [Fact]
        public void Build_NoRequestParameter_Success()
        {
            var builder = new PrivateUrlBuilder("access", "secret", "api.huobi.pro");
            DateTime dateTime = new DateTime(2019, 11, 21, 10, 0, 0);


            string result = builder.Build("GET", "/v1/account/accounts", dateTime);


            string escapedTime = Uri.EscapeDataString(dateTime.ToString("s"));
            string expected = string.Format(@"https://api.huobi.pro/v1/account/accounts?AccessKeyId=access&SignatureMethod=HmacSHA256&SignatureVersion=2&Timestamp={0}&Signature=rWnLcMt3XBAsmXoNHtTQVpvMbH%2FcE1PXFwQAGeYwt3s%3D",
                escapedTime);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Build_RequestParameter_Success()
        {
            var builder = new PrivateUrlBuilder("access", "secret", "api.huobi.pro");
            DateTime dateTime = new DateTime(2019, 11, 21, 10, 0, 0);
            var request = new GetRequest()
                .AddParam("account-id", "123")
                .AddParam("currency", "btc");


            string result = builder.Build("GET", "/v1/account/history", dateTime, request);


            string escapedTime = Uri.EscapeDataString(dateTime.ToString("s"));
            string expected = string.Format(@"https://api.huobi.pro/v1/account/history?AccessKeyId=access&SignatureMethod=HmacSHA256&SignatureVersion=2&Timestamp={0}&account-id=123&currency=btc&Signature=SGZYJ9Ub%2FhFerEBbSWsCxl8Djk%2BLRBgEZOB4fLc4T9Q%3D",
                escapedTime);
            Assert.Equal(expected, result);
        }
    }
}
