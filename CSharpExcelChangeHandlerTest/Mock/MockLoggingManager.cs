using CSharpExcelChangeHandler.Base;
using CSharpExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandlerTest.Mock
{
    class MockLoggingManager : ILoggingManager
    {
        public ILogger Log { get; private set; } = new TestAppLogger();

        public void SetLogger(ILogger? logger)
        {
            Log = logger ?? new InactiveLogger();
        }
    }
}
