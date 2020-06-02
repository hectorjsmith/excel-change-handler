using CSharpExcelChangeHandler.Excel;
using Microsoft.Office.Interop.Excel;
using System;

namespace ExampleVstoProject.Wrapper
{
    class ExcelWorksheetWrapper : IWorksheet
    {
        private readonly Worksheet _worksheet;

        public string Name => _worksheet.Name;

        public int RowCount => _worksheet.UsedRange.Rows.Count;

        public int ColumnCount => _worksheet.UsedRange.Columns.Count;

        public ExcelWorksheetWrapper(Worksheet worksheet)
        {
            _worksheet = worksheet ?? throw new ArgumentNullException(nameof(worksheet));
        }
    }
}
