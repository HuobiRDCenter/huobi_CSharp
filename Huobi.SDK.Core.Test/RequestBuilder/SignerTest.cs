using Huobi.SDK.Core.RequestBuilder;
using Xunit;

namespace Huobi.SDK.Core.Test.RequestBuilder
{
    public class SignatureTest
    {
        [Fact]
        public void Sign_FourString_Success()
        {
            var signer = new Signer("secret");

            string result = signer.Sign("GET", "api.huobi.pro", "/v1/account/history", "account-id=1&currency=btcusdt");

            Assert.Equal("HUP3n78npIuTzVKyjEOrPictRKEUTRoYs7Ld5y38hmA=", result);
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
