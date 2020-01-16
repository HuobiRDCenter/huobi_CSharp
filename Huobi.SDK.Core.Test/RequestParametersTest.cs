using System;
using Xunit;

namespace Huobi.SDK.Core.Test
{
    public class RequestParametersTest
    {
        [Fact]
        public void Constructor_NoParam_Success()
        {
            var parameters = new RequestParammeters();

            Assert.True(true);
        }

        [Fact]
        public void Constructor_NullParam_Success()
        {
            var parameters = new RequestParammeters(null);

            Assert.True(true);
        }

        [Fact]
        public void Constructor_WithParam_Success()
        {
            var parameters1 = new RequestParammeters();
            var parameters2 = new RequestParammeters(parameters1);

            Assert.True(true);
        }

        [Fact]
        public void AddParam_TwoNullParam_Success()
        {
            var parameters = new RequestParammeters();

            var newParams = parameters.AddParam(null, null);

            Assert.Equal(parameters, newParams);
        }

        [Fact]
        public void AddParam_FirstNullParam_Success()
        {
            var parameters = new RequestParammeters();

            var newParams = parameters.AddParam(null, "value");

            Assert.Equal(parameters, newParams);
        }

        [Fact]
        public void AddParam_SecondNullParam_Success()
        {
            var parameters = new RequestParammeters();

            var newParams = parameters.AddParam("key", null);

            Assert.Equal(parameters, newParams);
        }


        [Fact]
        public void BuildParams_NullParam_ReturnEmpty()
        {
            var parameters = new RequestParammeters();

            string result = parameters.BuildParams();

            Assert.Equal("", result);
        }


        [Fact]
        public void BuildParams_ClonedParam_ReturnClonedPair()
        {
            var params1 = new RequestParammeters().AddParam("key1", "value1");
            var params2 = new RequestParammeters(params1);

            string result = params2.BuildParams();

            Assert.Equal("key1=value1", result);
        }

        [Fact]
        public void BuildParams_ConcatedParam_ReturnConcatedPair()
        {
            var params1 = new RequestParammeters().AddParam("key1", "value1");
            var params2 = new RequestParammeters(params1).AddParam("key2", "value2");

            string result = params2.BuildParams();

            Assert.Equal("key1=value1&key2=value2", result);
        }

        [Fact]
        public void BuildParams_OneParam_ReturnOnePair()
        {
            var parameters = new RequestParammeters();

            string result = parameters
                .AddParam("key", "value")
                .BuildParams();

            Assert.Equal("key=value", result);
        }

        [Fact]
        public void BuildParams_UnEscapedParam_ReturnEscapedParam()
        {
            var parameters = new RequestParammeters();

            string result = parameters
                .AddParam("key", "valueA:valueB/valueC=")
                .BuildParams();

            Assert.Equal("key=valueA%3AvalueB%2FvalueC%3D", result);
        }

        [Fact]
        public void BuildParams_TwoParam_ReturnOrderedTwoPairs()
        {
            var parameters = new RequestParammeters();

            string result = parameters
                .AddParam("id", "123")
                .AddParam("Year", "2019")
                .BuildParams();

            Assert.Equal("Year=2019&id=123", result);
        }

        [Fact]
        public void BuildParams_ThreeParam_ReturnOrderedThreePairs()
        {
            var parameters = new RequestParammeters()
                .AddParam("AccessKey", "value1")
                .AddParam("SignatureMethod", "value2")
                .AddParam("account-id", "value3");

            string result = parameters.BuildParams();

            Assert.Equal("AccessKey=value1&SignatureMethod=value2&account-id=value3", result);
        }
    }
}
