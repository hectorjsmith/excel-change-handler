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

        public string[,]? DataBeforeChange { get; }

        public string[,]? DataAfterChange { get; }

        public MemoryComparison(
            bool locationMatches, bool dataMatches, 
            bool isNewRow, bool isRowDelete, bool isNewColumn, bool isColumnDelete, 
            string[,]? dataBeforeChange, string[,]? dataAfterChange)
        {
            LocationMatches = locationMatches;
            DataMatches = dataMatches;
            IsNewRow = isNewRow;
            IsRowDelete = isRowDelete;
            IsNewColumn = isNewColumn;
            IsColumnDelete = isColumnDelete;
            DataBeforeChange = dataBeforeChange;
            DataAfterChange = dataAfterChange;
        }
    }
}
