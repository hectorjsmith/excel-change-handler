using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Logging
{
    class InactiveLogger : ILogger
    {
        public void Info(string message)
        {
        }

        public void Error(string message, Exception ex)
        {
        }
    }
}
