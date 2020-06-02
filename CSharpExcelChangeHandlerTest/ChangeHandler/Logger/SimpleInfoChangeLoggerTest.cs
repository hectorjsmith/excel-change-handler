using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.ChangeHandling.Logger;
using CSharpExcelChangeHandler.Excel;
using CSharpExcelChangeHandlerTest.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandlerTest.ChangeHandler.Logger
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
