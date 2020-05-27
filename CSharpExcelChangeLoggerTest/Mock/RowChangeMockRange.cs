using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLoggerTest.Mock
{
    class RowChangeMockRange : SimpleMockRange
    {
        public RowChangeMockRange()
        {
            ColumnCount = 16384;
            RowCount = 1;
        }
    }
}
