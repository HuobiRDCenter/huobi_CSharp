namespace HuobiSDK.Model.Request.Margin
{
    public class GetRepaymentRequest
    {
        public string repayId;

        public string accountId;

        public string currency;

        public long startTime;

        public long endTime;

        public string sort;

        public int limit;

        public long fromId;
    }
}
