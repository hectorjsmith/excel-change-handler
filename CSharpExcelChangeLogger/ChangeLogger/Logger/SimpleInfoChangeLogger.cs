using CSharpExcelChangeLogger.Base;
using CSharpExcelChangeLogger.ChangeLogger.Handler;
using CSharpExcelChangeLogger.ChangeLogger.Memory;
using CSharpExcelChangeLogger.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Logger
{
    class SimpleInfoChangeLogger : BaseClass, IChangeHandler
    {
        public void HandleChange(IMemoryComparison memoryComparison, IWorksheet sheet, IRange range)
        {
            if (memoryComparison.IsNewRow)
            {
                Log.Info(string.Format("New row added at {0} on sheet {1}", range.Address, sheet.Name));
            }
            else if (memoryComparison.IsNewColumn)
            {
                Log.Info(string.Format("New column added at {0} on sheet {1}", range.Address, sheet.Name));
            }
            else if (memoryComparison.IsRowDelete)
            {
                Log.Info(string.Format("Row deleted at {0} on sheet {1}", range.Address, sheet.Name));
            }
            else if (memoryComparison.IsColumnDelete)
            {
                Log.Info(string.Format("Column deleted at {0} on sheet {1}", range.Address, sheet.Name));
            }
            else
            {
                Log.Info(string.Format("Change detected at range {0} on sheet {1}", range.Address, sheet.Name));
            }
        }
    }
}
