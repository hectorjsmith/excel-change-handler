using CSharpExcelChangeLogger.Base;
using CSharpExcelChangeLogger.ChangeLogger;
using CSharpExcelChangeLogger.ChangeLogger.Processor;
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
        private const int DEFAULT_HIGHLIGHT_COLOUR = 65535;

        private static IChangeLoggerApi? _instance;
        public static IChangeLoggerApi Instance = _instance ?? (_instance = new ChangeLoggerApi());

        private readonly IChangeProcessor _changeProcessor = new ActiveChangeProcessor();
        
        public IConfiguration Configuration { get; } = new Configuration();
        private bool ChangeHandlingEnabled => Configuration.ChangeHandlingEnabled;

        private ChangeLoggerApi()
        {
        }

        public void SetLogger(ILogger? logger)
        {
            StaticLogManager.SetLogger(logger);
        }

        public void ClearAllHandlers()
        {
            _changeProcessor.ClearAllHandlers();
        }

        public void AddDefaultHandlers()
        {
            AddCustomHandler(NewSimpleChangeHighlighter(DEFAULT_HIGHLIGHT_COLOUR));
        }

        public void AddCustomHandler(IChangeHandler handler)
        {
            _changeProcessor.AddHandler(handler);
        }

        public void BeforeChange(IWorksheet sheet, IRange range)
        {
            if (ChangeHandlingEnabled)
            {
                _changeProcessor.BeforeChange(sheet, range);
            }
        }

        public void AfterChange(IWorksheet sheet, IRange range)
        {
            if (ChangeHandlingEnabled)
            {
                _changeProcessor.AfterChange(sheet, range);
            }
        }

        public IChangeHandler NewSimpleChangeHighlighter(int highlightColour)
        {
            return new SimpleChangeHighlighter(highlightColour);
        }
    }
}
