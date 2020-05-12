using CSharpExcelChangeLogger.Excel;

namespace CSharpExcelChangeLoggerTest.Mock
{
    class SimpleMockRange : IRange
    {
        public string Address { get; set; }

        public int RowCount => RangeData.GetLength(0);

        public int ColumnCount => RangeData.GetLength(1);

        public string[,] RangeData { get; set; } = new string[0, 0];

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
