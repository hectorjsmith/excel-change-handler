using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLoggerTest.ChangeLogger.Handler
{
    class ActiveChangeHandlerTest
    {
        [Test]
        public void Given_ActiveChangeHandlerWithNoMemory_When_AfterChangeCalled_Then_ChangeHighlighted()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void Given_ActiveChangeHandlerWithMemory_When_AfterChangeCalledWithNoDataChange_Then_RangeNotHighlighted()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void Given_ActiveChangeHandlerWithMemory_When_AfterChangeCalledWithDataChanges_Then_RangeHighlighted()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void Given_ActiveChangeHandlerWithMemory_When_AfterChangeCalledWithDifferentRange_Then_RangeHighlighted()
        {
            Assert.Fail("Not implemented");
        }
    }
}
