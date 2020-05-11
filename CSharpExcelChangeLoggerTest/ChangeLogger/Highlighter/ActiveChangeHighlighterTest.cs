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
        public void Given_ActiveChangeLogger_When_AfterChangeHookCalled_Then_RangeIsHighlighted()
        {
            int testColour = 111;
            IChangeLoggerApi api = ChangeLoggerApi.Instance;
            api.Configuration.CellHighlightRgbColour = testColour;
            api.SetLogger(new TestLogger());

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange();

            IChangeHighlighter highlighter = new ActiveChangeHighlighter();
            highlighter.HighlightRange(sheet, range);

            Assert.AreEqual(testColour, range.FillColour, "Range should be filled with correct colour");
        }
    }
}
