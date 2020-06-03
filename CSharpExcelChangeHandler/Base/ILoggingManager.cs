using CSharpExcelChangeHandler.Logging;

namespace CSharpExcelChangeHandler.Base
{
    internal interface ILoggingManager
    {
        ILogger Log { get; }

        void SetLogger(ILogger? logger);
    }
}