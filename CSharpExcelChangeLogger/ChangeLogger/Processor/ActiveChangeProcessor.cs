using CSharpExcelChangeLogger.ChangeLogger.Highlighter;
using CSharpExcelChangeLogger.ChangeLogger.Memory;
using CSharpExcelChangeLogger.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Processor
{
    class ActiveChangeProcessor : IChangeProcessor
    {
        private const int DEFAULT_HIGHLIGHT_COLOUR = 65535;

        private readonly IChangeHandlerMemory _memory = new ChangeHandlerMemory();
        private readonly ISet<IChangeHandler> _handlerSet = new HashSet<IChangeHandler>();

        private readonly IChangeHandler _defaultHighlighter = new SimpleChangeHighlighter(DEFAULT_HIGHLIGHT_COLOUR);

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
            _memory.SetMemory(sheet, range);
        }

        public void AfterChange(IWorksheet sheet, IRange range)
        {
            IMemoryComparison memoryComparison = _memory.DoesMemoryMatch(sheet, range);
            if (!memoryComparison.LocationMatchesAndDataMatches)
            {
                CallAllHandlers(memoryComparison, sheet, range);
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
