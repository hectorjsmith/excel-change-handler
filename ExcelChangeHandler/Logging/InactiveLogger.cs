using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.Logging
{
    class InactiveLogger : ILogger
    {
        public void Debug(string message)
        {
        }

        public void Info(string message)
        {
        }

        public void Error(string message, Exception ex)
        {
        }
    }
}
