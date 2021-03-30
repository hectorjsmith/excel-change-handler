using ExcelChangeHandler.ChangeHandling.Handler;
using ExcelChangeHandler.Excel;
using ExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Factory
{
    public interface IChangeHandlerFactory<TWorksheetType, TRangeType> where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        IChangeHandler<TWorksheetType, TRangeType> NewSimpleChangeHighlighter(int highlightColour);

        IChangeHandler<TWorksheetType, TRangeType> NewSimpleChangeLogger(ILogger logger);

        IChangeHandler<TWorksheetType, TRangeType> NewSimpleChangeLogger();
    }
}
