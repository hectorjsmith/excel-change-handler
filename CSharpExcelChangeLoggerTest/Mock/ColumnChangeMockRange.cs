using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLoggerTest.Mock
{
    class ColumnChangeMockRange : SimpleMockRange
    {
        public ColumnChangeMockRange()
        {
            ColumnCount = 1;
            RowCount = 1048576;
        }
    }
}
