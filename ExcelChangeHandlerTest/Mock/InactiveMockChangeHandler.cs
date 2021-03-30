using ExcelChangeHandler.ChangeHandling.Handler;
using ExcelChangeHandler.ChangeHandling.Memory;
using ExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandlerTest.Mock
{
    class InactiveMockChangeHandler : IChangeHandler<IWorksheet, IRange>
    {
        public void HandleChange(IMemoryComparison memoryComparison, IWorksheet sheet, IRange range)
        {
        }
    }
}
