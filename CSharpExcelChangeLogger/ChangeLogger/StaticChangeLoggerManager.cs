using CSharpExcelChangeLogger.Api;
using CSharpExcelChangeLogger.Excel;
using CSharpExcelChangeLogger.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger
{
    internal static class StaticChangeLoggerManager
    {
        private static readonly ILogger _inactiveLogger = new InactiveLogger();
        private static ILogger? _injectedLogger;

        public static ILogger Logger
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
            Logger.Info(string.Format("Highlighting range '{0}' on sheet '{1}'", range.Address, sheet.Name));
            range.FillRange(Configuration.CellHighlightRgbColour);
        }
    }
}
