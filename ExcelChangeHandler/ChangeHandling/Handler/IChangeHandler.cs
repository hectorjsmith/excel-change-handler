using ExcelChangeHandler.ChangeHandling.Processor;
using ExcelChangeHandler.ChangeHandling.Memory;
using ExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Handler
{
    /// <summary>
    /// General interface that all change handlers implement.
    /// </summary>
    /// <typeparam name="TWorksheetType">Type of worksheet this handler can process.</typeparam>
    /// <typeparam name="TRangeType">Type of range this handler can process.</typeparam>
    public interface IChangeHandler<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        /// <summary>
        /// Handle a change.
        /// </summary>
        /// <param name="memoryComparison">Comparison data related to this change (<see cref="IMemoryComparison"/>).</param>
        /// <param name="sheet">Worksheet where the change occurred.</param>
        /// <param name="range">Range where the change occurred.</param>
        void HandleChange(IMemoryComparison memoryComparison, TWorksheetType sheet, TRangeType range);
    }
}
