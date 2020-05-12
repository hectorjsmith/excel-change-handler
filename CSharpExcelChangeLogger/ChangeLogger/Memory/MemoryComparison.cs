namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    class MemoryComparison : IMemoryComparison
    {
        public bool LocationMatches { get; }

        public bool DataMatches { get; }

        public bool LocationMatchesAndDataMatches => LocationMatches && DataMatches;

        public string[,]? DataBeforeChange { get; }

        public string[,]? DataAfterChange { get; }

        public MemoryComparison(bool locationMatches, bool dataMatches, string[,]? dataBeforeChange, string[,]? dataAfterChange)
        {
            LocationMatches = locationMatches;
            DataMatches = dataMatches;
            DataBeforeChange = dataBeforeChange;
            DataAfterChange = dataAfterChange;
        }
    }
}
