using CSharpExcelChangeHandler.Api.Config;
using CSharpExcelChangeHandler.Base;
using CSharpExcelChangeHandler.ChangeHandling.Factory;
using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.ChangeHandling.Processor;
using CSharpExcelChangeHandler.Excel;
using CSharpExcelChangeHandler.Excel.Cached;
using CSharpExcelChangeHandler.Logging;

namespace CSharpExcelChangeHandler.Api
{
    public class GenericChangeHandlerApi<TWorksheetType, TRangeType> : IGenericChangeHandlerApi<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        private const int DEFAULT_HIGHLIGHT_COLOUR = 65535;

        public IConfiguration Configuration { get; } = new Configuration();

        private readonly ILoggingManager _loggingManager = new LoggingManager();

        private IChangeProcessor<TWorksheetType, TRangeType> ChangeProcessor { get; }

        public IChangeHandlerFactory<TWorksheetType, TRangeType> ChangeHandlerFactory { get; }

        private bool ChangeHandlingEnabled => Configuration.ChangeHandlingEnabled;

        internal GenericChangeHandlerApi()
        {
            ChangeProcessor = new ActiveChangeProcessor<TWorksheetType, TRangeType>(_loggingManager);
            ChangeHandlerFactory = new SimpleChangeHandlerFactory<TWorksheetType, TRangeType>(_loggingManager);
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

        public void AddCustomHandler(IChangeHandler<TWorksheetType, TRangeType> handler)
        {
            ChangeProcessor.AddHandler(handler);
        }

        public void BeforeChange(TWorksheetType sheet, TRangeType range)
        {
            if (ChangeHandlingEnabled)
            {
                ChangeProcessor.BeforeChange(sheet, range);
            }
        }

        public void AfterChange(TWorksheetType sheet, TRangeType range)
        {
            if (ChangeHandlingEnabled)
            {
                ChangeProcessor.AfterChange(sheet, range);
            }
        }
    }
}
