namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    class MemoryComparison : IMemoryComparison
    {
        public bool LocationMatches { get; }

        public bool DataMatches { get; }

        public bool LocationMatchesAndDataMatches => LocationMatches && DataMatches;

        public string[,]? SavedData { get; }

        public string[,]? NewData { get; }

        public MemoryComparison(bool locationMatches, bool dataMatches, string[,]? savedData, string[,]? newData)
        {
            LocationMatches = locationMatches;
            DataMatches = dataMatches;
            SavedData = savedData;
            NewData = newData;
        }
    }
}
