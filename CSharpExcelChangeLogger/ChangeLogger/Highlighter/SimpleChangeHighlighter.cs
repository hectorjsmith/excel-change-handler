using CSharpExcelChangeLogger.Base;
using CSharpExcelChangeLogger.ChangeLogger.Memory;
using CSharpExcelChangeLogger.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Highlighter
{
    internal class SimpleChangeHighlighter : BaseClass, IChangeHighlighter
    {
        public void HighlightRange(IMemoryComparison memoryComparison, IWorksheet sheet, IRange range)
        {
            Log.Debug(string.Format("Highlighting range '{0}' on sheet '{1}'", range.Address, sheet.Name));
            range.FillRange(StaticChangeLoggerManager.Configuration.CellHighlightColour);
        }
    }
}
