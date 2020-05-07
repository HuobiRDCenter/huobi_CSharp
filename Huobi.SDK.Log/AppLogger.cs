using System;
using NLog;

namespace Huobi.SDK.Log
{
    public class AppLogger
    {
        private static readonly ILogger _nLogger = LogManager.GetLogger("appLogger");

        public static void Trace(string message)
        {
            _nLogger.Trace(message);
        }

        public static void Debug(string message)
        {
            _nLogger.Debug(message);
        }

        public static void Info(string message)
        {
            _nLogger.Info(message);
        }

        public static void Warn(string message)
        {
            _nLogger.Warn(message);
        }

        public static void Error(string message, Exception exception = null)
        {
            if (exception == null)
            {
                _nLogger.Error(message);
            }
            else
            {
                _nLogger.Error(exception, message);
            }
        }

        public static void Fatal(string message, Exception exception = null)
        {
            if (exception == null)
            {
                _nLogger.Fatal(message);
            }
            else
            {
                _nLogger.Fatal(exception, message);
            }
        }
    }
}
