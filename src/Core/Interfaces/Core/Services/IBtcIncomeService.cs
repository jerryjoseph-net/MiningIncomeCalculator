using MiningIncomeCalculator.Core.Models;

namespace MiningIncomeCalculator.Core.Interfaces.Core.Services;

public interface IBtcIncomeService
{
    Task<List<Income>> GetIncomesAsync(List<Payout> payouts);
}
