using MiningIncomeCalculator.Core.Models;
using MiningIncomeCalculator.Infrastructure;

namespace MiningIncomeCalculator.Core.IntegrationTests;

public class BtcIncomeServiceTests
{
    [Fact]
    public async Task GetIncomesAsync_ListOfDates_ReturnsRates()
    {
        // Arrange

        var configuration = new Startup().Configuration;

        var apiKey = configuration["ApiKey"] ?? throw new InvalidOperationException("API Key is needed");


        var sut = new BtcIncomeService(new CoinApiClient(apiKey));

        var dates = new List<Payout>
        {
            new(new DateTime(2022, 11, 01), "0.1", "FakeAddress", "Paid", "FakeTxId"),
            new(new DateTime(2022, 11, 02), "0.2", "FakeAddress", "Paid", "FakeTxId"),
            new(new DateTime(2022, 11, 03), "0.3", "FakeAddress", "Paid", "FakeTxId")
        };

        // Act

        var result = await sut.GetIncomesAsync(dates);

        // Assert

        Assert.Equal(3, result.Count);
        Assert.Equal(226024.81246659700636424275651M, result.First().Rate);
        Assert.Equal(225615.3310079706561372581168M, result.ElementAt(1).Rate);
        Assert.Equal(223886.31028959440332444301355M, result.Last().Rate);
    }
}
