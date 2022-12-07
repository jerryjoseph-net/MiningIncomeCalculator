namespace MiningIncomeCalculator.Core.Interfaces;

public interface ICoinApiClient
{
    Task<decimal> GetBtcPrice(DateTime time);
}
