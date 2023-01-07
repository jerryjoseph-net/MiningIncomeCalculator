using Microsoft.Extensions.Configuration;

namespace MiningIncomeCalculator.Infrastructure.IntegrationTests;

internal class Startup
{
    public static IConfiguration InitConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        var config = builder.Build();

        return config;
    }
}