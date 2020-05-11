using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.ChangeLogger.Memory
{
    internal interface IMemoryComparison
    {
        bool LocationMatches { get; }
        bool LocationMatchesAndDataMatches { get; }
    }
}
