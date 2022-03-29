using ExcelChangeHandler.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandlerTest.Mock
{
    class ExceptionMockSheet : IWorksheet
    {
        public string Name => throw new NotImplementedException();

        public int RowCount => throw new NotImplementedException();

        public int ColumnCount => throw new NotImplementedException();
    }
}
