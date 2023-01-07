using MiningIncomeCalculator.Core.Models;

namespace MiningIncomeCalculator.Core.Interfaces.Infrastructure.Repositories;

public interface IF2PoolRepository
{
    List<Payout> GetPayoutData(string csvFilePath);
}
