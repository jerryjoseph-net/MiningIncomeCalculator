namespace MiningIncomeCalculator.Core.Models;

public record Payout(DateTime Date, string Amount, string Address, string Status, string TxId);
