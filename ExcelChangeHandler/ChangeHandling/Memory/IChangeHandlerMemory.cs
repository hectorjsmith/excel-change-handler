using ExcelChangeHandler.Excel;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Memory
{
    internal interface IChangeHandlerMemory
    {
        long MaxRangeSizeForStoringData { get; }
        string? SheetName { get; }
        string? RangeAddress { get; }
        string[,]? RangeData { get; }
        long? RangeDataSize { get; }

        void UnsetMemory();

        void SetMemory(IWorksheet sheet, IRange range);

        IMemoryComparison Compare(IWorksheet sheet, IRange range);
    }
}
