using CSharpExcelChangeLogger.ChangeLogger.Highlighter;
using CSharpExcelChangeLogger.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Processor
{
    internal interface IChangeProcessor
    {
        void SetHighlighter(IChangeHighlighter? highlighter);

        void BeforeChange(IWorksheet sheet, IRange range);

        void AfterChange(IWorksheet sheet, IRange range);
    }
}
