namespace MiningIncomeCalculator.Core.Interfaces.Infrastructure;

public interface ICoinApiClient
{
    Task<decimal> GetBtcPrice(DateTime time, string currency);
}
