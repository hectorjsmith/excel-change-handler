using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.ChangeHandling.Factory
{
    public interface IChangeHandlerFactory
    {
        IChangeHandler NewSimpleChangeHighlighter(int highlightColour);

        IChangeHandler NewSimpleChangeLogger(ILogger logger);

        IChangeHandler NewSimpleChangeLogger();
    }
}
