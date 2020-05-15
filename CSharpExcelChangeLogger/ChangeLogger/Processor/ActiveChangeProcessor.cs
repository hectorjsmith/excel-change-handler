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
        private readonly IChangeHighlighter _defaultHighlighter = new SimpleChangeHighlighter(DEFAULT_HIGHLIGHT_COLOUR);
        private IChangeHighlighter? _injectedHighlighter;

        public IChangeHighlighter ChangeHighlighter => _injectedHighlighter ?? _defaultHighlighter;

        public void SetHighlighter(IChangeHighlighter? highlighter)
        {
            _injectedHighlighter = highlighter;
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
                ChangeHighlighter.HighlightRange(memoryComparison, sheet, range);
            }
        }

    }
}
