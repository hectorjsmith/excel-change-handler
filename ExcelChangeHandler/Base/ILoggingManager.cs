using ExcelChangeHandler.Logging;

namespace ExcelChangeHandler.Base
{
    internal interface ILoggingManager
    {
        ILogger Log { get; }

        void SetLogger(ILogger? logger);
    }
}