using CSharpExcelChangeLogger.Excel;

namespace CSharpExcelChangeLoggerTest.Mock
{
    class SimpleMockRange : IRange
    {
        public string Address { get; set; } = "";

        public int RowCount { get; set; }

        public int ColumnCount { get; set; }

        public string[,] RangeData { get; set; } = new string[0, 0];

        public int FillColour { get; private set; }

        public void FillRange(int rgbColour)
        {
            FillColour = rgbColour;
        }
    }
}
