using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.ChangeHandling.Memory;
using CSharpExcelChangeHandler.Excel;

namespace CSharpExcelChangeHandlerTest.Mock
{
    class GenericMockChangeHandler<TWorksheetType, TRangeType> : IChangeHandler<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        public bool HandleChangeCalled { get; private set; }

        public void HandleChange(IMemoryComparison memoryComparison, TWorksheetType sheet, TRangeType range)
        {
            HandleChangeCalled = true;
        }
    }
}
