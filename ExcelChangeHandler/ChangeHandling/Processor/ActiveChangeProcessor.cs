using ExcelChangeHandler.Api.Config;
using ExcelChangeHandler.Base;
using ExcelChangeHandler.ChangeHandling.Handler;
using ExcelChangeHandler.ChangeHandling.Memory;
using ExcelChangeHandler.Excel;
using ExcelChangeHandler.Excel.Cached;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Processor
{
    class ActiveChangeProcessor<TWorksheetType, TRangeType> : BaseClass, IChangeProcessor<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        private readonly IConfiguration _configuration;
        private readonly ISet<IChangeHandler<TWorksheetType, TRangeType>> _handlerSet = new HashSet<IChangeHandler<TWorksheetType, TRangeType>>();

        private IChangeHandlerMemory? _memory;
        private IChangeHandlerMemory Memory => _memory ?? (_memory = NewChangeHandlerMemory());

        public ActiveChangeProcessor(ILoggingManager loggingManager, IConfiguration configuration) : base(loggingManager)
        {
            _configuration = configuration;
        }

        public void ClearAllHandlers()
        {
            _handlerSet.Clear();
        }

        public void AddHandler(IChangeHandler<TWorksheetType, TRangeType> handler)
        {
            _handlerSet.Add(handler);
        }

        public void BeforeChange(TWorksheetType sheet, TRangeType range)
        {
            if (_handlerSet.Count > 0)
            {
                Memory.SetMemory(new CachedWorksheetWrapper(sheet), new CachedRangeWrapper(range));
            }
        }

        public void AfterChange(TWorksheetType sheet, TRangeType range)
        {
            if (_handlerSet.Count > 0)
            {
                IMemoryComparison memoryComparison = Memory.Compare(new CachedWorksheetWrapper(sheet), new CachedRangeWrapper(range));
                if (!memoryComparison.LocationMatchesAndDataMatches)
                {
                    CallAllHandlers(memoryComparison, sheet, range);
                }
            }
        }

        private void CallAllHandlers(IMemoryComparison memoryComparison, TWorksheetType sheet, TRangeType range)
        {
            foreach (IChangeHandler<TWorksheetType, TRangeType> handler in _handlerSet)
            {
                handler.HandleChange(memoryComparison, sheet, range);
            }
        }

        private IChangeHandlerMemory NewChangeHandlerMemory()
        {
            return new ChangeHandlerMemory(LoggingManager, _configuration);
        }
    }
}
