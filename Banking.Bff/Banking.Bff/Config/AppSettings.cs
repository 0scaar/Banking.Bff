namespace Banking.Bff.Config
{
    public static class AppSettings
    {
        public static ServicesConfig ServicesConfig { get; private set; } = new();

        public static void Configure(IConfiguration configuration)
        {
            ServicesConfig = configuration
                .GetSection(nameof(ServicesConfig))
                .Get<ServicesConfig>() ?? new ServicesConfig();
        }
    }

    public sealed class ServicesConfig
    {
        public double TimeoutPadraoMilissegundos { get; init; } = 100000;
    }
}
