using System;
using System.Diagnostics;
using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using NLog.Targets;

namespace Huobi.SDK.Core
{
    public class PerformanceLogger
    {
        private Stopwatch _stopwatch;
        private static ILogger _logger;
        private static int _index;

        public PerformanceLogger()
        {            
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
            _logger = LogManager.GetCurrentClassLogger();
            _logger.Info($"Index, Duration(ms), Response Type, URL");

        }

        public void Start()
        {
            _stopwatch.Restart();
        }

        public void StopAndLog<T>(string method, string url, bool stripUrlParams = true)
        {
            _stopwatch.Stop();

            if (stripUrlParams)
            {
                int i = url.IndexOf('?');
                url = i > 0 ? url.Substring(0, i) : url;
            }
            _logger.Info($"{_index}, {_stopwatch.ElapsedMilliseconds}, {typeof(T).Name}, {method} {url}");
            _index++;
        }
    }
}
