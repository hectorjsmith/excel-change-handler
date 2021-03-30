using ExcelChangeHandler.ChangeHandling.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelChangeHandlerTest.Mock
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

        public IChangeProperties? PropertiesBeforeChange { get; set; }

        public IChangeProperties PropertiesAfterChange { get; set; } = new ChangePropertiesImpl(null, null, null, null, null);
    }
}
