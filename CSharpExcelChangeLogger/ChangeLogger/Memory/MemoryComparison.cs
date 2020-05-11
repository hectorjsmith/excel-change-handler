namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    class MemoryComparison : IMemoryComparison
    {
        public bool LocationMatches { get; }
        public bool LocationMatchesAndDataChanged { get; }

        public MemoryComparison(bool locationMatches, bool locationMatchesAndDataChanged)
        {
            LocationMatches = locationMatches;
            LocationMatchesAndDataChanged = locationMatchesAndDataChanged;
        }
    }
}
