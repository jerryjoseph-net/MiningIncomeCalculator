using MiningIncomeCalculator.Core.Interfaces;
using MiningIncomeCalculator.Core.Interfaces.Infrastructure;
using MiningIncomeCalculator.Core.Models;

namespace MiningIncomeCalculator.Core;

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
