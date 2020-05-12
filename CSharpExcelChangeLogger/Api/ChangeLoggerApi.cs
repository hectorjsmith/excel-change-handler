using CSharpExcelChangeLogger.ChangeLogger;
using CSharpExcelChangeLogger.ChangeLogger.Highlighter;
using CSharpExcelChangeLogger.Excel;
using CSharpExcelChangeLogger.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Api
{
    public class ChangeLoggerApi : IChangeLoggerApi
    {
        private static IChangeLoggerApi? _instance;
        public static IChangeLoggerApi Instance = _instance ?? (_instance = new ChangeLoggerApi());

        public IConfiguration Configuration => StaticChangeLoggerManager.Configuration;

        private ChangeLoggerApi()
        {
        }

        public void SetLogger(ILogger? logger)
        {
            StaticChangeLoggerManager.SetInjectedLogger(logger);
        }

        public void SetCustomHighlighter(IChangeHighlighter? highlighter)
        {
            StaticChangeLoggerManager.SetInjectedHighlighter(highlighter);
        }

        public void BeforeChange(IWorksheet sheet, IRange range)
        {
            StaticChangeLoggerManager.BeforeChange(sheet, range);
        }

        public void AfterChange(IWorksheet sheet, IRange range)
        {
            StaticChangeLoggerManager.AfterChange(sheet, range);
        }
    }
}
