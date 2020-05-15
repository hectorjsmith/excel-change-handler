namespace CSharpExcelChangeLogger.Api
{
    class Configuration : IConfiguration
    {
        public bool ChangeHandlingEnabled { get; set; } = true;
    }
}
