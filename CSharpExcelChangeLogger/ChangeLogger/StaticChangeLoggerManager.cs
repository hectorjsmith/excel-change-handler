using CSharpExcelChangeLogger.Api;
using CSharpExcelChangeLogger.ChangeLogger.Base;
using CSharpExcelChangeLogger.ChangeLogger.Highlighter;
using CSharpExcelChangeLogger.Excel;
using CSharpExcelChangeLogger.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger
{
    internal static class StaticChangeLoggerManager
    {
        private static readonly IChangeHandler _changeHandler = new ActiveChangeHandler();

        private static readonly ILogger _inactiveLogger = new InactiveLogger();
        private static ILogger? _injectedLogger;

        public static ILogger Log
        {
            get { return _injectedLogger ?? _inactiveLogger; }
        }

        public static IConfiguration Configuration { get; } = new Configuration();

        public static void SetInjectedLogger(ILogger? logger)
        {
            _injectedLogger = logger;
        }

        public static void AfterChange(IWorksheet sheet, IRange range)
        {
            _changeHandler.AfterChange(sheet, range);
        }
    }
}
