using System;
using System.Diagnostics;
using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using NLog.Targets;

namespace Huobi.SDK.Log
{
    public class PerformanceLogger
    {
        private static PerformanceLogger _pLogger;

        private bool _enable;
        private Stopwatch _stopwatch;
        private ILogger _nLogger;
        private int _index;

        private PerformanceLogger()
        {
            _enable = false;

            _stopwatch = new Stopwatch();

            var config = new LoggingConfiguration();
            var logfile = new FileTarget("logfile")
            {
                FileName = $"sdk-perf-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}.txt",
                Layout = "${message}"
            };

            config.AddRule(LogLevel.Info, LogLevel.Info, logfile);

            LogManager.Configuration = config;

            _index = 1;
            _nLogger = LogManager.GetCurrentClassLogger();
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
        public void Start()
        {
            if (_enable)
            {                
                _stopwatch.Restart();
            }

        }

        /// <summary>
        /// Stop timer and output log
        /// </summary>
        /// <typeparam name="T">response type</typeparam>
        /// <param name="method">http method</param>
        /// <param name="url">URL</param>
        /// <param name="stripUrlParams">Whether strip the parameters from url</param>
        public void StopAndLog<T>(string method, string url, bool stripUrlParams = true)
        {
            if (_enable)
            {
                _stopwatch.Stop();

                // Strip paramaters
                if (stripUrlParams)
                {
                    int i = url.IndexOf('?');
                    url = i > 0 ? url.Substring(0, i) : url;
                }

                // Log header if it is the first record
                if (_index == 1)
                {
                    _nLogger.Info($"Index, Duration(ms), Response Type, URL");
                }

                _nLogger.Info($"{_index}, {_stopwatch.ElapsedMilliseconds}, {typeof(T).Name}, {method} {url}");

                _index++;
            }
        }
    }
}
