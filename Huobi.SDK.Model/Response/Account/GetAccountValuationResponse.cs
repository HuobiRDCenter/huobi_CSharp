using Huobi.SDK.Model.Response.Account;
using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Account
{
    public class GetAccountValuationResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public AccountValuation Data;

        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public bool Success;
        
        public class AccountValuation
        {
            [JsonProperty("totalBalance", NullValueHandling = NullValueHandling.Ignore)]
            public string TotalBalance;

            [JsonProperty("todayProfit", NullValueHandling = NullValueHandling.Ignore)]
            public string TodayProfit;

            [JsonProperty("todayProfitRate", NullValueHandling = NullValueHandling.Ignore)]
            public string TodayProfitRate;

            [JsonProperty("<profitAccountBalanceList>", NullValueHandling = NullValueHandling.Ignore)]
            public ProfitAccountBalanceObject[] ProfitAccountBalanceList;

            [JsonProperty("<updated>", NullValueHandling = NullValueHandling.Ignore)]
            public UpdatedObject[] Updated;
        }

        public class ProfitAccountBalanceObject
        {
            [JsonProperty("distributionType", NullValueHandling = NullValueHandling.Ignore)]
            public string DistributionType;

            [JsonProperty("balance", NullValueHandling = NullValueHandling.Ignore)]
            public float Balance;

            [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
            public bool Success;

            [JsonProperty("accountBalance", NullValueHandling = NullValueHandling.Ignore)]
            public string AccountBalance;
        }
        
        public class UpdatedObject
        {
            [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
            public bool Success;

            [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
            public long Time;
        }
    }
}