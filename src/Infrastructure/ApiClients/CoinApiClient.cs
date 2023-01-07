using CoinAPI.REST.V1;
using MiningIncomeCalculator.Core.Interfaces.Infrastructure.ApiClients;

namespace MiningIncomeCalculator.Infrastructure.ApiClients;

public class CoinApiClient : ICoinApiClient
{
    private readonly string _apiKey;

    public CoinApiClient(string apiKey)
    {
        _apiKey = apiKey;
    }

    public async Task<decimal> GetBtcPrice(DateTime time, string currency)
    {
        var client = new CoinApiRestClient(_apiKey);

        try
        {
            var exchangeRate = await client.Exchange_rates_get_specific_rateAsync("BTC", currency, time);

            return exchangeRate.rate;
        }
        catch (Exception ex)
        {
            // TODO Log exception

            return 0; // Manually fix data in output file for these
        }
    }
}
