using CSharpExcelChangeLogger.Base;
using CSharpExcelChangeLogger.ChangeLogger;
using CSharpExcelChangeLogger.ChangeLogger.Handler;
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

        private readonly IChangeHandler _changeHandler = new ActiveChangeHandler();
        
        public IConfiguration Configuration { get; } = new Configuration();
        private bool ChangeHandlingEnabled => Configuration.HighlighterEnabled;

        private ChangeLoggerApi()
        {
        }

        public void SetLogger(ILogger? logger)
        {
            StaticLogManager.SetLogger(logger);
        }

        public void SetCustomHighlighter(IChangeHighlighter? highlighter)
        {
            _changeHandler.SetHighlighter(highlighter);
        }

        public void BeforeChange(IWorksheet sheet, IRange range)
        {
            if (ChangeHandlingEnabled)
            {
                _changeHandler.BeforeChange(sheet, range);
            }
        }

        public void AfterChange(IWorksheet sheet, IRange range)
        {
            if (ChangeHandlingEnabled)
            {
                _changeHandler.AfterChange(sheet, range);
            }
        }

        public IChangeHighlighter NewSimpleChangeHighlighter(int highlightColour)
        {
            return new SimpleChangeHighlighter(highlightColour);
        }
    }
}
