using MiningIncomeCalculator.Core.Commands;
using MiningIncomeCalculator.Core.Services;
using MiningIncomeCalculator.Infrastructure.ApiClients;
using MiningIncomeCalculator.Infrastructure.Repositories;

namespace MiningIncomeCalculator.Core.IntegrationTests;

public class CalculateIncomeCommandHandlerTests
{
    [Fact]
    public async Task Handle_Default_GeneratesIncomeCsvFile()
    {
        // Arrange

        var configuration = new Startup().Configuration;

        var apiKey = configuration["ApiKey"] ?? throw new InvalidOperationException("API Key is needed");
        var payoutFilePath = configuration["PayoutFilePath"] ?? throw new InvalidOperationException("Payout File Path is needed");
        var incomeFilePath = configuration["IncomeFilePath"] ?? throw new InvalidOperationException("Income File Path is needed");


        var sut = new CalculateIncomeCommand.CalculateIncomeCommandHandler(
            new BtcIncomeService(new CoinApiClient(apiKey)), 
            new F2PoolRepository(), 
            new IncomeRepository(),
            payoutFilePath,
            incomeFilePath);
        
        // Act

        await sut.Handle();

        // Assert


    }
}
