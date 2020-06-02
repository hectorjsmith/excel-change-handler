using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.Excel;
using CSharpExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.ChangeHandling.Factory
{
    public interface IChangeHandlerFactory<TWorksheetType, TRangeType> where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        IChangeHandler<TWorksheetType, TRangeType> NewSimpleChangeHighlighter(int highlightColour);

        IChangeHandler<TWorksheetType, TRangeType> NewSimpleChangeLogger(ILogger logger);

        IChangeHandler<TWorksheetType, TRangeType> NewSimpleChangeLogger();
    }
}
