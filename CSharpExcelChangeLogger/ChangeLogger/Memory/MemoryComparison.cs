namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    class MemoryComparison : IMemoryComparison
    {
        public bool LocationMatches { get; }

        public bool DataMatches { get; }

        public bool LocationMatchesAndDataMatches => LocationMatches && DataMatches;

        public MemoryComparison(bool locationMatches, bool dataMatches)
        {
            LocationMatches = locationMatches;
            DataMatches = dataMatches;
        }
    }
}
