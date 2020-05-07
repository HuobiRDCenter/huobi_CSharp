using System;
using System.Diagnostics;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Huobi.SDK.Log
{
    /// <summary>
    /// Responsible to measure SDK performance
    /// </summary>
    public class PerformanceLogger
    {
        struct LogContent
        {
            public int Id;
            public string Endpoint;
            public string Url;
            public long TotalDuration;
            public long NetworkDuration;
            public long SDKDuration;
        }

        private static PerformanceLogger _pLogger;

        private bool _enable;
        private Stopwatch _stopwatch;
        private ILogger _nLogger;
        private int _logContentLineCount;

        private long _requestStart;
        private long _requestEnd;

        private LogContent _logContent;

        private PerformanceLogger()
        {
            // Logger switch
            _enable = false;

            // Stopwatch
            _stopwatch = new Stopwatch();

            // Performance logger
            _nLogger = LogManager.GetLogger("perfLogger");

            // Log content line count
            _logContentLineCount = 1;
        }

        /// <summary>
        /// Provide single instance
        /// </summary>
        /// <returns></returns>
        public static PerformanceLogger GetInstance()
        {
            if (_pLogger == null)
            {
                _pLogger = new PerformanceLogger();
            }

            return _pLogger;
        }

        /// <summary>
        /// Set enable or disable the performance log
        /// </summary>
        /// <param name="enable"></param>
        public void Enable(bool enable)
        {
            _enable = enable;
        }

        /// <summary>
        /// Start timer
        /// </summary>
        public void Start([System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
        {
            if (_enable)
            {
                _stopwatch.Restart();
                _logContent.Id = _logContentLineCount;
                _logContent.Endpoint = methodName;

            }
        }

        public void RquestStart(string method, string url, bool stripUrlParams = true)
        {
            if (_enable)
            {
                _stopwatch.Stop();
                _requestStart = _stopwatch.ElapsedMilliseconds;
                _stopwatch.Start();

                // Strip paramaters
                if (stripUrlParams)
                {
                    int i = url.IndexOf('?');
                    url = i > 0 ? url.Substring(0, i) : url;
                }

                _logContent.Url = $"{method} {url}";
            }
        }

        public void RequestEnd()
        {
            if (_enable)
            {
                _stopwatch.Stop();
                _requestEnd = _stopwatch.ElapsedMilliseconds;
                _stopwatch.Start();
            }
        }

        public void StopAndLog()
        {
            if (_enable)
            {
                _stopwatch.Stop();
                long totalDuration = _stopwatch.ElapsedMilliseconds;
                long requestDuration = _requestEnd - _requestStart;


                // Log header if it is the first record
                if (_logContentLineCount == 1)
                {
                    _nLogger.Trace($"Index|Endpoint|URL|Total Duration(ms)|Request Duration(ms)|SDK Duration(ms)");
                }

                _nLogger.Trace($"{_logContent.Id}|{_logContent.Endpoint}|{_logContent.Url}|{totalDuration}|{requestDuration}|{totalDuration - requestDuration}");

                _logContentLineCount++;
            }
        }
    }
}
