using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Logging
{
    public interface ILogger
    {
        void Info(string message);

        void Error(string message, Exception ex);
    }
}
