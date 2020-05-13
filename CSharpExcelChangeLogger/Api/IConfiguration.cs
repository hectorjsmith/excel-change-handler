using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Api
{
    public interface IConfiguration
    {
        bool HighlighterEnabled { get; set; }
        int CellHighlightColour { get; set; }
    }

    class Configuration : IConfiguration
    {
        public bool HighlighterEnabled { get; set; }
        public int CellHighlightColour { get; set; }
    }
}
