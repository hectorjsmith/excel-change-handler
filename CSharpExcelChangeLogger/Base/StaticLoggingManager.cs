using CSharpExcelChangeLogger.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Base
{
    internal static class StaticLoggingManager
    {
        private static readonly ILogger _inactiveLogger = new InactiveLogger();
        private static ILogger? _injectedLogger;

        public static ILogger Log => _injectedLogger ?? _inactiveLogger;

        public static void SetLogger(ILogger? logger)
        {
            _injectedLogger = logger;
        }
    }
}
