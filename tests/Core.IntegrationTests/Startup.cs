using Microsoft.Extensions.Configuration;

namespace MiningIncomeCalculator.Core.IntegrationTests;

public class Startup
{
    public Startup()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        Configuration = builder.Build();

        //var services = new ServiceCollection()
        //    .AddSingleton<IConfiguration>(Configuration)
        //    .AddCore();
    }

    public IConfigurationRoot Configuration { get; set; }
}
