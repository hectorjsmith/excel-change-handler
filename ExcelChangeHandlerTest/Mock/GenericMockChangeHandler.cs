using ExcelChangeHandler.ChangeHandling.Handler;
using ExcelChangeHandler.ChangeHandling.Memory;
using ExcelChangeHandler.Excel;

namespace ExcelChangeHandlerTest.Mock
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
