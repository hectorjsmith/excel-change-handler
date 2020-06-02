using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandlerTest.Mock
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
