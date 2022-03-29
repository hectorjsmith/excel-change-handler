using ExcelChangeHandler.Excel.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.Excel.Cached
{
    internal class CachedRangeWrapper : ICachedRange
    {
        public IRange RawRange { get; }

        public CachedRangeWrapper(IRange range)
        {
            RawRange = range;
        }

        private string? _address;
        public string Address => _address ?? (_address = ExcelAccessProtection.ReadDataAndWrapException(nameof(RawRange.Address), () => RawRange.Address));

        private int? _rowCount;
        public int RowCount => _rowCount ?? (int)(_rowCount = ExcelAccessProtection.ReadDataAndWrapException(nameof(RawRange.RowCount), () => RawRange.RowCount));

        private int? _columnCount;
        public int ColumnCount => _columnCount ?? (int)(_columnCount = ExcelAccessProtection.ReadDataAndWrapException(nameof(RawRange.ColumnCount), () => RawRange.ColumnCount));

        private string[,]? _rangeData;
        public string[,] RangeData => _rangeData ?? (_rangeData = ExcelAccessProtection.ReadDataAndWrapException(nameof(RawRange.RangeData), () => RawRange.RangeData));

        public void FillRange(int colour)
        {
            ExcelAccessProtection.RunActionAndWrapException(nameof(RawRange.FillRange), () => RawRange.FillRange(colour));
        }
    }
}
