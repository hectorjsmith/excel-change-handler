using System;

namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    class MemoryComparison : IMemoryComparison
    {
        public bool LocationMatches { get; }

        public bool DataMatches { get; }

        public bool IsNewRow { get; }

        public bool IsRowDelete { get; }

        public bool IsNewColumn { get; }

        public bool IsColumnDelete { get; }

        public bool LocationMatchesAndDataMatches => LocationMatches && DataMatches;

        public string? RangeAddressBeforeChange { get; }

        public string? RangeAddressAfterChange { get; }

        public string? SheetNameBeforeChange { get; }

        public string? SheetNameAfterChange { get; }

        public string[,]? DataBeforeChange { get; }

        public string[,]? DataAfterChange { get; }

        public MemoryComparison(bool locationMatches,
                                bool dataMatches,
                                bool isNewRow,
                                bool isRowDelete,
                                bool isNewColumn,
                                bool isColumnDelete,
                                string? rangeAddressBeforeChange,
                                string? rangeAddressAfterChange,
                                string? sheetNameBeforeChange,
                                string? sheetNameAfterChange,
                                string[,]? dataBeforeChange,
                                string[,]? dataAfterChange)
        {
            LocationMatches = locationMatches;
            DataMatches = dataMatches;
            IsNewRow = isNewRow;
            IsRowDelete = isRowDelete;
            IsNewColumn = isNewColumn;
            IsColumnDelete = isColumnDelete;
            RangeAddressBeforeChange = rangeAddressBeforeChange;
            RangeAddressAfterChange = rangeAddressAfterChange;
            SheetNameBeforeChange = sheetNameBeforeChange;
            SheetNameAfterChange = sheetNameAfterChange;
            DataBeforeChange = dataBeforeChange;
            DataAfterChange = dataAfterChange;
        }
    }
}
