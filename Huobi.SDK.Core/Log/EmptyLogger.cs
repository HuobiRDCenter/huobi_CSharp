using System;
namespace Huobi.SDK.Core.Log
{
    public class EmptyLogger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
            return;
        }
    }
}
