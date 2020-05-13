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
        private IChangeHighlighter Highlighter => StaticChangeLoggerManager.ChangeHighlighter;

        private bool ChangeHandlingEnabled => StaticChangeLoggerManager.Configuration.HighlighterEnabled;

        public void BeforeChange(IWorksheet sheet, IRange range)
        {
            if (ChangeHandlingEnabled)
            {
                _memory.SetMemory(sheet, range);
            }
        }

        public void AfterChange(IWorksheet sheet, IRange range)
        {
            if (ChangeHandlingEnabled)
            {
                IMemoryComparison memoryComparison = _memory.DoesMemoryMatch(sheet, range);
                if (!memoryComparison.LocationMatchesAndDataMatches)
                {
                    Highlighter.HighlightRange(memoryComparison, sheet, range);
                }
            }
        }
    }
}
