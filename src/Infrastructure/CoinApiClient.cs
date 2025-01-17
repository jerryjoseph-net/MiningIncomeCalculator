﻿using CoinAPI.REST.V1;
using MiningIncomeCalculator.Core.Interfaces;

namespace MiningIncomeCalculator.Infrastructure;

public class CoinApiClient : ICoinApiClient
{
    private readonly string _apiKey;

    public CoinApiClient(string apiKey)
    {
        _apiKey = apiKey;
    }

    public async Task<decimal> GetBtcPrice(DateTime time)
    {
        var client = new CoinApiRestClient(_apiKey);
        
        var exchangeRate = await client.Exchange_rates_get_specific_rateAsync("BTC", "USD", time);

        return exchangeRate.rate;
    }
}
