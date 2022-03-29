using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandler.Excel
{
    /// <summary>
    /// Interface that represents an Excel range object. This interface should be implemented in "client code" to connect to an Excel range object.
    /// </summary>
    public interface IRange
    {
        /// <summary>
        /// Address of this range.
        /// </summary>
        string Address { get; }

        /// <summary>
        /// Number of rows contained in this range.
        /// </summary>
        int RowCount { get; }

        /// <summary>
        /// Number of columns contained in this range.
        /// </summary>
        int ColumnCount { get; }

        /// <summary>
        /// Two-dimensional array of data stored in this range. The size of the array should match up with <see cref="RowCount"/> and <see cref="ColumnCount"/>.
        /// </summary>
        string[,] RangeData { get; }

        /// <summary>
        /// Fill this range with the provided colour.
        /// </summary>
        void FillRange(int colour);
    }
}
