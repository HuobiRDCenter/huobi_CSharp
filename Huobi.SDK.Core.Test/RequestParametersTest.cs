using System;
using Xunit;

namespace Huobi.SDK.Core.Test
{
    public class RequestParametersTest
    {
        [Fact]
        public void Constructor_NoParam_Success()
        {
            var request = new GetRequest();

            Assert.True(true);
        }

        [Fact]
        public void Constructor_NullParam_Success()
        {
            var request = new GetRequest(null);

            Assert.True(true);
        }

        [Fact]
        public void Constructor_WithParam_Success()
        {
            var request1 = new GetRequest();
            var request2 = new GetRequest(request1);

            Assert.True(true);
        }

        [Fact]
        public void AddParam_TwoNullParam_Success()
        {
            var request = new GetRequest();

            var newParams = request.AddParam(null, null);

            Assert.Equal(request, newParams);
        }

        [Fact]
        public void AddParam_FirstNullParam_Success()
        {
            var request = new GetRequest();

            var newParams = request.AddParam(null, "value");

            Assert.Equal(request, newParams);
        }

        [Fact]
        public void AddParam_SecondNullParam_Success()
        {
            var request = new GetRequest();

            var newParams = request.AddParam("key", null);

            Assert.Equal(request, newParams);
        }


        [Fact]
        public void BuildParams_NullParam_ReturnEmpty()
        {
            var request = new GetRequest();

            string result = request.BuildParams();

            Assert.Equal("", result);
        }


        [Fact]
        public void BuildParams_ClonedParam_ReturnClonedPair()
        {
            var request1 = new GetRequest().AddParam("key1", "value1");
            var request2 = new GetRequest(request1);

            string result = request2.BuildParams();

            Assert.Equal("key1=value1", result);
        }

        [Fact]
        public void BuildParams_ConcatedParam_ReturnConcatedPair()
        {
            var request1 = new GetRequest().AddParam("key1", "value1");
            var request2 = new GetRequest(request1).AddParam("key2", "value2");

            string result = request2.BuildParams();

            Assert.Equal("key1=value1&key2=value2", result);
        }

        [Fact]
        public void BuildParams_OneParam_ReturnOnePair()
        {
            var request = new GetRequest();

            string result = request
                .AddParam("key", "value")
                .BuildParams();

            Assert.Equal("key=value", result);
        }

        [Fact]
        public void BuildParams_UnEscapedParam_ReturnEscapedParam()
        {
            var request = new GetRequest();

            string result = request
                .AddParam("key", "valueA:valueB/valueC=")
                .BuildParams();

            Assert.Equal("key=valueA%3AvalueB%2FvalueC%3D", result);
        }

        [Fact]
        public void BuildParams_TwoParam_ReturnOrderedTwoPairs()
        {
            var request = new GetRequest();

            string result = request
                .AddParam("id", "123")
                .AddParam("Year", "2019")
                .BuildParams();

            Assert.Equal("Year=2019&id=123", result);
        }

        [Fact]
        public void BuildParams_ThreeParam_ReturnOrderedThreePairs()
        {
            var request = new GetRequest()
                .AddParam("AccessKey", "value1")
                .AddParam("SignatureMethod", "value2")
                .AddParam("account-id", "value3");

            string result = request.BuildParams();

            Assert.Equal("AccessKey=value1&SignatureMethod=value2&account-id=value3", result);
        }
    }
}
