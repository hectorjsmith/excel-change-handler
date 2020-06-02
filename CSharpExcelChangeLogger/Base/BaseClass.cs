using CSharpExcelChangeHandler.ChangeHandling;
using CSharpExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.Base
{
    class BaseClass
    {
        protected ILogger Log => StaticLoggingManager.Log;
    }
}
