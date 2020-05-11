using CSharpExcelChangeLogger.Api;
using CSharpExcelChangeLogger.ChangeLogger.Highlighter;
using CSharpExcelChangeLoggerTest.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLoggerTest.ChangeLogger.Highlighter
{
    class ActiveChangeHighlighterTest
    {
        [Test]
        public void GivenApiWhenAfterChangeHookCalledThenRangeIsHighlighted()
        {
            int testColour = 111;
            ChangeLoggerApi.Instance.Configuration.CellHighlightRgbColour = testColour;
            ChangeLoggerApi.Instance.SetLogger(new TestLogger());

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange();

            ChangeLoggerApi.Instance.AfterChange(sheet, range);

            Assert.AreEqual(testColour, range.FillColour, "Range should be filled with correct colour");
        }

        [Test]
        public void GivenActiveChangeLoggerWhenAfterChangeHookCalledThenRangeIsHighlighted()
        {
            int testColour = 111;
            ChangeLoggerApi.Instance.Configuration.CellHighlightRgbColour = testColour;
            ChangeLoggerApi.Instance.SetLogger(new TestLogger());

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange();

            IChangeHighlighter highlighter = new ActiveChangeHighlighter();
            highlighter.AfterChange(sheet, range);

            Assert.AreEqual(testColour, range.FillColour, "Range should be filled with correct colour");
        }
    }
}
