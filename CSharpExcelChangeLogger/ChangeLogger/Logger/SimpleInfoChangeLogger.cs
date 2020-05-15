using CSharpExcelChangeLogger.Base;
using CSharpExcelChangeLogger.ChangeLogger.Handler;
using CSharpExcelChangeLogger.ChangeLogger.Memory;
using CSharpExcelChangeLogger.Excel;
using CSharpExcelChangeLogger.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Logger
{
    class SimpleInfoChangeLogger : IChangeHandler
    {
        private readonly ILogger _logger;

        public SimpleInfoChangeLogger(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void HandleChange(IMemoryComparison memoryComparison, IWorksheet sheet, IRange range)
        {
            if (memoryComparison.IsNewRow)
            {
                _logger.Info(string.Format("New row added at {0} on sheet {1}", range.Address, sheet.Name));
            }
            else if (memoryComparison.IsNewColumn)
            {
                _logger.Info(string.Format("New column added at {0} on sheet {1}", range.Address, sheet.Name));
            }
            else if (memoryComparison.IsRowDelete)
            {
                _logger.Info(string.Format("Row deleted at {0} on sheet {1}", range.Address, sheet.Name));
            }
            else if (memoryComparison.IsColumnDelete)
            {
                _logger.Info(string.Format("Column deleted at {0} on sheet {1}", range.Address, sheet.Name));
            }
            else
            {
                _logger.Info(string.Format("Change detected at range {0} on sheet {1}", range.Address, sheet.Name));
            }
        }
    }
}
