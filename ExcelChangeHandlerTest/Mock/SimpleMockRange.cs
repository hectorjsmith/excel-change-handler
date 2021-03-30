using ExcelChangeHandler.Excel;

namespace ExcelChangeHandlerTest.Mock
{
    class SimpleMockRange : IRange
    {
        private string[,] _rangeData = new string[0, 0];
        private string _address;
        private int _rowCount;
        private int _columnCount;

        public int AddressCallCount { get; private set; }
        public string Address { get { AddressCallCount++; return _address; } set => _address = value; }

        public int RowCountCallCount { get; private set; }
        public int RowCount { get { RowCountCallCount++; return _rowCount; } set => _rowCount = value; }

        public int ColumnCountCallCount { get; private set; }
        public int ColumnCount { get { ColumnCountCallCount++; return _columnCount; } set => _columnCount = value; }

        public int RangeDataCallCount { get; private set; }
        public string[,] RangeData { get { RangeDataCallCount++; return _rangeData; } set { _rangeData = value; RowCount = _rangeData.GetLength(0); ColumnCount = _rangeData.GetLength(1); } }

        public int FillColour { get; private set; } = 0;

        public void FillRange(int colour)
        {
            FillColour = colour;
        }

        public SimpleMockRange(string rangeAddress = "mock:address")
        {
            _address = rangeAddress;
        }
    }
}
