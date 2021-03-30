using ExcelChangeHandler.Base;
using ExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandlerTest.Mock
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
