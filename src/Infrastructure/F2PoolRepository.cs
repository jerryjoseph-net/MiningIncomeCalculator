namespace MiningIncomeCalculator.Infrastructure;

public class F2PoolRepository
{
    public List<Payout> GetPayoutData(string csvFilePath)
    {
        var payouts = new List<Payout>();

        using var reader = new StreamReader(csvFilePath);
        
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line?.Split(',');

            if (values != null && values[0] != "Date") // Skip header row
            {
                payouts.Add(new Payout(values[0], values[1], values[2], values[3], values[4]));
            }
        }

        return payouts;
    }
}

public record Payout(string Date, string Amount, string Address, string Status, string TxId);