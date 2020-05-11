using CSharpExcelChangeLogger.Base;
using CSharpExcelChangeLogger.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Highlighter
{
    internal class ActiveChangeHighlighter : BaseClass, IChangeHighlighter
    {
        public void BeforeChange(IWorksheet sheet, IRange range)
        {
            throw new NotImplementedException();
        }

        public void AfterChange(IWorksheet sheet, IRange range)
        {
            Log.Info(string.Format("Highlighting range '{0}' on sheet '{1}'", range.Address, sheet.Name));
            range.FillRange(StaticChangeLoggerManager.Configuration.CellHighlightRgbColour);
        }
    }
}
