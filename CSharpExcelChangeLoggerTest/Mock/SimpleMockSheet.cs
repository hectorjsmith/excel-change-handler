using CSharpExcelChangeLogger.Excel;

namespace CSharpExcelChangeLoggerTest.Mock
{
    class SimpleMockSheet : IWorksheet
    {
        public string Name { get; set; }

        public int RowCount { get; set; }

        public int ColumnCount { get; set; }

        public SimpleMockSheet(string sheetName = "Mock worksheet")
        {
            Name = sheetName;
        }
    }
}
