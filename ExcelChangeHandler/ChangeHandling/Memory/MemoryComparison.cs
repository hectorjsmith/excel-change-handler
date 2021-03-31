using System;

namespace ExcelChangeHandler.ChangeHandling.Memory
{
    class MemoryComparison : IMemoryComparison
    {
        public bool HasSheetSizeChanged { get; }

        public bool IsNewRow { get; }

        public bool IsRowDelete { get; }

        public bool IsNewColumn { get; }

        public bool IsColumnDelete { get; }

        public bool LocationMatches { get; }

        public bool LocationMatchesAndDataMatches { get; }

        public IChangeProperties? PropertiesBeforeChange { get; }

        public IChangeProperties PropertiesAfterChange { get; }


        public MemoryComparison(bool isNewRow,
                                bool isRowDelete,
                                bool isNewColumn,
                                bool isColumnDelete,
                                bool locationMatches,
                                bool dataMatches,
                                IChangeProperties? propertiesBeforeChange,
                                IChangeProperties propertiesAfterChange)
        {
            HasSheetSizeChanged = isNewRow || isRowDelete || isNewColumn || isColumnDelete;
            IsNewRow = isNewRow;
            IsRowDelete = isRowDelete;
            IsNewColumn = isNewColumn;
            IsColumnDelete = isColumnDelete;
            LocationMatches = locationMatches;
            LocationMatchesAndDataMatches = locationMatches && dataMatches;
            PropertiesBeforeChange = propertiesBeforeChange;
            PropertiesAfterChange = propertiesAfterChange ?? throw new ArgumentNullException(nameof(propertiesAfterChange));
        }
    }
}
