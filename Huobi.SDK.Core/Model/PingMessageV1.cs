namespace Huobi.SDK.Core.Model
{
    public class PingMessageV1
    {
        public string op;

        public long ts;

        public bool IsPing()
        {
            return this != null && ts != 0 && op.Equals("ping");
        }
    }
}
