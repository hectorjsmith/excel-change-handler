using CSharpExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.Base
{
    internal class LoggingManager : ILoggingManager
    {
        private readonly ILogger _inactiveLogger = new InactiveLogger();
        private ILogger? _injectedLogger;

        public ILogger Log => _injectedLogger ?? _inactiveLogger;

        public void SetLogger(ILogger? logger)
        {
            _injectedLogger = logger;
        }
    }
}
