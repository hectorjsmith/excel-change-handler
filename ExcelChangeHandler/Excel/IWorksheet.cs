using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.Excel
{
    /// <summary>
    /// Interface that represents an Excel worksheet object. This interface should be implemented in "client code" to connect to an Excel worksheet object.
    /// </summary>
    public interface IWorksheet
    {
        /// <summary>
        /// Name of the worksheet.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Number of used rows on this worksheet.
        /// </summary>
        int RowCount { get; }

        /// <summary>
        /// Number of used columns on this worksheet.
        /// </summary>
        int ColumnCount { get; }
    }
}
