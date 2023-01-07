using MiningIncomeCalculator.Infrastructure.ApiClients;

namespace MiningIncomeCalculator.Infrastructure.IntegrationTests;

public class CoinApiClientTests
{
    [Fact]
    public async Task GetBtcPrice_20220101USD_Returns46182o6902043563M()
    {
        // Arrange

        var configuration = Startup.InitConfiguration();
        var apiKey = configuration["ApiKey"] ?? throw new InvalidOperationException("API Key is needed");

        var sut = new CoinApiClient(apiKey);

        // Act

        var result = await sut.GetBtcPrice(new DateTime(2022, 01, 01), "USD");

        // Assert

        Assert.Equal(46182.6902043563M, result);
    }

    [Fact]
    public async Task GetBtcPrice_20220815SEK_Returns0()
    {
        // Arrange

        var configuration = Startup.InitConfiguration();
        var apiKey = configuration["ApiKey"] ?? throw new InvalidOperationException("API Key is needed");

        var sut = new CoinApiClient(apiKey);

        // Act

        var result = await sut.GetBtcPrice(new DateTime(2022, 08, 15), "SEK");

        // Assert

        Assert.Equal(0, result);
    }
}
