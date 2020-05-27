using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Excel.Cached
{
    internal class CachedRangeWrapper : IRange
    {
        private readonly IRange _delegate;

        public CachedRangeWrapper(IRange range)
        {
            _delegate = range;
        }

        private string? _address;
        public string Address => _address ?? (_address = _delegate.Address);

        private int? _rowCount;
        public int RowCount => _rowCount ?? (int)(_rowCount = _delegate.RowCount);

        private int? _columnCount;
        public int ColumnCount => _columnCount ?? (int)(_columnCount = _delegate.ColumnCount);

        private string[,]? _rangeData;
        public string[,] RangeData => _rangeData ?? (_rangeData = _delegate.RangeData);

        public void FillRange(int colour)
        {
            _delegate.FillRange(colour);
        }
    }
}
