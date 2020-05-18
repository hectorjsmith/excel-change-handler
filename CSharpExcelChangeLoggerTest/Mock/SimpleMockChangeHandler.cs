using CSharpExcelChangeLogger.ChangeLogger.Handler;
using CSharpExcelChangeLogger.ChangeLogger.Memory;
using CSharpExcelChangeLogger.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLoggerTest.Mock
{
    class SimpleMockChangeHandler : IChangeHandler
    {
        public bool HandleChangeCalled { get; private set; }

        public void HandleChange(IMemoryComparison memoryComparison, IWorksheet sheet, IRange range)
        {
            HandleChangeCalled = true;
        }
    }
}
