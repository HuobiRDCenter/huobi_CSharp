using Huobi.SDK.Core.RequestBuilder;
using Xunit;

namespace Huobi.SDK.Core.Test.RequestBuilder
{
    public class SignatureTest
    {
        [Fact]
        public void Sign_FourString_Success()
        {
            var signer = new Signer("12345-67890-12345-67890");

            string result = signer.Sign(
                "GET",
                "api.huobi.pro",
                "/v1/account/accounts",
                "AccessKeyId=abcdefg-hijklmn-opqrst-uvwxyz&SignatureMethod=HmacSHA256&SignatureVersion=2&Timestamp=2020-04-01T12%3A34%3A56");

            Assert.Equal("3IUZcEak4IIRrh7/idFrP2Jj77MaWGXR/oQbe9gL4+I=", result);
        }

        [Fact]
        public void Sign_RunTwice_ReturnSameResult()
        {
            var signer = new Signer("secret");

            string result1 = signer.Sign("GET", "api.huobi.pro", "/v1/account/history", "account-id=1&currency=btcusdt");
            string result2 = signer.Sign("GET", "api.huobi.pro", "/v1/account/history", "account-id=1&currency=btcusdt");

            Assert.Equal(result1, result2);
        }

        [Fact]
        public void Sign_OneNullStringThreeString_ReturnEmpty()
        {
            var signer = new Signer("secret");

            string result = signer.Sign("GET", "api.huob.pro", "", "account-id=1&currency=btcusdt");

            Assert.Equal("", result);
        }
    }
}
