using CSharpExcelChangeLogger.ChangeLogger.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLoggerTest.Mock
{
    class SimpleMockMemoryComparison : IMemoryComparison
    {
        public bool LocationMatches { get; set; }

        public bool DataMatches { get; set; }

        public bool LocationMatchesAndDataMatches => LocationMatches && DataMatches;

        public string[,]? SavedData { get; set; }

        public string[,]? NewData { get; set; }
    }
}
