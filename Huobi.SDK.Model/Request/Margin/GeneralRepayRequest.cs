namespace Huobi.SDK.Model.Request.Margin
{
    public class GeneralRepayRequest : PostRequestBase
    {
        public string accountId;

        public string currency;

        public string amount;

        public string transactId;
    }
}
