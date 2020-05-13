namespace CSharpExcelChangeLogger.Api
{
    class Configuration : IConfiguration
    {
        public bool HighlighterEnabled { get; set; } = true;
        public int CellHighlightColour { get; set; } = 65535;
    }
}
