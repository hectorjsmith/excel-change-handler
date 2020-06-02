using CSharpExcelChangeLogger.Excel;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    internal interface IChangeHandlerMemory
    {
        int MaxRangeSizeForStoringData { get; set; }
        string? SheetName { get; }
        string? RangeAddress { get; }
        string[,]? RangeData { get; }

        void UnsetMemory();

        void SetMemory(IWorksheet sheet, IRange range);

        IMemoryComparison Compare(IWorksheet sheet, IRange range);
    }
}
