using ExcelChangeHandler.Base;
using ExcelChangeHandler.ChangeHandling.Handler;
using ExcelChangeHandler.ChangeHandling.Highlighter;
using ExcelChangeHandler.ChangeHandling.Logger;
using ExcelChangeHandler.Excel;
using ExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Factory
{
    class SimpleChangeHandlerFactory<TWorksheetType, TRangeType> : BaseClass, IChangeHandlerFactory<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        public SimpleChangeHandlerFactory(ILoggingManager loggingManager) : base(loggingManager)
        {
        }

        public IChangeHandler<TWorksheetType, TRangeType> NewSimpleChangeHighlighter(int highlightColour)
        {
            return new SimpleChangeHighlighter<TWorksheetType, TRangeType>(LoggingManager, highlightColour);
        }

        public IChangeHandler<TWorksheetType, TRangeType> NewSimpleChangeLogger(ILogger logger)
        {
            return new SimpleInfoChangeLogger<TWorksheetType, TRangeType>(logger);
        }

        public IChangeHandler<TWorksheetType, TRangeType> NewSimpleChangeLogger()
        {
            return new SimpleInfoChangeLogger<TWorksheetType, TRangeType>(Log);
        }
    }
}
