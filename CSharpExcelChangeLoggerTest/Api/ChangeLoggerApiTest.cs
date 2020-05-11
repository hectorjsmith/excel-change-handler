using CSharpExcelChangeLogger.Api;
using CSharpExcelChangeLoggerTest.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLoggerTest.Api
{
    class ChangeLoggerApiTest
    {
        [Test]
        public void Given_Api_When_AfterChangeHookCalled_Then_RangeIsHighlighted()
        {
            int testColour = 33;
            IChangeLoggerApi api = ChangeLoggerApi.Instance;
            api.Configuration.CellHighlightRgbColour = testColour;
            api.SetLogger(new TestLogger());

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange range = new SimpleMockRange();

            api.AfterChange(sheet, range);

            Assert.AreEqual(testColour, range.FillColour, "Range should be filled with correct colour when no memory set");
        }

    }
}
