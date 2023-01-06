using MiningIncomeCalculator.Core.Models;

namespace MiningIncomeCalculator.Infrastructure.Extensions;

public static class IncomeExtensions
{
    public static string ToCsv(this List<Income> incomes)
    {
        var incomesString = string.Join(Environment.NewLine, incomes);

        return $"SEP=;{Environment.NewLine}{incomesString}"; 
    }
}
