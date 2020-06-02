using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.Excel.Cached
{
    internal class CachedWorksheetWrapper : ICachedWorksheet
    {
        public IWorksheet RawWorksheet { get; }

        public CachedWorksheetWrapper(IWorksheet worksheet)
        {
            RawWorksheet = worksheet;
        }

        private string? _name;
        public string Name => _name ?? (_name = RawWorksheet.Name);

        private int? _rowCount;
        public int RowCount => _rowCount ?? (int)(_rowCount = RawWorksheet.RowCount);

        private int? _columnCount;
        public int ColumnCount => _columnCount ?? (int)(_columnCount = RawWorksheet.ColumnCount);
    }
}
