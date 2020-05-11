using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExcelChangeLogger.Api
{
    public interface IConfiguration
    {
        int CellHighlightRgbColour { get; set; }
    }

    class Configuration : IConfiguration
    {
        public int CellHighlightRgbColour { get; set; }
    }
}
