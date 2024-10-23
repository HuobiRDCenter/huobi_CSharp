using Huobi.SDK.Core.RequestBuilder;
using Xunit;

namespace Huobi.SDK.Core.Test.RequestBuilder
{
    public class Ed25519SignerTest
    {
        private const string PrivateKey = "MC4CAQAwBQYDK2VwBCIEILHeu7fAq16wUfz/w91bQVEQO+J1dJ6HE4YGdyfYMPqt"; // 替换为有效的私钥

        [Fact]
        public void Sign_FourString_Success()
        {
            var signer = new Ed25519Signer(PrivateKey);
            string result = signer.Sign(
                "GET",
                "https://api.huobi.pro/v1/account/accounts?AccessKeyId=abcdefg-hijklmn-opqrst-uvwxyz&SignatureMethod=ED25519&SignatureVersion=2&Timestamp=2020-04-01T12%3A34%3A56"
            );

            Assert.Equal("expected_base64_encoded_signature", result); // 替换为您预期的签名
        }

        [Fact]
        public void Sign_RunTwice_ReturnSameResult()
        {
            var signer = new Ed25519Signer(PrivateKey);

            string result1 = signer.Sign("GET", "https://api.huobi.pro/v1/account/history?account-id=1&currency=btcusdt");
            string result2 = signer.Sign("GET", "https://api.huobi.pro/v1/account/history?account-id=1&currency=btcusdt");

            Assert.Equal(result1, result2);
        }

        [Fact]
        public void Sign_OneNullStringThreeString_ReturnEmpty()
        {
            var signer = new Ed25519Signer(PrivateKey);

            string result = signer.Sign("GET", "https://api.huobi.pro", "", "account-id=currency=btcusdt");

            Assert.Equal("", result);
        }
    }
}