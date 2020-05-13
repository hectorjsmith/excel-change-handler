using CSharpExcelChangeLogger.ChangeLogger.Highlighter;
using CSharpExcelChangeLogger.Excel;
using CSharpExcelChangeLogger.Logging;

namespace CSharpExcelChangeLogger.Api
{
    public interface IChangeLoggerApi
    {
        IConfiguration Configuration { get; }

        void SetLogger(ILogger? logger);

        void BeforeChange(IWorksheet sheet, IRange range);

        void AfterChange(IWorksheet sheet, IRange range);

        void SetCustomHighlighter(IChangeHighlighter? highlighter);

        IChangeHighlighter NewSimpleChangeHighlighter(int highlightColour);
    }
}
