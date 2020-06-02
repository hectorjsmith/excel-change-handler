using CSharpExcelChangeLogger.ChangeLogger.Memory;
using CSharpExcelChangeLogger.Excel;
using CSharpExcelChangeLoggerTest.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLoggerTest.ChangeLogger.Memory
{
    class ChangeHandlerMemoryTest
    {
        [Test]
        public void Given_NoDataSavedToMemory_When_ComparedToSheetAndRange_Then_AddressesShouldNotMatch()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();
            IWorksheet sheet = new SimpleMockSheet();
            IRange range = new SimpleMockRange();

            IMemoryComparison comparison = memory.Compare(sheet, range);
            Assert.AreEqual(false, comparison.LocationMatches, "Location should not match given sheet/range if no data saved to memory");
            Assert.AreEqual(false, comparison.LocationMatchesAndDataMatches, 
                "Location and data should not match given sheet/range if no data saved to memory");
        }

        [Test]
        public void Given_SheetAndRangeSavedToMemory_When_ComparedToTheSameAddress_Then_TheAddressesShouldMatch()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();
            IWorksheet sheet = new SimpleMockSheet();
            IRange range = new SimpleMockRange();

            memory.SetMemory(sheet, range);
            IMemoryComparison comparison = memory.Compare(sheet, range);

            Assert.AreEqual(true, comparison.LocationMatches, "Location should match given sheet/range");
            Assert.AreEqual(true, comparison.LocationMatchesAndDataMatches,
                "Location and data should match the given sheet/range because no data was changed");
        }

        [Test]
        public void Given_SheetAndRangeSavedToMemory_When_ComparedToDifferentAddress_Then_TheAddressesShouldNotMatch()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();
            IWorksheet sheet = new SimpleMockSheet();
            IRange range1 = new SimpleMockRange("1");
            IRange range2 = new SimpleMockRange("2");

            memory.SetMemory(sheet, range1);
            IMemoryComparison comparison = memory.Compare(sheet, range2);

            Assert.AreEqual(false, comparison.LocationMatches, "Location should not match because the saved range has a different address");
            Assert.AreEqual(false, comparison.LocationMatchesAndDataMatches,
                "Location should not match because a different range was saved to memory");
        }

        [Test]
        public void Given_SheetAndRangeSavedToMemory_When_ComparedToTheSameAddressWithDifferentData_Then_ShouldReportDataChanged()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();
            IWorksheet sheet = new SimpleMockSheet();
            SimpleMockRange range1 = new SimpleMockRange("addr");
            range1.RangeData = new string[2, 2] { { "one", "two" }, { "three", "four" } };
            SimpleMockRange range2 = new SimpleMockRange("addr");
            range2.RangeData = new string[2, 2] { { "1", "2" }, { "3", "4" } };

            memory.SetMemory(sheet, range1);
            IMemoryComparison comparison = memory.Compare(sheet, range2);

            Assert.AreEqual(true, comparison.LocationMatches, "Location should match because the saved range has the same address");
            Assert.AreEqual(false, comparison.LocationMatchesAndDataMatches,
                "Should return false because the range address matches and the data has been changed");
        }

        [Test]
        public void Given_SheetAndRangeSavedToMemory_When_ComparedToTheSameAddressWithTheSameData_Then_ShouldReportNoDataChanged()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();
            IWorksheet sheet = new SimpleMockSheet();
            SimpleMockRange range1 = new SimpleMockRange("addr");
            range1.RangeData = new string[2, 2] { { "one", "two" }, { "three", "four" } };
            SimpleMockRange range2 = new SimpleMockRange("addr");
            range2.RangeData = new string[2, 2] { { "one", "two" }, { "three", "four" } };

            memory.SetMemory(sheet, range1);
            IMemoryComparison comparison = memory.Compare(sheet, range2);

            Assert.AreEqual(true, comparison.LocationMatches, "Location should match because the saved range has the same address");
            Assert.AreEqual(true, comparison.LocationMatchesAndDataMatches,
                "Should return true because both the range address and range data match");
        }

        [Test]
        public void Given_SheetAndRangeLargerThanMaxSizeSavedToMemory_When_ComparedToTheSameAddressWithTheSameData_Then_ShouldReportDataChanged()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();
            // Set the max range size to 1 so that a range with more than 1 cell does not get its data loaded into memory
            memory.MaxRangeSizeForStoringData = 1;

            IWorksheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange("addr");
            range.RangeData = new string[2, 2] { { "one", "two" }, { "three", "four" } };

            memory.SetMemory(sheet, range);
            IMemoryComparison comparison = memory.Compare(sheet, range);

            Assert.AreEqual(true, comparison.LocationMatches, "Location should match because the saved range has the same address");
            Assert.AreEqual(false, comparison.LocationMatchesAndDataMatches,
                "Should return false because the range data was not loaded into memory and as such is always treated as different");
        }

        [Test]
        public void Given_SheetSavedToMemory_When_ComparedToSheetWithMoreRows_Then_ShouldReportRowsAdded()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();

            SimpleMockSheet sheet1 = new SimpleMockSheet();
            sheet1.RowCount = 1;
            sheet1.ColumnCount = 1;
            SimpleMockSheet sheet2 = new SimpleMockSheet();
            sheet2.RowCount = 2;
            sheet2.ColumnCount = 1;
            SimpleMockRange range = new SimpleMockRange();

            memory.SetMemory(sheet1, range);
            range = new RowChangeMockRange();
            IMemoryComparison comparison = memory.Compare(sheet2, range);

            Assert.AreEqual(true, comparison.IsNewRow, "Should report new row as sheet row count increased");
            Assert.AreEqual(false, comparison.IsNewColumn, "Should not report new column as sheet column count remained the same");
            Assert.AreEqual(false, comparison.IsRowDelete, "Should not report row delete as sheet row count increased");
            Assert.AreEqual(false, comparison.IsColumnDelete, "Should not report column delete as sheet column count remained the same");
        }

        [Test]
        public void Given_SheetSavedToMemory_When_ComparedToSheetWithMoreColumns_Then_ShouldReportColumnsAdded()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();

            SimpleMockSheet sheet1 = new SimpleMockSheet();
            sheet1.RowCount = 1;
            sheet1.ColumnCount = 1;
            SimpleMockSheet sheet2 = new SimpleMockSheet();
            sheet2.RowCount = 1;
            sheet2.ColumnCount = 2;
            SimpleMockRange range = new SimpleMockRange();

            memory.SetMemory(sheet1, range);
            range = new ColumnChangeMockRange();
            IMemoryComparison comparison = memory.Compare(sheet2, range);

            Assert.AreEqual(false, comparison.IsNewRow, "Should not report new row as sheet row count remained the same");
            Assert.AreEqual(true, comparison.IsNewColumn, "Should report new column as sheet row cound increased");
            Assert.AreEqual(false, comparison.IsRowDelete, "Should not report row delete as sheet row count remained the same");
            Assert.AreEqual(false, comparison.IsColumnDelete, "Should not report column delete as sheet column count increased");
        }

        [Test]
        public void Given_SheetWithNoDataSavedToMemory_When_ComparedToSheetWithMoreRows_Then_ShouldReportRowsAdded()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();

            SimpleMockSheet sheet1 = new SimpleMockSheet();
            sheet1.RowCount = 1;
            sheet1.ColumnCount = 1;
            SimpleMockSheet sheet2 = new SimpleMockSheet();
            sheet2.RowCount = 2;
            sheet2.ColumnCount = 1;
            SimpleMockRange range = new SimpleMockRange();

            range.RangeData = new string[memory.MaxRangeSizeForStoringData + 1, 1];
            memory.SetMemory(sheet1, range);

            range = new RowChangeMockRange();
            IMemoryComparison comparison = memory.Compare(sheet2, range);

            Assert.IsNull(comparison.DataBeforeChange, "GIVEN: Data from before change should not be saved");
            Assert.AreEqual(true, comparison.IsNewRow, "Should report new row as sheet row count increased");
            Assert.AreEqual(false, comparison.IsNewColumn, "Should not report new column as sheet column count remained the same");
            Assert.AreEqual(false, comparison.IsRowDelete, "Should not report row delete as sheet row count increased");
            Assert.AreEqual(false, comparison.IsColumnDelete, "Should not report column delete as sheet column count remained the same");
        }

        [Test]
        public void Given_SheetWithNoDataSavedToMemory_When_ComparedToSheetWithMoreColumns_Then_ShouldReportColumnsAdded()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();

            SimpleMockSheet sheet1 = new SimpleMockSheet();
            sheet1.RowCount = 1;
            sheet1.ColumnCount = 1;
            SimpleMockSheet sheet2 = new SimpleMockSheet();
            sheet2.RowCount = 1;
            sheet2.ColumnCount = 2;
            SimpleMockRange range = new SimpleMockRange();

            range.RangeData = new string[memory.MaxRangeSizeForStoringData + 1, 1];
            memory.SetMemory(sheet1, range);

            range = new ColumnChangeMockRange();
            IMemoryComparison comparison = memory.Compare(sheet2, range);

            Assert.IsNull(comparison.DataBeforeChange, "GIVEN: Data from before change should not be saved");
            Assert.AreEqual(false, comparison.IsNewRow, "Should not report new row as sheet row count remained the same");
            Assert.AreEqual(true, comparison.IsNewColumn, "Should report new column as sheet size grew");
            Assert.AreEqual(false, comparison.IsRowDelete, "Should not report row delete as sheet row count remained the same");
            Assert.AreEqual(false, comparison.IsColumnDelete, "Should not report column delete as sheet column count remained the same");
        }

        [Test]
        public void Given_SheetSavedToMemory_When_ComparedToSheetWithFewerRows_Then_ShouldReportRowsDeleted()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();

            SimpleMockSheet sheet1 = new SimpleMockSheet();
            sheet1.RowCount = 2;
            sheet1.ColumnCount = 2;
            SimpleMockSheet sheet2 = new SimpleMockSheet();
            sheet2.RowCount = 1;
            sheet2.ColumnCount = 2;
            SimpleMockRange range = new SimpleMockRange();

            memory.SetMemory(sheet1, range);
            range = new RowChangeMockRange();
            IMemoryComparison comparison = memory.Compare(sheet2, range);

            Assert.AreEqual(false, comparison.IsNewRow, "Should not report new row as sheet row count decreased");
            Assert.AreEqual(false, comparison.IsNewColumn, "Should not report new column as sheet column count remained the same");
            Assert.AreEqual(true, comparison.IsRowDelete, "Should report row delete as sheet row count decreased");
            Assert.AreEqual(false, comparison.IsColumnDelete, "Should not report column delete as sheet column count remained the same");
        }

        [Test]
        public void Given_SheetSavedToMemory_When_ComparedToSheetWithFewerColumns_Then_ShouldReportColumnsDeleted()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();

            SimpleMockSheet sheet1 = new SimpleMockSheet();
            sheet1.RowCount = 2;
            sheet1.ColumnCount = 2;
            SimpleMockSheet sheet2 = new SimpleMockSheet();
            sheet2.RowCount = 2;
            sheet2.ColumnCount = 1;

            SimpleMockRange range = new SimpleMockRange();
            memory.SetMemory(sheet1, range);

            range = new ColumnChangeMockRange();
            IMemoryComparison comparison = memory.Compare(sheet2, range);

            Assert.AreEqual(false, comparison.IsNewRow, "Should not report new row as sheet row count remained the same");
            Assert.AreEqual(false, comparison.IsNewColumn, "Should not report new column as sheet column count decreased");
            Assert.AreEqual(false, comparison.IsRowDelete, "Should not report row delete as sheet row count remained the same");
            Assert.AreEqual(true, comparison.IsColumnDelete, "Should report column delete as sheet column count decreased");
        }

        [Test]
        public void Given_SheetWithNoDataSavedToMemory_When_ComparedToSheetWithFewerRows_Then_ShouldReportRowsDeleted()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();

            SimpleMockSheet sheet1 = new SimpleMockSheet();
            sheet1.RowCount = 2;
            sheet1.ColumnCount = 2;
            SimpleMockSheet sheet2 = new SimpleMockSheet();
            sheet2.RowCount = 1;
            sheet2.ColumnCount = 2;
            SimpleMockRange range = new SimpleMockRange();

            range.RangeData = new string[memory.MaxRangeSizeForStoringData + 1, 1];
            memory.SetMemory(sheet1, range);

            range = new RowChangeMockRange();
            IMemoryComparison comparison = memory.Compare(sheet2, range);

            Assert.IsNull(comparison.DataBeforeChange, "GIVEN: Data from before change should not be saved");
            Assert.AreEqual(false, comparison.IsNewRow, "Should not report new row as sheet row count decreased");
            Assert.AreEqual(false, comparison.IsNewColumn, "Should not report new column as sheet column count remained the same");
            Assert.AreEqual(true, comparison.IsRowDelete, "Should report row delete as sheet row count decreased");
            Assert.AreEqual(false, comparison.IsColumnDelete, "Should not report column delete as sheet column count remained the same");
        }

        [Test]
        public void Given_SheetWithNoDataSavedToMemory_When_ComparedToSheetWithFewerColumns_Then_ShouldReportColumnsDeleted()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();

            SimpleMockSheet sheet1 = new SimpleMockSheet();
            sheet1.RowCount = 2;
            sheet1.ColumnCount = 2;
            SimpleMockSheet sheet2 = new SimpleMockSheet();
            sheet2.RowCount = 2;
            sheet2.ColumnCount = 1;
            SimpleMockRange range = new SimpleMockRange();

            range.RangeData = new string[memory.MaxRangeSizeForStoringData + 1, 1];
            memory.SetMemory(sheet1, range);
            
            range = new ColumnChangeMockRange();
            IMemoryComparison comparison = memory.Compare(sheet2, range);

            Assert.IsNull(comparison.DataBeforeChange, "GIVEN: Data from before change should not be saved");
            Assert.AreEqual(false, comparison.IsNewRow, "Should not report new row as sheet column count remained the same");
            Assert.AreEqual(false, comparison.IsNewColumn, "Should report new column as sheet column count decreased");
            Assert.AreEqual(false, comparison.IsRowDelete, "Should not report row delete as sheet column count remained the same");
            Assert.AreEqual(true, comparison.IsColumnDelete, "Should report column delete as sheet column count decreased");
        }

        [Test]
        public void Given_SheetAndRangeSavedToMemory_When_ComparedToAnotherSheetAndRange_Then_BeforeAndAfterAddressProvided()
        {
            IChangeHandlerMemory memory = new ChangeHandlerMemory();

            string sheet1Name = "sheet 1";
            string sheet2Name = "sheet 2";
            string range1Addr = "A1";
            string range2Addr = "B2";

            SimpleMockSheet sheet1 = new SimpleMockSheet(sheet1Name);
            SimpleMockSheet sheet2 = new SimpleMockSheet(sheet2Name);

            SimpleMockRange range1 = new SimpleMockRange(range1Addr);
            memory.SetMemory(sheet1, range1);

            SimpleMockRange range2 = new SimpleMockRange(range2Addr);
            IMemoryComparison comparison = memory.Compare(sheet2, range2);

            Assert.AreEqual(sheet1Name, comparison.SheetNameBeforeChange, "Sheet name from before change should match name of sheet1");
            Assert.AreEqual(sheet2Name, comparison.SheetNameAfterChange, "Sheet name from after change should match name of sheet2");
            Assert.AreEqual(range1Addr, comparison.RangeAddressBeforeChange, "Range address from before change should match name of range1");
            Assert.AreEqual(range2Addr, comparison.RangeAddressAfterChange, "Range address from after change should match name of range2");
        }
    }
}
