using ExcelChangeHandler.ChangeHandling.Memory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandlerTest.ChangeHandler.Memory
{
    class MemoryComparisonTest
    {
        [Test]
        public void Given_MemoryComparisonObject_When_ConstructedWithSheetSizeChanges_Then_SheetSizeChangedPropertyIsTrue()
        {
            IMemoryComparison memory = NewMemoryComparisonObject(true, false, false, false);
            Assert.True(memory.HasSheetSizeChanged, "Sheet size should report true if columns/rows were added/removed");

            memory = NewMemoryComparisonObject(false, true, false, false);
            Assert.True(memory.HasSheetSizeChanged, "Sheet size should report true if columns/rows were added/removed");

            memory = NewMemoryComparisonObject(false, false, true, false);
            Assert.True(memory.HasSheetSizeChanged, "Sheet size should report true if columns/rows were added/removed");

            memory = NewMemoryComparisonObject(false, false, false, true);
            Assert.True(memory.HasSheetSizeChanged, "Sheet size should report true if columns/rows were added/removed");

            memory = NewMemoryComparisonObject(true, true, true, true);
            Assert.True(memory.HasSheetSizeChanged, "Sheet size should report true if columns/rows were added/removed");
        }

        [Test]
        public void Given_MemoryComparisonObject_When_ConstructedWithoutSheetSizeChanges_Then_SheetSizeChangedPropertyIsFalse()
        {
            IMemoryComparison memory = NewMemoryComparisonObject(false, false, false, false);
            Assert.False(memory.HasSheetSizeChanged, "Sheet size should not report true if no columns/rows were added/removed");
        }

        private IMemoryComparison NewMemoryComparisonObject(bool isNewRow, bool isRowDelete, bool isNewColumn, bool isColumnDelete)
        {
            return new MemoryComparison(isNewRow, isRowDelete, isNewColumn, isColumnDelete, true, true, null, new ChangePropertiesImpl(null, null, null, null, null));
        }
    }
}
