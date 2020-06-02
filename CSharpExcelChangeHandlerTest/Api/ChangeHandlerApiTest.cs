using CSharpExcelChangeHandler.Api;
using CSharpExcelChangeHandler.Excel;
using CSharpExcelChangeHandlerTest.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandlerTest.Api
{
    class ChangeHandlerApiTest
    {
        [Test]
        public void Given_Api_When_BeforeAndAfterChangeHookCalledWithDataChange_Then_RangeIsHighlighted()
        {
            int testColour = 33;
            IChangeHandlerApi<IWorksheet, IRange> api = ChangeHandlerApi<IWorksheet, IRange>.NewInstance();
            api.AddCustomHandler(api.ChangeHandlerFactory.NewSimpleChangeHighlighter(testColour));
            api.SetApplicationLogger(new TestAppLogger());

            SimpleMockSheet sheet = new SimpleMockSheet();
            SimpleMockRange rangeBefore = new SimpleMockRange();
            rangeBefore.RangeData = new string[2, 2] { { "one", "two" }, { "three", "four" } };
            api.BeforeChange(sheet, rangeBefore);

            SimpleMockRange rangeAfter = new SimpleMockRange();
            rangeAfter.RangeData = new string[2, 2] { { "1", "2" }, { "3", "4" } };
            api.AfterChange(sheet, rangeAfter);

            Assert.AreEqual(testColour, rangeAfter.FillColour, "Range should be filled with correct colour when no memory set");
        }
    }
}
