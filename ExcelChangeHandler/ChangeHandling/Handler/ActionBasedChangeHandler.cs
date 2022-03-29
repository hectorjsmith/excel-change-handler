using ExcelChangeHandler.ChangeHandling.Memory;
using ExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Handler
{
    internal class ActionBasedChangeHandler<TWorksheetType, TRangeType> : IChangeHandler<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        private readonly Action<IMemoryComparison, TWorksheetType, TRangeType> _handler;

        public ActionBasedChangeHandler(Action<IMemoryComparison, TWorksheetType, TRangeType> handler)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        public void HandleChange(IMemoryComparison memoryComparison, TWorksheetType sheet, TRangeType range)
        {
            _handler(memoryComparison, sheet, range);
        }
    }
}
