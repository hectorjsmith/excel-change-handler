using CSharpExcelChangeLogger.ChangeLogger;
using CSharpExcelChangeLogger.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Base
{
    class BaseClass
    {
        protected ILogger Log => StaticChangeLoggerManager.Log;
    }
}
