using ExcelChangeHandler.Excel;
using ExcelChangeHandler.Excel.Cached;
using ExcelChangeHandler.Excel.Exception;
using ExcelChangeHandlerTest.Mock;
using NUnit.Framework;

namespace ExcelChangeHandlerTest.Excel.Cached
{
    class CachedRangeExceptions
    {
        [Test]
        public void Given_CachedRangeDecorator_When_ExceptionThrownWhenAccessingData_Then_CorrectExceptionThrown()
        {
            // Assemble
            IRange range = new ExceptionMockRange();
            ICachedRange cachedRange = new CachedRangeWrapper(range);

            // Act / Assert
            Assert.Throws<ExcelDataAccessException>(() => { var a = cachedRange.Address; }, "Exception of correct type should be thrown");
            Assert.Throws<ExcelDataAccessException>(() => { var a = cachedRange.ColumnCount; }, "Exception of correct type should be thrown");
            Assert.Throws<ExcelDataAccessException>(() => { var a = cachedRange.RowCount; }, "Exception of correct type should be thrown");
            Assert.Throws<ExcelDataAccessException>(() => { var a = cachedRange.RangeData; }, "Exception of correct type should be thrown");
            Assert.Throws<ExcelDataAccessException>(() => cachedRange.FillRange(100), "Exception of correct type should be thrown");
        }
    }
}
