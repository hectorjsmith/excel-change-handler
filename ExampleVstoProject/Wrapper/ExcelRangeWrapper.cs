using System;
using Microsoft.Office.Interop.Excel;

namespace ExampleVstoProject.Wrapper
{
    class ExcelRangeWrapper : CSharpExcelChangeLogger.Excel.IRange
    {
        private readonly Range _range;

        public string Address => _range.Address;

        public int RowCount => _range.Rows.Count;

        public int ColumnCount => _range.Columns.Count;

        public string[,] RangeData => ConvertToStringArray2D(GetArray(_range, () => _range.Formula));

        public void FillRange(int rgbColour)
        {
            _range.Interior.Color = rgbColour;
        }

        public ExcelRangeWrapper(Range range)
        {
            _range = range ?? throw new ArgumentNullException(nameof(range));
        }

        private Array GetArray(Range range, Func<object> dataProducer)
        {
            if (range.Cells.Count == 0)
            {
                return Array.CreateInstance(typeof(Object), 0, 0);
            }
            if (range.Cells.Count == 1)
            {
                //Creating a 1-based array to fit with Excel's 1-based indexing
                Array retArray = OneBasedSingletonArray2D();
                retArray.SetValue(dataProducer.Invoke(), 1, 1);
                return retArray;
            }
            else
            {
                return (Array)dataProducer.Invoke();
            }
        }

        private string[,] ConvertToStringArray2D(Array values)
        {
            string[,] retArray = new string[values.GetLength(0), values.GetLength(1)];

            // loop through the 2-D System.Array and populate the 1-D String Array
            for (int row = 1; row <= values.GetLength(0); row++)
            {
                for (int col = 1; col <= values.GetLength(1); col++)
                {
                    if (values.GetValue(row, col) == null)
                    {
                        retArray[row - 1, col - 1] = "";
                    }
                    else
                    {
                        retArray[row - 1, col - 1] = values.GetValue(row, col).ToString();
                    }
                }
            }

            return retArray;
        }

        private Array OneBasedSingletonArray2D()
        {
            return Array.CreateInstance(typeof(Object), new int[] { 1, 1 }, new int[] { 1, 1 });
        }
    }
}
