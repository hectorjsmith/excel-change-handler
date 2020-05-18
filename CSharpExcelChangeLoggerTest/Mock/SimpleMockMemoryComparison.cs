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

        public string[,]? DataBeforeChange { get; set; }

        public string[,]? DataAfterChange { get; set; }

        public bool IsNewRow { get; set; }

        public bool IsRowDelete { get; set; }

        public bool IsNewColumn { get; set; }

        public bool IsColumnDelete { get; set; }
    }
}
