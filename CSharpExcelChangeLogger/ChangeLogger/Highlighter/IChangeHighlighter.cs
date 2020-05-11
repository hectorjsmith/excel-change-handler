using CSharpExcelChangeLogger.ChangeLogger.Base;
using CSharpExcelChangeLogger.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Highlighter
{
    internal interface IChangeHighlighter
    {
        void HighlightRange(IWorksheet sheet, IRange range);
    }
}
