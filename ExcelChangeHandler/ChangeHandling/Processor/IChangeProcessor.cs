using ExcelChangeHandler.ChangeHandling.Handler;
using ExcelChangeHandler.ChangeHandling.Highlighter;
using ExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Processor
{
    internal interface IChangeProcessor<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        void ClearAllHandlers();

        void AddHandler(IChangeHandler<TWorksheetType, TRangeType> highlighter);

        void BeforeChange(TWorksheetType sheet, TRangeType range);

        void AfterChange(TWorksheetType sheet, TRangeType range);
    }
}
