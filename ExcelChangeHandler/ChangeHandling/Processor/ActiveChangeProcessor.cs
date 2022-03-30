using ExcelChangeHandler.Api.Config;
using ExcelChangeHandler.Base;
using ExcelChangeHandler.ChangeHandling.Filter;
using ExcelChangeHandler.ChangeHandling.Handler;
using ExcelChangeHandler.ChangeHandling.Memory;
using ExcelChangeHandler.Excel;
using ExcelChangeHandler.Excel.Cached;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelChangeHandler.ChangeHandling.Processor
{
    class ActiveChangeProcessor<TWorksheetType, TRangeType> : BaseClass, IChangeProcessor<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        private readonly IConfiguration _configuration;
        private readonly IList<IChangeHandler<TWorksheetType, TRangeType>> _handlerList = new List<IChangeHandler<TWorksheetType, TRangeType>>();
        private readonly IList<IChangeEventFilter<TWorksheetType, TRangeType>> _filterList = new List<IChangeEventFilter<TWorksheetType, TRangeType>>();

        private IChangeHandlerMemory? _memory;
        private IChangeHandlerMemory Memory => _memory ?? (_memory = NewChangeHandlerMemory());

        public ActiveChangeProcessor(ILoggingManager loggingManager, IConfiguration configuration) : base(loggingManager)
        {
            _configuration = configuration;
        }

        public void ClearAllFilters()
        {
            _filterList.Clear();
        }

        public void AddFilter(IChangeEventFilter<TWorksheetType, TRangeType> filter)
        {
            _filterList.Add(filter);
        }

        public void ClearAllHandlers()
        {
            _handlerList.Clear();
        }

        public void AddHandler(IChangeHandler<TWorksheetType, TRangeType> handler)
        {
            _handlerList.Add(handler);
        }

        public void BeforeChange(TWorksheetType sheet, TRangeType range)
        {
            if (_handlerList.Count > 0)
            {
                Memory.SetMemory(new CachedWorksheetWrapper(sheet), new CachedRangeWrapper(range));
            }
        }

        public void AfterChange(TWorksheetType sheet, TRangeType range)
        {
            if (_handlerList.Count > 0)
            {
                IMemoryComparison memoryComparison = Memory.Compare(new CachedWorksheetWrapper(sheet), new CachedRangeWrapper(range));
                if (DoAllFiltersPass(memoryComparison, sheet, range))
                {
                    if (!memoryComparison.LocationMatchesAndDataMatches)
                    {
                        CallAllHandlers(memoryComparison, sheet, range);
                    }
                }
            }
        }

        private void CallAllHandlers(IMemoryComparison memoryComparison, TWorksheetType sheet, TRangeType range)
        {
            foreach (IChangeHandler<TWorksheetType, TRangeType> handler in _handlerList)
            {
                handler.HandleChange(memoryComparison, sheet, range);
            }
        }

        private IChangeHandlerMemory NewChangeHandlerMemory()
        {
            return new ChangeHandlerMemory(LoggingManager, _configuration);
        }

        private bool DoAllFiltersPass(IMemoryComparison memoryComparison, TWorksheetType sheet, TRangeType range)
        {
            if (_filterList.Count == 0)
            {
                return true;
            }
            return _filterList.All(filter => filter.Apply(memoryComparison, sheet, range));
        }
    }
}
