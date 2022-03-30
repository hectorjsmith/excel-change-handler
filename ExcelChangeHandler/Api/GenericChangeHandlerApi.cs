using ExcelChangeHandler.Api.Config;
using ExcelChangeHandler.Base;
using ExcelChangeHandler.ChangeHandling.Factory;
using ExcelChangeHandler.ChangeHandling.Filter;
using ExcelChangeHandler.ChangeHandling.Handler;
using ExcelChangeHandler.ChangeHandling.Memory;
using ExcelChangeHandler.ChangeHandling.Processor;
using ExcelChangeHandler.Excel;
using ExcelChangeHandler.Excel.Cached;
using ExcelChangeHandler.Logging;
using System;

namespace ExcelChangeHandler.Api
{
    internal class GenericChangeHandlerApi<TWorksheetType, TRangeType> : IGenericChangeHandlerApi<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        private const int DEFAULT_HIGHLIGHT_COLOUR = 65535;

        private readonly ILoggingManager _loggingManager = new LoggingManager();

        private IChangeProcessor<TWorksheetType, TRangeType>? _changeProcessor;
        private IChangeProcessor<TWorksheetType, TRangeType> ChangeProcessor =>
            _changeProcessor ?? (_changeProcessor = NewActiveChangeProcessor());

        private IChangeHandlerFactory<TWorksheetType, TRangeType>? _changeHandlerFactory;
        public IChangeHandlerFactory<TWorksheetType, TRangeType> ChangeHandlerFactory =>
            _changeHandlerFactory ?? (_changeHandlerFactory = NewSimpleChangeHandlerFactory());

        public IConfiguration Configuration { get; } = new Configuration();

        private bool ChangeHandlingEnabled => Configuration.ChangeHandlingEnabled;

        internal GenericChangeHandlerApi()
        {
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

        public void AddCustomHandler(Action<IMemoryComparison, TWorksheetType, TRangeType> handler)
        {
            ChangeProcessor.AddHandler(new ActionBasedChangeHandler<TWorksheetType, TRangeType>(handler));
        }

        public void ClearAllFilters()
        {
            ChangeProcessor.ClearAllFilters();
        }

        public void AddChangeEventFilter(IChangeEventFilter<TWorksheetType, TRangeType> filter)
        {
            ChangeProcessor.AddFilter(filter);
        }

        public void AddChangeEventFilter(Func<IMemoryComparison, TWorksheetType, TRangeType, bool> filter)
        {
            ChangeProcessor.AddFilter(new FunctionBasedChangeEventFilter<TWorksheetType, TRangeType>(filter));
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

        private IChangeProcessor<TWorksheetType, TRangeType> NewActiveChangeProcessor()
        {
            return new ActiveChangeProcessor<TWorksheetType, TRangeType>(_loggingManager, Configuration);
        }

        private IChangeHandlerFactory<TWorksheetType, TRangeType> NewSimpleChangeHandlerFactory()
        {
            return new SimpleChangeHandlerFactory<TWorksheetType, TRangeType>(_loggingManager);
        }

    }
}
