using CSharpExcelChangeHandler.Base;
using CSharpExcelChangeHandler.ChangeHandling.Handler;
using CSharpExcelChangeHandler.ChangeHandling.Highlighter;
using CSharpExcelChangeHandler.ChangeHandling.Logger;
using CSharpExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.ChangeHandling.Factory
{
    class SimpleChangeHandlerFactory : BaseClass, IChangeHandlerFactory
    {
        public SimpleChangeHandlerFactory(ILoggingManager loggingManager) : base(loggingManager)
        {
        }

        public IChangeHandler NewSimpleChangeHighlighter(int highlightColour)
        {
            return new SimpleChangeHighlighter(LoggingManager, highlightColour);
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
