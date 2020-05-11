using CSharpExcelChangeLogger.ChangeLogger.Highlighter;
using CSharpExcelChangeLogger.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Base
{
    class ChangeHandlerBase : IChangeHandler
    {
        private readonly IChangeHighlighter _highlighter = new ActiveChangeHighlighter();

        public void BeforeChange(IWorksheet sheet, IRange range)
        {
            throw new NotImplementedException();
        }

        public void AfterChange(IWorksheet sheet, IRange range)
        {
            _highlighter.HighlightRange(sheet, range);
        }
    }
}
