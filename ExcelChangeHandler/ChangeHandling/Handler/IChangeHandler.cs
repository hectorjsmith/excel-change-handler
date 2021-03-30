using ExcelChangeHandler.ChangeHandling.Processor;
using ExcelChangeHandler.ChangeHandling.Memory;
using ExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Handler
{
    public interface IChangeHandler<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        void HandleChange(IMemoryComparison memoryComparison, TWorksheetType sheet, TRangeType range);
    }
}
