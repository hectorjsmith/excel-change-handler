using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandler.Excel
{
    public interface IWorksheet
    {
        string Name { get; }
        int RowCount { get; }
        int ColumnCount { get; }
    }
}
