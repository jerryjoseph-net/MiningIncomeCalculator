using Microsoft.Extensions.Configuration;
using MiningIncomeCalculator.Infrastructure;

namespace MiningIncomeCalculator.Core.IntegrationTests;

public class BtcRateServiceTests
{
    [Fact]
    public async Task GetRatesAsync_ListOfDates_ReturnsRates()
    {
        // TODO Move

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        // Arrange

        var apiKey = configuration["ApiKey"] ?? throw new InvalidOperationException("API Key is needed");


        var sut = new BtcRateService(new CoinApiClient(apiKey));

        var dates = new List<DateTime>
        {
            new(2022, 11, 01),
            new(2022, 11, 02),
            new(2022, 11, 03)
        };

        // Act

        var result = await sut.GetRatesAsync(dates);

        // Assert

        Assert.Equal(3, result.Count);
        Assert.Equal(20496.8282890577M, result.First());
        Assert.Equal(20487.7684189483M, result.ElementAt(1));
        Assert.Equal(20148.8646952261M, result.Last());
    }
}
