using CSharpExcelChangeLogger.Api;
using CSharpExcelChangeLogger.ChangeLogger.Handler;
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

        private static readonly IChangeHighlighter _defaultHighlighter = new ActiveChangeHighlighter();
        private static IChangeHighlighter? _injectedHighlighter;

        public static ILogger Log => _injectedLogger ?? _inactiveLogger;
        public static IChangeHighlighter ChangeHighlighter => _injectedHighlighter ?? _defaultHighlighter;

        public static IConfiguration Configuration { get; } = new Configuration();

        public static void SetInjectedLogger(ILogger? logger)
        {
            _injectedLogger = logger;
        }

        public static void SetInjectedHighlighter(IChangeHighlighter? highlighter)
        {
            _injectedHighlighter = highlighter;
        }

        public static void BeforeChange(IWorksheet sheet, IRange range)
        {
            _changeHandler.BeforeChange(sheet, range);
        }

        public static void AfterChange(IWorksheet sheet, IRange range)
        {
            _changeHandler.AfterChange(sheet, range);
        }
    }
}
