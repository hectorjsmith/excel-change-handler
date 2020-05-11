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

            IMemoryComparison comparison = memory.DoesMemoryMatch(sheet, range);
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
            IMemoryComparison comparison = memory.DoesMemoryMatch(sheet, range);

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
            IMemoryComparison comparison = memory.DoesMemoryMatch(sheet, range2);

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
            range1.RangeData = new string[2, 2] { { "1", "2" }, { "3", "4" } };

            memory.SetMemory(sheet, range1);
            IMemoryComparison comparison = memory.DoesMemoryMatch(sheet, range2);

            Assert.AreEqual(true, comparison.LocationMatches, "Location should match because the saved range has the same address");
            Assert.AreEqual(false, comparison.LocationMatchesAndDataMatches,
                "Should return true because the range address matches and the data has been changed");
        }
    }
}
