using MiningIncomeCalculator.Core.Interfaces;

namespace MiningIncomeCalculator.Core;

public class BtcRateService
{
    private readonly ICoinApiClient _coinApiClient;

    public BtcRateService(ICoinApiClient coinApiClient)
    {
        _coinApiClient = coinApiClient;
    }

    public async Task<List<decimal>> GetRatesAsync(List<DateTime> dates)
    {
        var rates = new List<decimal>();

        foreach (var date in dates)
        {
            rates.Add(await _coinApiClient.GetBtcPrice(date));
        }

        return rates;
    }
}
