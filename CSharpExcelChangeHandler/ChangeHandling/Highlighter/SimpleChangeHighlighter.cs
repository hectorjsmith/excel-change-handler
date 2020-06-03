using CSharpExcelChangeHandler.Base;
using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.ChangeHandling.Memory;
using CSharpExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.ChangeHandling.Highlighter
{
    internal class SimpleChangeHighlighter<TWorksheetType, TRangeType> : BaseClass, IChangeHandler<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        private readonly int _highlightColour;

        public SimpleChangeHighlighter(ILoggingManager loggingManager, int highlightColour) : base(loggingManager)
        {
            _highlightColour = highlightColour;
        }

        public void HandleChange(IMemoryComparison memoryComparison, TWorksheetType sheet, TRangeType range)
        {
            if (!memoryComparison.IsColumnDelete && !memoryComparison.IsRowDelete)
            {
                Log.Debug(string.Format("Highlighting range '{0}' on sheet '{1}'", range.Address, sheet.Name));
                range.FillRange(_highlightColour);
            }
        }
    }
}
