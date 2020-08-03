namespace Huobi.SDK.Core.Log
{
    public interface ILogger
    {
        void Log(LogLevel level, string message);
    }

    public enum LogLevel
    {
        Fatal,
        Error,
        Warn,
        Info,
        Debug,
        Trace
    }
}
