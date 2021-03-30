namespace ExcelChangeHandler.Api.Config
{
    class Configuration : IConfiguration
    {
        public bool ChangeHandlingEnabled { get; set; } = true;

        public int MaxMemorySize { get; set; } = 250_000;
    }
}
