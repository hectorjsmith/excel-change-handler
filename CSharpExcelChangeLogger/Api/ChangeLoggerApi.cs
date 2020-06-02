using CSharpExcelChangeLogger.Base;
using CSharpExcelChangeLogger.ChangeLogger.Factory;
using CSharpExcelChangeLogger.ChangeLogger.Handler;
using CSharpExcelChangeLogger.ChangeLogger.Highlighter;
using CSharpExcelChangeLogger.ChangeLogger.Processor;
using CSharpExcelChangeLogger.Excel;
using CSharpExcelChangeLogger.Excel.Cached;
using CSharpExcelChangeLogger.Logging;

namespace CSharpExcelChangeLogger.Api
{
    public class ChangeLoggerApi : IChangeLoggerApi
    {
        private const int DEFAULT_HIGHLIGHT_COLOUR = 65535;

        private static IChangeLoggerApi? _instance;
        public static IChangeLoggerApi Instance = _instance ?? (_instance = new ChangeLoggerApi());

        private IChangeProcessor ChangeProcessor { get; } = new ActiveChangeProcessor();

        public IConfiguration Configuration { get; } = new Configuration();
        private bool ChangeHandlingEnabled => Configuration.ChangeHandlingEnabled;

        public IChangeHandlerFactory ChangeHandlerFactory { get; } = new SimpleChangeHandlerFactory();


        private ChangeLoggerApi()
        {
        }

        public void SetApplicationLogger(ILogger? logger)
        {
            StaticLoggingManager.SetLogger(logger);
        }

        public void ClearAllHandlers()
        {
            ChangeProcessor.ClearAllHandlers();
        }

        public void AddDefaultHandlers()
        {
            AddCustomHandler(ChangeHandlerFactory.NewSimpleChangeHighlighter(DEFAULT_HIGHLIGHT_COLOUR));
        }

        public void AddCustomHandler(IChangeHandler handler)
        {
            ChangeProcessor.AddHandler(handler);
        }

        public void BeforeChange(IWorksheet sheet, IRange range)
        {
            if (ChangeHandlingEnabled)
            {
                ChangeProcessor.BeforeChange(sheet, range);
            }
        }

        public void AfterChange(IWorksheet sheet, IRange range)
        {
            if (ChangeHandlingEnabled)
            {
                ChangeProcessor.AfterChange(sheet, range);
            }
        }
    }
}
