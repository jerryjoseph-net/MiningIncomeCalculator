using MiningIncomeCalculator.Core.Models;

namespace MiningIncomeCalculator.Core.Interfaces;

public interface IBtcIncomeService
{
    Task<List<Income>> GetIncomesAsync(List<Payout> payouts);
}
