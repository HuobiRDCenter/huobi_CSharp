using System;
using Huobi.SDK.Core.Model;
using Huobi.SDK.Core.RequestBuilder;
using Newtonsoft.Json;
using Xunit;

namespace Huobi.SDK.Core.Test.RequestBuilder
{
    public class WebSocketRequestBuilderTest
    {
        [Fact]
        public void Build_NullParam_Success()
        {
            var builder = new WebSocketV1RequestBuilder("access", "secret", "api.huobi.pro","256" ,"/ws/v1");

            string auth = builder.Build();

            var authReq = JsonConvert.DeserializeObject<WebSocketAuthenticationRequest>(auth);

            Assert.Equal("auth", authReq.op);
            Assert.Equal("access", authReq.AccessKeyId);
            Assert.Equal("HmacSHA256", authReq.SignatureMethod);
            Assert.Equal("2", authReq.SignatureVersion);
        }

        [Fact]
        public void Build_Time_Success()
        {
            var builder = new WebSocketV1RequestBuilder("access", "secret", "api.huobi.pro", "256","/ws/v1");

            var utcTime = new DateTime(2019, 11, 21, 10, 0, 0);
            string auth = builder.Build(utcTime);

            var authReq = JsonConvert.DeserializeObject<WebSocketAuthenticationRequest>(auth);

            Assert.Equal("auth", authReq.op);
            Assert.Equal("access", authReq.AccessKeyId);
            Assert.Equal("HmacSHA256", authReq.SignatureMethod);
            Assert.Equal("2", authReq.SignatureVersion);
            Assert.Equal(utcTime.ToString("s"), authReq.Timestamp);
            Assert.Equal("nWj8xkaQ8mWPyvdtRVPFkrX2B8v3mSomAfhXiOGoS3M=", authReq.Signature);
        }
    }
}