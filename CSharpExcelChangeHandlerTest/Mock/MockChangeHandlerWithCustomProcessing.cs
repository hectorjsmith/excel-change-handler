using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.ChangeHandling.Memory;
using CSharpExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandlerTest.Mock
{
    class MockChangeHandlerWithCustomProcessing<TWorksheetType, TRangeType> : IChangeHandler<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        private readonly Action<IMemoryComparison, TWorksheetType, TRangeType> _changeHandlerProcessing;

        public MockChangeHandlerWithCustomProcessing(Action<IMemoryComparison, TWorksheetType, TRangeType> changeHandlerProcessing)
        {
            _changeHandlerProcessing = changeHandlerProcessing;
        }

        public void HandleChange(IMemoryComparison memoryComparison, TWorksheetType sheet, TRangeType range)
        {
            _changeHandlerProcessing(memoryComparison, sheet, range);
        }
    }
}
