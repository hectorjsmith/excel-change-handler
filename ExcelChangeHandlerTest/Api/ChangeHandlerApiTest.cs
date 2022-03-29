using ExcelChangeHandler.Api;
using ExcelChangeHandler.Api.Factory;
using ExcelChangeHandler.ChangeHandling.Handler;
using ExcelChangeHandler.ChangeHandling.Memory;
using ExcelChangeHandler.Excel;
using ExcelChangeHandlerTest.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandlerTest.Api
{
    class ChangeHandlerApiTest
    {
        [Test]
        public void Given_Api_When_BeforeAndAfterChangeHookCalledWithDataChange_Then_RangeIsHighlighted()
        {
            int testColour = 33;
            IChangeHandlerApi api = ChangeHandlerApiFactory.NewApiInstance();
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

        [Test]
        public void Given_ApiCreatedWithSpecificType_When_ValidChangeDetected_Then_HandlersGetTheExactSameObjects()
        {
            SimpleMockSheet mockSheet = new SimpleMockSheet();
            SimpleMockRange mockRange = new SimpleMockRange();

            IGenericChangeHandlerApi<SimpleMockSheet, SimpleMockRange> api = ChangeHandlerApiFactory.NewGenericApiInstance<SimpleMockSheet, SimpleMockRange>();
            GenericMockChangeHandler<SimpleMockSheet, SimpleMockRange> controlHandler = new GenericMockChangeHandler<SimpleMockSheet, SimpleMockRange>();
            IChangeHandler<SimpleMockSheet, SimpleMockRange> handler = new MockChangeHandlerWithCustomProcessing<SimpleMockSheet, SimpleMockRange>((memory, sheet, range) =>
            {
                Assert.AreSame(mockSheet, sheet, "Sheet object in handler should be the same as the object used when calling AfterChange");
                Assert.AreSame(mockRange, range, "Range object in handler should be the same as the object used when calling AfterChange");
            });
            api.AddCustomHandler(controlHandler);
            api.AddCustomHandler(handler);
            api.AfterChange(mockSheet, mockRange);

            Assert.IsTrue(controlHandler.HandleChangeCalled, "Control handler was not called. Test is invalid.");
        }

        [Test]
        public void Given_ApiSetupWithActionHandler_When_ValidChangeDetected_Then_ActionHandlerIsInvoked()
        {
            // Assemble
            bool actionInvoked = false;
            Action<IMemoryComparison, IWorksheet, IRange> action = (memory, sheet, range) => actionInvoked = true;

            SimpleMockSheet mockSheet = new SimpleMockSheet();
            SimpleMockRange mockRange = new SimpleMockRange();

            IGenericChangeHandlerApi<SimpleMockSheet, SimpleMockRange> api = ChangeHandlerApiFactory.NewGenericApiInstance<SimpleMockSheet, SimpleMockRange>();
            api.AddCustomHandler(action);

            // Act
            api.AfterChange(mockSheet, mockRange);

            // Assert
            Assert.IsTrue(actionInvoked, "Action should have been invoked when a valid change was detected");
        }
    }
}
