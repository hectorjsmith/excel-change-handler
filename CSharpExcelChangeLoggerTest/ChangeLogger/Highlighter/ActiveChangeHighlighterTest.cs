using CSharpExcelChangeLogger.ChangeLogger.Handler;
using CSharpExcelChangeLogger.ChangeLogger.Highlighter;
using CSharpExcelChangeLoggerTest.Mock;
using NUnit.Framework;

namespace CSharpExcelChangeLoggerTest.ChangeLogger.Highlighter
{
    class ActiveChangeHighlighterTest
    {
        [Test]
        public void Given_ActiveChangeHighlighter_When_HighlightRangeMethodCalled_Then_RangeIsHighlighted()
        {
            int testColour = 111;

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange();

            IChangeHandler highlighter = new SimpleChangeHighlighter(testColour);
            highlighter.HandleChange(new SimpleMockMemoryComparison(), sheet, range);

            Assert.AreEqual(testColour, range.FillColour, "Range should be filled with correct colour");
        }
    }
}
