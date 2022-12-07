using Microsoft.Extensions.Configuration;

namespace MiningIncomeCalculator.Infrastructure.IntegrationTests;

internal class Startup
{
    public static IConfiguration InitConfiguration()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        return config;
    }
}