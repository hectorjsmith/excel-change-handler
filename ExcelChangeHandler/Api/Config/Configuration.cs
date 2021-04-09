namespace ExcelChangeHandler.Api.Config
{
    class Configuration : IConfiguration
    {
        public bool ChangeHandlingEnabled { get; set; } = true;

        public long MaxMemorySize { get; set; } = 250_000;
    }
}
