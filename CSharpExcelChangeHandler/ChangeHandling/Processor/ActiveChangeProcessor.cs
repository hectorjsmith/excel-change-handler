using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.ChangeHandling.Memory;
using CSharpExcelChangeHandler.Excel;
using CSharpExcelChangeHandler.Excel.Cached;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.ChangeHandling.Processor
{
    class ActiveChangeProcessor : IChangeProcessor
    {
        private readonly IChangeHandlerMemory _memory = new ChangeHandlerMemory();
        private readonly ISet<IChangeHandler> _handlerSet = new HashSet<IChangeHandler>();

        public void ClearAllHandlers()
        {
            _handlerSet.Clear();
        }

        public void AddHandler(IChangeHandler handler)
        {
            _handlerSet.Add(handler);
        }

        public void BeforeChange(IWorksheet sheet, IRange range)
        {
            if (_handlerSet.Count > 0)
            {
                _memory.SetMemory(new CachedWorksheetWrapper(sheet), new CachedRangeWrapper(range));
            }
        }

        public void AfterChange(IWorksheet sheet, IRange range)
        {
            if (_handlerSet.Count > 0)
            {
                IMemoryComparison memoryComparison = _memory.Compare(new CachedWorksheetWrapper(sheet), new CachedRangeWrapper(range));
                if (!memoryComparison.LocationMatchesAndDataMatches)
                {
                    CallAllHandlers(memoryComparison, sheet, range);
                }
            }
        }

        private void CallAllHandlers(IMemoryComparison memoryComparison, IWorksheet sheet, IRange range)
        {
            foreach (IChangeHandler handler in _handlerSet)
            {
                handler.HandleChange(memoryComparison, sheet, range);
            }
        }
    }
}
