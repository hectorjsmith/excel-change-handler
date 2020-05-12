using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    public interface IMemoryComparison
    {
        bool LocationMatches { get; }
        bool DataMatches { get; }
        bool LocationMatchesAndDataMatches { get; }
        string[,]? SavedData { get; }
        string[,]? NewData { get; }
    }
}
