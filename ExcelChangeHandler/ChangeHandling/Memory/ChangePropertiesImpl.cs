using System;

namespace ExcelChangeHandler.ChangeHandling.Memory
{
    class ChangePropertiesImpl : IChangeProperties
    {
        public string? SheetName { get; }

        public int? SheetColumns { get; }

        public int? SheetRows { get; }

        public string? RangeAddress { get; }

        public string[,]? RangeFormulas { get; }

        public ChangePropertiesImpl(string? sheetName, int? sheetColumns, int? sheetRows, string? rangeAddress, string[,]? rangeFormulas)
        {
            SheetName = sheetName;
            SheetColumns = sheetColumns;
            SheetRows = sheetRows;
            RangeAddress = rangeAddress;
            RangeFormulas = rangeFormulas;
        }
    }
}
