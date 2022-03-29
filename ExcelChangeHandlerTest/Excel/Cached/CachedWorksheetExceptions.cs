using ExcelChangeHandler.Excel;
using ExcelChangeHandler.Excel.Cached;
using ExcelChangeHandler.Excel.Exception;
using ExcelChangeHandlerTest.Mock;
using NUnit.Framework;

namespace ExcelChangeHandlerTest.Excel.Cached
{
    class CachedWorksheetExceptions
    {
        [Test]
        public void Given_CachedWorksheetDecorator_When_ExceptionThrownWhenAccessingData_Then_CorrectExceptionThrown()
        {
            // Assemble
            IWorksheet worksheet = new ExceptionMockSheet();
            ICachedWorksheet cachedWorksheet = new CachedWorksheetWrapper(worksheet);

            // Act / Assert
            Assert.Throws<ExcelDataAccessException>(() => { var a = cachedWorksheet.Name; }, "Exception of correct type should be thrown");
            Assert.Throws<ExcelDataAccessException>(() => { var a = cachedWorksheet.ColumnCount; }, "Exception of correct type should be thrown");
            Assert.Throws<ExcelDataAccessException>(() => { var a = cachedWorksheet.RowCount; }, "Exception of correct type should be thrown");
        }
    }
}
