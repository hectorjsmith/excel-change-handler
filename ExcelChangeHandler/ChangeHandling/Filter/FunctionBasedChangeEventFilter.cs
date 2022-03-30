using ExcelChangeHandler.ChangeHandling.Memory;
using ExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Filter
{
    internal class FunctionBasedChangeEventFilter<TWorksheetType, TRangeType> : IChangeEventFilter<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        private readonly Func<IMemoryComparison, TWorksheetType, TRangeType, bool> _filter;

        public FunctionBasedChangeEventFilter(Func<IMemoryComparison, TWorksheetType, TRangeType, bool> filter)
        {
            _filter = filter ?? throw new ArgumentNullException(nameof(filter));
        }

        public bool Apply(IMemoryComparison memoryComparison, TWorksheetType worksheet, TRangeType range)
        {
            return _filter(memoryComparison, worksheet, range);
        }
    }
}
