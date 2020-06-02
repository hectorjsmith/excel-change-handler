using CSharpExcelChangeHandler.ChangeHandling.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeHandlerTest.Mock
{
    class SimpleMockMemoryComparison : IMemoryComparison
    {
        public bool LocationMatches { get; set; }

        public bool DataMatches { get; set; }

        public bool LocationMatchesAndDataMatches => LocationMatches && DataMatches;

        public bool IsNewRow { get; set; }

        public bool IsRowDelete { get; set; }

        public bool IsNewColumn { get; set; }

        public bool IsColumnDelete { get; set; }

        public string? RangeAddressBeforeChange { get; set; }

        public string? RangeAddressAfterChange { get; set; }

        public string? SheetNameBeforeChange { get; set; }

        public string? SheetNameAfterChange { get; set; }

        public string[,]? DataBeforeChange { get; set; }

        public string[,]? DataAfterChange { get; set; }
    }
}
