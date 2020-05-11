using CSharpExcelChangeLogger.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Base
{
    internal static class StaticChangeLoggerManager
    {
        private static readonly ILogger _inactiveLogger = new InactiveLogger();
        private static ILogger? _injectedLogger;

        public static ILogger Logger
        {
            get { return _injectedLogger ?? _inactiveLogger; }
        }

        public static void SetInjectedLogger(ILogger? logger)
        {
            _injectedLogger = logger;
        }

    }
}
