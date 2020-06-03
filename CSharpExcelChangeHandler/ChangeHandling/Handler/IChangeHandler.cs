using CSharpExcelChangeHandler.ChangeHandling.Processor;
using CSharpExcelChangeHandler.ChangeHandling.Memory;
using CSharpExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.ChangeHandling.Handler
{
    public interface IChangeHandler<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        void HandleChange(IMemoryComparison memoryComparison, TWorksheetType sheet, TRangeType range);
    }
}
