using CSharpExcelChangeLogger.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLoggerTest.Mock
{
    class TestLogger : ILogger
    {
        public void Debug(string message)
        {
            Console.WriteLine("DEBUG " + message);
        }

        public void Info(string message)
        {
            Console.WriteLine("INFO  " + message);
        }

        public void Error(string message, Exception ex)
        {
            Console.WriteLine("ERROR " + message);
            Console.WriteLine(ex);
        }
    }
}
