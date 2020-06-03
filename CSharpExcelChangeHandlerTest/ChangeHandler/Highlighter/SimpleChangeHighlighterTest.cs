using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.ChangeHandling.Highlighter;
using CSharpExcelChangeHandler.Excel;
using CSharpExcelChangeHandlerTest.Mock;
using NUnit.Framework;

namespace CSharpExcelChangeHandlerTest.ChangeHandler.Highlighter
{
    class SimpleChangeHighlighterTest
    {
        [Test]
        public void Given_SimpleChangeHighlighter_When_HandleChangeMethodCalled_Then_RangeIsHighlighted()
        {
            int testColour = 111;

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange();

            IChangeHandler<IWorksheet, IRange> highlighter = new SimpleChangeHighlighter<IWorksheet, IRange>(new MockLoggingManager(), testColour);
            highlighter.HandleChange(new SimpleMockMemoryComparison(), sheet, range);

            Assert.AreEqual(testColour, range.FillColour, "Range should be filled with correct colour");
        }
    }
}
