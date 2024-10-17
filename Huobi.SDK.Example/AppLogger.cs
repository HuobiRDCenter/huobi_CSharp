using System;
using Huobi.SDK.Core.Log;

namespace Huobi.SDK.Example
{
    public class AppLogger
    {
        private static readonly ILogger _logger = new ConsoleLogger();

        public static void Trace(string message)
        {
            _logger.Log(LogLevel.Trace, message);
        }

        public static void Debug(string message)
        {
            _logger.Log(LogLevel.Debug, message);
        }

        public static void Info(string message)
        {
            _logger.Log(LogLevel.Info, message);
        }

        public static void Warn(string message)
        {
            _logger.Log(LogLevel.Warn, message);
        }

        public static void Error(string message, Exception exception = null)
        {
            if (exception == null)
            {
                _logger.Log(LogLevel.Error, message);
            }
            else
            {
                _logger.Log(LogLevel.Error, message + exception.StackTrace);
            }
        }

        public static void Fatal(string message, Exception exception = null)
        {
            if (exception == null)
            {
                _logger.Log(LogLevel.Fatal, message);
            }
            else
            {
                _logger.Log(LogLevel.Fatal, message + exception.StackTrace);
            }
        }
    }
}
