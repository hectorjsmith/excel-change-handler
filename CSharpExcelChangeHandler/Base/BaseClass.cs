using CSharpExcelChangeHandler.ChangeHandling;
using CSharpExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.Base
{
    class BaseClass
    {
        protected ILoggingManager LoggingManager { get; }
        protected ILogger Log => LoggingManager.Log;

        public BaseClass(ILoggingManager loggingManager)
        {
            LoggingManager = loggingManager;
        }
    }
}
