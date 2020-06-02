using CSharpExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandlerTest.Mock
{
    class TestLogger : ILogger
    {
        public int DebugMessageCount {get; private set;}
        public int InfoMessageCount {get; private set;}
        public int ErrorMessageCount {get; private set;}

        public void Debug(string message)
        {
            DebugMessageCount++;
            Console.WriteLine("DEBUG " + message);
        }

        public void Info(string message)
        {
            InfoMessageCount++;
            Console.WriteLine("INFO  " + message);
        }

        public void Error(string message, Exception ex)
        {
            ErrorMessageCount++;
            Console.WriteLine("ERROR " + message);
            Console.WriteLine(ex);
        }
    }
}
