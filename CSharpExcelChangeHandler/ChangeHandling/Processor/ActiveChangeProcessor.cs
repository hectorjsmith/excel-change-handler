using CSharpExcelChangeHandler.Base;
using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.ChangeHandling.Memory;
using CSharpExcelChangeHandler.Excel;
using CSharpExcelChangeHandler.Excel.Cached;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.ChangeHandling.Processor
{
    class ActiveChangeProcessor<TWorksheetType, TRangeType> : BaseClass, IChangeProcessor<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        private readonly ISet<IChangeHandler<TWorksheetType, TRangeType>> _handlerSet = new HashSet<IChangeHandler<TWorksheetType, TRangeType>>();

        private IChangeHandlerMemory? _memory;
        private IChangeHandlerMemory Memory => _memory ?? (_memory = new ChangeHandlerMemory(LoggingManager));

        public ActiveChangeProcessor(ILoggingManager loggingManager) : base(loggingManager)
        {
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
    }
}
