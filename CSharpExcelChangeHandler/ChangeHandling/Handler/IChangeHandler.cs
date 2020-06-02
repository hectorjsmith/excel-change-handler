using CSharpExcelChangeHandler.ChangeHandling.Processor;
using CSharpExcelChangeHandler.ChangeHandling.Memory;
using CSharpExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.ChangeHandling.Handler
{
    public interface IChangeHandler
    {
        void HandleChange(IMemoryComparison memoryComparison, IWorksheet sheet, IRange range);
    }
}
