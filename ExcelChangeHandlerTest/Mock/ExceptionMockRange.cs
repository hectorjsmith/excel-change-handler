using ExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandlerTest.Mock
{
    class ExceptionMockRange : IRange
    {
        public string Address => throw new NotImplementedException();

        public int RowCount => throw new NotImplementedException();

        public int ColumnCount => throw new NotImplementedException();

        public string[,] RangeData => throw new NotImplementedException();

        public void FillRange(int colour)
        {
            throw new NotImplementedException();
        }
    }
}
