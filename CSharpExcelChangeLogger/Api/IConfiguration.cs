using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Api
{
    public interface IConfiguration
    {
        int CellHighlightColour { get; set; }
    }

    class Configuration : IConfiguration
    {
        public int CellHighlightColour { get; set; }
    }
}
