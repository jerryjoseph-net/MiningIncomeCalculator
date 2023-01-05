using MiningIncomeCalculator.Core.Models;

namespace MiningIncomeCalculator.Core.Interfaces;

public interface IF2PoolRepository
{
    List<Payout> GetPayoutData(string csvFilePath);
}
