using ExcelChangeHandler.ChangeHandling.Memory;
using ExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Filter
{
    /// <summary>
    /// General interface that all change event filters implement.
    /// </summary>
    /// <typeparam name="TWorksheetType">Type of worksheet this filter can process.</typeparam>
    /// <typeparam name="TRangeType">Type of range this filter can process.</typeparam>
    public interface IChangeEventFilter<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        /// <summary>
        /// Apply this filter and return whether the change event should be processed or not.
        /// </summary>
        /// <param name="memoryComparison">Comparison object from before and after the change.</param>
        /// <param name="worksheet">Worksheet where the change occurred.</param>
        /// <param name="range">Range where the change occurred.</param>
        /// <returns>True if the change should be processed, false if the change event should be skipped.</returns>
        public bool Apply(IMemoryComparison memoryComparison, TWorksheetType worksheet, TRangeType range);
    }
}
