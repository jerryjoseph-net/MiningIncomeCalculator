using System.Globalization;

namespace MiningIncomeCalculator.Core.Models;

public class Income
{
    public Income(Payout payout, decimal rate, string currency)
    {
        Payout = payout;
        Rate = rate;
        Currency = currency;
    }

    public decimal Amount => Rate * decimal.Parse(Payout.Amount, CultureInfo.InvariantCulture);
    public string Currency { get; }
    public Payout Payout { get; }
    public decimal Rate { get; }

    public override string ToString()
    {
        var dateString = Payout.Date.ToShortDateString();
        var amountString = decimal.Parse(Payout.Amount, CultureInfo.InvariantCulture).ToString(new CultureInfo("sv-SE"));
        var rateString = Rate.ToString(new CultureInfo("sv-SE"));
        var incomeAmountString = Amount.ToString(new CultureInfo("sv-SE"));

        return $"{dateString};{amountString};{rateString};{incomeAmountString};{Currency}";
    }
}
