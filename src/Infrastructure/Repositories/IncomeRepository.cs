using MiningIncomeCalculator.Core.Interfaces.Infrastructure.Repositories;
using MiningIncomeCalculator.Core.Models;
using MiningIncomeCalculator.Infrastructure.Extensions;

namespace MiningIncomeCalculator.Infrastructure.Repositories;

public class IncomeRepository : IIncomeRepository
{
    public async Task WriteIncomeData(List<Income> incomes, string csvFilePath)
    {
        var csvData = incomes.ToCsv();

        await using StreamWriter file = new(csvFilePath);

        await file.WriteLineAsync(csvData);
    }
}
