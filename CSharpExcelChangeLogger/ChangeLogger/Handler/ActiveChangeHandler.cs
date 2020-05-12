using CSharpExcelChangeLogger.ChangeLogger.Highlighter;
using CSharpExcelChangeLogger.ChangeLogger.Memory;
using CSharpExcelChangeLogger.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Handler
{
    class ActiveChangeHandler : IChangeHandler
    {
        private readonly IChangeHandlerMemory _memory = new ChangeHandlerMemory();
        private readonly IChangeHighlighter _highlighter = new ActiveChangeHighlighter();

        public void BeforeChange(IWorksheet sheet, IRange range)
        {
            _memory.SetMemory(sheet, range);
        }

        public void AfterChange(IWorksheet sheet, IRange range)
        {
            IMemoryComparison memoryComparison = _memory.DoesMemoryMatch(sheet, range);
            if (!memoryComparison.LocationMatchesAndDataMatches)
            {
                _highlighter.HighlightRange(sheet, range);
            }
        }
    }
}
