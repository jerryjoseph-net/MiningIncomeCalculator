﻿using MiningIncomeCalculator.Core.Models;

namespace MiningIncomeCalculator.Core.Interfaces.Infrastructure.Repositories;

public interface IIncomeRepository
{
    Task WriteIncomeData(List<Income> incomes, string csvFilePath);
}