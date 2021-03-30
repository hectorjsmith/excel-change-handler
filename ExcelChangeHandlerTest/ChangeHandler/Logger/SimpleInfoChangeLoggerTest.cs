using ExcelChangeHandler.ChangeHandling.Handler;
using ExcelChangeHandler.ChangeHandling.Logger;
using ExcelChangeHandler.Excel;
using ExcelChangeHandlerTest.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandlerTest.ChangeHandler.Logger
{
    class SimpleInfoChangeLoggerTest
    {
        [Test]
        public void Given_SimpleChangeLogger_When_HandleChangeMethodCalled_Then_ChangeIsLogged()
        {
            TestAppLogger logger = new TestAppLogger();
            
            IChangeHandler<IWorksheet, IRange> highlighter = new SimpleInfoChangeLogger<IWorksheet, IRange>(logger);
            highlighter.HandleChange(new SimpleMockMemoryComparison(), new SimpleMockSheet(), new SimpleMockRange());

            Assert.AreEqual(1, logger.InfoMessageCount, "One info message should be logged for a change");
        }
    }
}
