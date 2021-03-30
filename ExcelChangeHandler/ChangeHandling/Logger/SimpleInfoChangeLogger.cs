using ExcelChangeHandler.Base;
using ExcelChangeHandler.ChangeHandling.Handler;
using ExcelChangeHandler.ChangeHandling.Memory;
using ExcelChangeHandler.Excel;
using ExcelChangeHandler.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelChangeHandler.ChangeHandling.Logger
{
    class SimpleInfoChangeLogger<TWorksheetType, TRangeType> : IChangeHandler<TWorksheetType, TRangeType>
        where TWorksheetType : IWorksheet where TRangeType : IRange
    {
        private readonly ILogger _logger;

        public SimpleInfoChangeLogger(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void HandleChange(IMemoryComparison memoryComparison, TWorksheetType sheet, TRangeType range)
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
