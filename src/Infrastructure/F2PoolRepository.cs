using MiningIncomeCalculator.Core.Interfaces;
using MiningIncomeCalculator.Core.Models;

namespace MiningIncomeCalculator.Infrastructure;

public class F2PoolRepository : IF2PoolRepository
{
    public List<Payout> GetPayoutData(string csvFilePath)
    {
        var payouts = new List<Payout>();

        using var reader = new StreamReader(csvFilePath);
        
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line?.Split(',');

            if (IsDataRow(values)) // Skip header row
            {
                payouts.Add(new Payout(values![0], values[1], values[2], values[3], values[4]));
            }
        }

        return payouts;
    }

    private static bool IsDataRow(IReadOnlyList<string>? values)
    {
        return values != null 
               && values[0] != "Date";
    }
}
