using CSharpExcelChangeHandler.Base;
using CSharpExcelChangeHandler.ChangeHandling.Factory;
using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.ChangeHandling.Highlighter;
using CSharpExcelChangeHandler.ChangeHandling.Processor;
using CSharpExcelChangeHandler.Excel;
using CSharpExcelChangeHandler.Excel.Cached;
using CSharpExcelChangeHandler.Logging;

namespace CSharpExcelChangeHandler.Api
{
    public class ChangeHandlerApi : IChangeHandlerApi
    {
        private const int DEFAULT_HIGHLIGHT_COLOUR = 65535;

        public static IChangeHandlerApi NewInstance()
        {
            return new ChangeHandlerApi();
        }

        public IConfiguration Configuration { get; } = new Configuration();

        private readonly ILoggingManager _loggingManager = new LoggingManager();

        private IChangeProcessor ChangeProcessor { get; }

        public IChangeHandlerFactory ChangeHandlerFactory { get; }

        private bool ChangeHandlingEnabled => Configuration.ChangeHandlingEnabled;

        private ChangeHandlerApi()
        {
            ChangeProcessor = new ActiveChangeProcessor(_loggingManager);
            ChangeHandlerFactory = new SimpleChangeHandlerFactory(_loggingManager);
        }

        public void SetApplicationLogger(ILogger? logger)
        {
            _loggingManager.SetLogger(logger);
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
