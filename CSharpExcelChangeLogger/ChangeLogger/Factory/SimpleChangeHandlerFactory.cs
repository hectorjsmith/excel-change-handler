using CSharpExcelChangeLogger.Base;
using CSharpExcelChangeLogger.ChangeLogger.Handler;
using CSharpExcelChangeLogger.ChangeLogger.Highlighter;
using CSharpExcelChangeLogger.ChangeLogger.Logger;
using CSharpExcelChangeLogger.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Factory
{
    class SimpleChangeHandlerFactory : BaseClass, IChangeHandlerFactory
    {
        public IChangeHandler NewSimpleChangeHighlighter(int highlightColour)
        {
            return new SimpleChangeHighlighter(highlightColour);
        }

        public IChangeHandler NewSimpleChangeLogger(ILogger logger)
        {
            return new SimpleInfoChangeLogger(logger);
        }

        public IChangeHandler NewSimpleChangeLogger()
        {
            return new SimpleInfoChangeLogger(Log);
        }
    }
}
