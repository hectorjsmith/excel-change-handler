using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Excel.Cached
{
    internal class CachedWorksheetWrapper : IWorksheet
    {
        private readonly IWorksheet _delegate;

        public CachedWorksheetWrapper(IWorksheet worksheet)
        {
            _delegate = worksheet;
        }

        private string? _name;
        public string Name => _name ?? (_name = _delegate.Name);

        private int? _rowCount;
        public int RowCount => _rowCount ?? (int)(_rowCount = _delegate.RowCount);

        private int? _columnCount;
        public int ColumnCount => _columnCount ?? (int)(_columnCount = _delegate.ColumnCount);
    }
}
