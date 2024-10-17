using System;
namespace Huobi.SDK.Example
{
    public class Timestamp
    {
        public static string SToLocal(long ts)
        {
            return SToDateTime(ts).ToLocalTime().ToString("s");
        }

        public static string MSToLocal(string ts)
        {
            return MSToLocal(long.Parse(ts));
        }

        public static string MSToLocal(long ts)
        {
            return MSToDateTime(ts).ToLocalTime().ToString("s");
        }

        private static DateTime MSToDateTime(long ts)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(ts);
        }

        private static DateTime SToDateTime(long ts)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(ts);
        }
    }
}
