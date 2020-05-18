using CSharpExcelChangeLogger.Excel;

namespace CSharpExcelChangeLoggerTest.Mock
{
    class SimpleMockRange : IRange
    {
        private string[,] rangeData = new string[0, 0];

        public string Address { get; set; }

        public int RowCount { get; set; }

        public int ColumnCount { get; set; }

        public string[,] RangeData { get => rangeData; set { rangeData = value; RowCount = rangeData.GetLength(0); ColumnCount = rangeData.GetLength(1); } }
        public int FillColour { get; private set; } = 0;

        public void FillRange(int colour)
        {
            FillColour = colour;
        }

        public SimpleMockRange(string rangeAddress = "mock:address")
        {
            Address = rangeAddress;
        }
    }
}
