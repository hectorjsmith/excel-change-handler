using CSharpExcelChangeLogger.Api;
using CSharpExcelChangeLogger.ChangeLogger.Processor;
using CSharpExcelChangeLogger.ChangeLogger.Highlighter;
using CSharpExcelChangeLogger.ChangeLogger.Handler;
using CSharpExcelChangeLoggerTest.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLoggerTest.ChangeLogger.Handler
{
    class ActiveChangeProcessorTest
    {
        [Test]
        public void Given_ActiveChangeProcessorWithNoMemory_When_AfterChangeCalled_Then_ChangeHighlighted()
        {
            int testColour = 111;
            IChangeProcessor changeHandler = new ActiveChangeProcessor();
            changeHandler.AddHandler(new SimpleChangeHighlighter(testColour));

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange();

            changeHandler.AfterChange(sheet, range);

            Assert.AreEqual(testColour, range.FillColour, "Range should be highlighted if no memory was set");
        }

        [Test]
        public void Given_ActiveChangeProcessorWithMemory_When_AfterChangeCalledWithNoDataChange_Then_RangeNotHighlighted()
        {
            int testColour = 111;
            IChangeProcessor changeHandler = new ActiveChangeProcessor();
            changeHandler.AddHandler(new SimpleChangeHighlighter(testColour));

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
            IChangeProcessor changeHandler = new ActiveChangeProcessor();
            changeHandler.AddHandler(new SimpleChangeHighlighter(testColour));

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
            IChangeProcessor changeHandler = new ActiveChangeProcessor();
            changeHandler.AddHandler(new SimpleChangeHighlighter(testColour));

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range1 = new SimpleMockRange("1");
            SimpleMockRange range2 = new SimpleMockRange("2");

            changeHandler.BeforeChange(sheet, range1);
            changeHandler.AfterChange(sheet, range2);

            Assert.AreEqual(testColour, range2.FillColour, "Range should be highlighted if address is different");
        }
    }
}
