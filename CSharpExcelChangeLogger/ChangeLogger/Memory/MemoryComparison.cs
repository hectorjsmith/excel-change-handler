namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    class MemoryComparison : IMemoryComparison
    {
        public bool LocationMatches { get; }
        public bool LocationMatchesAndDataMatches { get; }

        public MemoryComparison(bool locationMatches, bool locationMatchesAndDataMatches)
        {
            LocationMatches = locationMatches;
            LocationMatchesAndDataMatches = locationMatchesAndDataMatches;
        }
    }
}
