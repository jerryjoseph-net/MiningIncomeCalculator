using Microsoft.Extensions.Configuration;

namespace MiningIncomeCalculator.Infrastructure.IntegrationTests;

public class CoinApiClientTests
{
    [Fact]
    public async Task GetBtcPrice_20220101_Returns46182o6902043563M()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        
        var configuration = builder.Build();

        var apiKey = configuration["ApiKey"] ?? throw new InvalidOperationException("API Key is needed");


        var sut = new CoinApiClient(apiKey);

        var result = await sut.GetBtcPrice(new DateTime(2022, 01, 01));

        Assert.Equal(46182.6902043563M, result);
    }
}
