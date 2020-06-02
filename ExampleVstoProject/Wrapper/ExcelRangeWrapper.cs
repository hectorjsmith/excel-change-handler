using System;
using Microsoft.Office.Interop.Excel;

namespace ExampleVstoProject.Wrapper
{
    class ExcelRangeWrapper : CSharpExcelChangeHandler.Excel.IRange
    {
        private readonly Range _range;

        public string Address => _range.Address;

        public int RowCount => _range.Rows.Count;

        public int ColumnCount => _range.Columns.Count;

        public string[,] RangeData => ConvertToStringArray2D(GetArray(_range, () => _range.Formula));

        public void FillRange(int colour)
        {
            _range.Interior.Color = colour;
        }

        public ExcelRangeWrapper(Range range)
        {
            _range = range ?? throw new ArgumentNullException(nameof(range));
        }

        private Array GetArray(Range range, Func<object> dataProducer)
        {
            if (range.Cells.Count == 0)
            {
                // Create empty array if range is empty
                return Array.CreateInstance(typeof(object), 0, 0);
            }
            if (range.Cells.Count == 1)
            {
                // If the range has a single cell it will return one value, not an array.
                // Wrapping this into a 2-dimensional 1-based array with a single entry.
                Array retArray = OneBasedSingletonArray2D();
                retArray.SetValue(dataProducer.Invoke(), 1, 1);
                return retArray;
            }
            else
            {
                // Return the range data as an Array. If a range has > 1 cell it returns a 2-dimensional array of data.
                return (Array)dataProducer.Invoke();
            }
        }

        private string[,] ConvertToStringArray2D(Array values)
        {
            string[,] retArray = new string[values.GetLength(0), values.GetLength(1)];

            // Loop through the 1-based System.Array and populate the 0-based string array
            for (int oneBasedRow = 1; oneBasedRow <= values.GetLength(0); oneBasedRow++)
            {
                int zeroBasedRow = oneBasedRow - 1;
                for (int oneBasedCol = 1; oneBasedCol <= values.GetLength(1); oneBasedCol++)
                {
                    int zeroBasedCol = oneBasedCol - 1;
                    if (values.GetValue(oneBasedRow, oneBasedCol) == null)
                    {
                        retArray[zeroBasedRow, zeroBasedCol] = "";
                    }
                    else
                    {
                        retArray[zeroBasedRow, zeroBasedCol] = values.GetValue(oneBasedRow, oneBasedCol).ToString();
                    }
                }
            }

            return retArray;
        }

        private Array OneBasedSingletonArray2D()
        {
            return Array.CreateInstance(typeof(object), new int[] { 1, 1 }, new int[] { 1, 1 });
        }
    }
}
