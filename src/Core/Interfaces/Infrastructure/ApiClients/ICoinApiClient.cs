namespace MiningIncomeCalculator.Core.Interfaces.Infrastructure.ApiClients;

public interface ICoinApiClient
{
    Task<decimal> GetBtcPrice(DateTime time, string currency);
}
