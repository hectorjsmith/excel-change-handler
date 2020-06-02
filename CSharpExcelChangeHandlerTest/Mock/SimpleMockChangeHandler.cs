using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.ChangeHandling.Memory;
using CSharpExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandlerTest.Mock
{
    class SimpleMockChangeHandler : IChangeHandler<IWorksheet, IRange>
    {
        public bool HandleChangeCalled { get; private set; }

        public void HandleChange(IMemoryComparison memoryComparison, IWorksheet sheet, IRange range)
        {
            HandleChangeCalled = true;
        }
    }
}
