using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.ChangeHandling.Highlighter;
using CSharpExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.ChangeHandling.Processor
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
