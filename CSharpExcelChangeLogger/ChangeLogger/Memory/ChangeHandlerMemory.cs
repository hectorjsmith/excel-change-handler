using CSharpExcelChangeLogger.Excel;
using System;

namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    class ChangeHandlerMemory : IChangeHandlerMemory
    {
        public IMemoryComparison DoesMemoryMatch(IWorksheet sheet, IRange range)
        {
            throw new NotImplementedException();
        }

        public void SetMemory(IWorksheet sheet, IRange range)
        {
            throw new NotImplementedException();
        }
    }
}
