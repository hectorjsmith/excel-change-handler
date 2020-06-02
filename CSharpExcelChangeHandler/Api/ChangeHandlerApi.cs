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

        private static IChangeHandlerApi? _instance;
        public static IChangeHandlerApi Instance = _instance ?? (_instance = new ChangeHandlerApi());

        private IChangeProcessor ChangeProcessor { get; } = new ActiveChangeProcessor();

        public IConfiguration Configuration { get; } = new Configuration();
        private bool ChangeHandlingEnabled => Configuration.ChangeHandlingEnabled;

        public IChangeHandlerFactory ChangeHandlerFactory { get; } = new SimpleChangeHandlerFactory();


        private ChangeHandlerApi()
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
