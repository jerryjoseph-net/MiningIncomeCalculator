using MiningIncomeCalculator.Core.Interfaces.Core.Services;
using MiningIncomeCalculator.Core.Interfaces.Infrastructure.ApiClients;
using MiningIncomeCalculator.Core.Models;

namespace MiningIncomeCalculator.Core.Services;

public class BtcIncomeService : IBtcIncomeService
{
    private const string Currency = "SEK";

    private readonly ICoinApiClient _coinApiClient;

    public BtcIncomeService(ICoinApiClient coinApiClient)
    {
        _coinApiClient = coinApiClient;
    }

    public async Task<List<Income>> GetIncomesAsync(List<Payout> payouts)
    {
        var incomes = new List<Income>();

        foreach (var payout in payouts)
        {
            var rate = await _coinApiClient.GetBtcPrice(payout!.Date, Currency);

            incomes.Add(new Income(payout, rate, Currency));
        }

        return incomes;
    }
}
