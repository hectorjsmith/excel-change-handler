using CSharpExcelChangeLogger.Excel;

namespace CSharpExcelChangeLoggerTest.Mock
{
    class SimpleMockSheet : IWorksheet
    {
        private string _name;
        private int _rowCount;
        private int _columnCount;

        public int NameCallCount { get; private set; }
        public string Name { get { NameCallCount++; return _name; } set => _name = value; }

        public int RowCountCallCount { get; private set; }
        public int RowCount { get { RowCountCallCount++; return _rowCount; } set => _rowCount = value; }

        public int ColumnCountCallCount { get; private set; }
        public int ColumnCount { get { ColumnCountCallCount++; return _columnCount; } set => _columnCount = value; }

        public SimpleMockSheet(string sheetName = "Mock worksheet")
        {
            _name = sheetName;
        }
    }
}
