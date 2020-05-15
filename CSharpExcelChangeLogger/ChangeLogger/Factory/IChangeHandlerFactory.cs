using CSharpExcelChangeLogger.ChangeLogger.Handler;
using CSharpExcelChangeLogger.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Factory
{
    public interface IChangeHandlerFactory
    {
        IChangeHandler NewSimpleChangeHighlighter(int highlightColour);

        IChangeHandler NewSimpleChangeLogger(ILogger logger);

        IChangeHandler NewSimpleChangeLogger();
    }
}
