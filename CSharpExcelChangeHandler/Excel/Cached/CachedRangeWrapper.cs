using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.Excel.Cached
{
    internal class CachedRangeWrapper : ICachedRange
    {
        public IRange RawRange { get; }

        public CachedRangeWrapper(IRange range)
        {
            RawRange = range;
        }

        private string? _address;
        public string Address => _address ?? (_address = RawRange.Address);

        private int? _rowCount;
        public int RowCount => _rowCount ?? (int)(_rowCount = RawRange.RowCount);

        private int? _columnCount;
        public int ColumnCount => _columnCount ?? (int)(_columnCount = RawRange.ColumnCount);

        private string[,]? _rangeData;
        public string[,] RangeData => _rangeData ?? (_rangeData = RawRange.RangeData);

        public void FillRange(int colour)
        {
            RawRange.FillRange(colour);
        }
    }
}
