using CSharpExcelChangeLogger.Excel;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    internal interface IChangeHandlerMemory
    {
        void SetMemory(IWorksheet sheet, IRange range);

        IMemoryComparison DoesMemoryMatch(IWorksheet sheet, IRange range);
    }
}
