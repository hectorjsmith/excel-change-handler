using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Excel
{
    public interface IWorksheet
    {
        string Name { get; }
        int RowCount { get; }
        int ColumnCount { get; }
    }
}
