using CSharpExcelChangeHandler.Api;
using CSharpExcelChangeHandler.ChangeHandling.Processor;
using CSharpExcelChangeHandler.ChangeHandling.Highlighter;
using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandlerTest.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandlerTest.ChangeHandler.Handler
{
    class ActiveChangeProcessorTest
    {
        [Test]
        public void Given_ActiveChangeProcessor_When_AfterValidChangeDetected_Then_AllHandlersTriggered()
        {
            IChangeProcessor changeHandler = new ActiveChangeProcessor(new MockLoggingManager());

            SimpleMockChangeHandler handler1 = new SimpleMockChangeHandler();
            SimpleMockChangeHandler handler2 = new SimpleMockChangeHandler();
            changeHandler.AddHandler(handler1);
            changeHandler.AddHandler(handler2);

            changeHandler.AfterChange(new SimpleMockSheet(), new SimpleMockRange());

            Assert.IsTrue(handler1.HandleChangeCalled, "Processor should have fired handler1");
            Assert.IsTrue(handler2.HandleChangeCalled, "Processor should have fired handler2");
        }

        [Test]
        public void Given_ActiveChangeProcessorWithNoMemory_When_AfterChangeCalled_Then_ChangeHighlighted()
        {
            int testColour = 111;
            IChangeProcessor changeHandler = new ActiveChangeProcessor(new MockLoggingManager());
            changeHandler.AddHandler(new SimpleChangeHighlighter(new MockLoggingManager(), testColour));

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange();

            changeHandler.AfterChange(sheet, range);

            Assert.AreEqual(testColour, range.FillColour, "Range should be highlighted if no memory was set");
        }

        [Test]
        public void Given_ActiveChangeProcessorWithMemory_When_AfterChangeCalledWithNoDataChange_Then_RangeNotHighlighted()
        {
            int testColour = 111;
            IChangeProcessor changeHandler = new ActiveChangeProcessor(new MockLoggingManager());
            changeHandler.AddHandler(new SimpleChangeHighlighter(new MockLoggingManager(), testColour));

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range1 = new SimpleMockRange();
            range1.RangeData = new string[2, 2] { { "one", "two" }, { "three", "four" } };
            SimpleMockRange range2 = new SimpleMockRange();
            range2.RangeData = new string[2, 2] { { "one", "two" }, { "three", "four" } };

            changeHandler.BeforeChange(sheet, range1);
            changeHandler.AfterChange(sheet, range2);

            Assert.AreNotEqual(testColour, range2.FillColour, "Range should not be highlighted if no data was changed");
        }

        [Test]
        public void Given_ActiveChangeProcessorWithMemory_When_AfterChangeCalledWithDataChanges_Then_RangeHighlighted()
        {
            int testColour = 111;
            IChangeProcessor changeHandler = new ActiveChangeProcessor(new MockLoggingManager());
            changeHandler.AddHandler(new SimpleChangeHighlighter(new MockLoggingManager(), testColour));

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range1 = new SimpleMockRange();
            range1.RangeData = new string[2, 2] { { "one", "two" }, { "three", "four" } };
            SimpleMockRange range2 = new SimpleMockRange();
            range2.RangeData = new string[2, 2] { { "1", "2" }, { "3", "4" } };

            changeHandler.BeforeChange(sheet, range1);
            changeHandler.AfterChange(sheet, range2);

            Assert.AreEqual(testColour, range2.FillColour, "Range should be highlighted if data was changed");
        }

        [Test]
        public void Given_ActiveChangeProcessorWithMemory_When_AfterChangeCalledWithDifferentRange_Then_RangeHighlighted()
        {
            int testColour = 111;
            IChangeProcessor changeHandler = new ActiveChangeProcessor(new MockLoggingManager());
            changeHandler.AddHandler(new SimpleChangeHighlighter(new MockLoggingManager(), testColour));

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range1 = new SimpleMockRange("1");
            SimpleMockRange range2 = new SimpleMockRange("2");

            changeHandler.BeforeChange(sheet, range1);
            changeHandler.AfterChange(sheet, range2);

            Assert.AreEqual(testColour, range2.FillColour, "Range should be highlighted if address is different");
        }

        [Test]
        public void Given_ActiveChangeProcessor_When_BeforeChangeCalled_Then_MethodsOnSheetCachedAndOnlyCalledOnce()
        {
            IChangeProcessor changeHandler = new ActiveChangeProcessor(new MockLoggingManager());
            changeHandler.AddHandler(new InactiveMockChangeHandler());
            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange();

            Assert.AreEqual(0, sheet.NameCallCount, "Given: Call count for Name property should be 0 before running method");
            Assert.AreEqual(0, sheet.RowCountCallCount, "Given: Call count for RowCount property should be 0 before running method");
            Assert.AreEqual(0, sheet.ColumnCountCallCount, "Given: Call count for ColumnCount property should be 0 before running method");

            changeHandler.BeforeChange(sheet, range);

            Assert.LessOrEqual(sheet.NameCallCount, 1, "Call count for Name property should be no more than 1");
            Assert.LessOrEqual(sheet.RowCountCallCount, 1, "Call count for RowCount property should be no more than 1");
            Assert.LessOrEqual(sheet.ColumnCountCallCount, 1, "Call count for ColumnCount property should be no more than 1");
        }

        [Test]
        public void Given_ActiveChangeProcessor_When_AfterChangeCalled_Then_MethodsOnSheetCachedAndOnlyCalledOnce()
        {
            IChangeProcessor changeHandler = new ActiveChangeProcessor(new MockLoggingManager());
            changeHandler.AddHandler(new InactiveMockChangeHandler());
            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange();

            Assert.AreEqual(0, sheet.NameCallCount, "Given: Call count for Name property should be 0 before running method");
            Assert.AreEqual(0, sheet.RowCountCallCount, "Given: Call count for RowCount property should be 0 before running method");
            Assert.AreEqual(0, sheet.ColumnCountCallCount, "Given: Call count for ColumnCount property should be 0 before running method");

            changeHandler.AfterChange(sheet, range);

            Assert.LessOrEqual(sheet.NameCallCount, 1, "Call count for Name property should be no more than 1");
            Assert.LessOrEqual(sheet.RowCountCallCount, 1, "Call count for RowCount property should be no more than 1");
            Assert.LessOrEqual(sheet.ColumnCountCallCount, 1, "Call count for ColumnCount property should be no more than 1");
        }

        [Test]
        public void Given_ActiveChangeProcessor_When_BeforeChangeCalled_Then_MethodsOnRangeCachedAndOnlyCalledOnce()
        {
            IChangeProcessor changeHandler = new ActiveChangeProcessor(new MockLoggingManager());
            changeHandler.AddHandler(new InactiveMockChangeHandler());
            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange();

            Assert.AreEqual(0, range.AddressCallCount, "Given: Call count for Address property should be 0 before running method");
            Assert.AreEqual(0, range.RowCountCallCount, "Given: Call count for RowCount property should be 0 before running method");
            Assert.AreEqual(0, range.ColumnCountCallCount, "Given: Call count for ColumnCount property should be 0 before running method");
            Assert.AreEqual(0, range.RangeDataCallCount, "Given: Call count for RangeData property should be 0 before running method");

            changeHandler.BeforeChange(sheet, range);

            Assert.LessOrEqual(range.AddressCallCount, 1, "Call count for Address property should be no more than 1");
            Assert.LessOrEqual(range.RowCountCallCount, 1, "Call count for RowCount property should be no more than 1");
            Assert.LessOrEqual(range.ColumnCountCallCount, 1, "Call count for ColumnCount property should be no more than 1");
            Assert.LessOrEqual(range.RangeDataCallCount, 1, "Call count for RangeData property should be no more than 1");
        }

        [Test]
        public void Given_ActiveChangeProcessor_When_AfterChangeCalled_Then_MethodsOnRangeCachedAndOnlyCalledOnce()
        {
            IChangeProcessor changeHandler = new ActiveChangeProcessor(new MockLoggingManager());
            changeHandler.AddHandler(new InactiveMockChangeHandler());
            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange();

            Assert.AreEqual(0, range.AddressCallCount, "Given: Call count for Address property should be 0 before running method");
            Assert.AreEqual(0, range.RowCountCallCount, "Given: Call count for RowCount property should be 0 before running method");
            Assert.AreEqual(0, range.ColumnCountCallCount, "Given: Call count for ColumnCount property should be 0 before running method");
            Assert.AreEqual(0, range.RangeDataCallCount, "Given: Call count for RangeData property should be 0 before running method");

            changeHandler.AfterChange(sheet, range);

            Assert.LessOrEqual(range.AddressCallCount, 1, "Call count for Address property should be no more than 1");
            Assert.LessOrEqual(range.RowCountCallCount, 1, "Call count for RowCount property should be no more than 1");
            Assert.LessOrEqual(range.ColumnCountCallCount, 1, "Call count for ColumnCount property should be no more than 1");
            Assert.LessOrEqual(range.RangeDataCallCount, 1, "Call count for RangeData property should be no more than 1");
        }
    }
}
