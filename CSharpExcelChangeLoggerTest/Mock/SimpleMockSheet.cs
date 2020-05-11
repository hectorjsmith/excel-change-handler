using CSharpExcelChangeLogger.Excel;

namespace CSharpExcelChangeLoggerTest.Mock
{
    class SimpleMockSheet : IWorksheet
    {
        public string Name { get; set; } = "Mock worksheet";

        public int RowCount { get; set; }

        public int ColumnCount { get; set; }
    }
}
