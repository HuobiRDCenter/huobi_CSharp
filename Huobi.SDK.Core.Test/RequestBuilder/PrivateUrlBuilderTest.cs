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
            var builder = new PrivateUrlBuilder("abcdefg-hijklmn-opqrst-uvwxyz", "12345-67890-12345-67890", "api.huobi.pro");
            DateTime dateTime = new DateTime(2020, 04, 01, 12, 34, 56);

            string result = builder.Build("GET", "/v1/account/accounts", dateTime);

            string expected = @"https://api.huobi.pro/v1/account/accounts?AccessKeyId=abcdefg-hijklmn-opqrst-uvwxyz&SignatureMethod=HmacSHA256&SignatureVersion=2&Timestamp=2020-04-01T12%3A34%3A56&Signature=3IUZcEak4IIRrh7%2FidFrP2Jj77MaWGXR%2FoQbe9gL4%2BI%3D";
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
