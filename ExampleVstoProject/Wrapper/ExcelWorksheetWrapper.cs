using CSharpExcelChangeLogger.Excel;
using Microsoft.Office.Interop.Excel;
using System;

namespace ExampleVstoProject.Wrapper
{
    class ExcelWorksheetWrapper : IWorksheet
    {
        private readonly Worksheet _worksheet;

        public string Name => _worksheet.Name;

        public int RowCount => _worksheet.Rows.Count;

        public int ColumnCount => _worksheet.Columns.Count;

        public ExcelWorksheetWrapper(Worksheet worksheet)
        {
            _worksheet = worksheet ?? throw new ArgumentNullException(nameof(worksheet));
        }
    }
}
