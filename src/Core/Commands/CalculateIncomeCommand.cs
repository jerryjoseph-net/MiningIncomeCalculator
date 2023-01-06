using MiningIncomeCalculator.Core.Interfaces;
using MiningIncomeCalculator.Core.Interfaces.Infrastructure;

namespace MiningIncomeCalculator.Core.Commands;

// TODO Use MediatR pattern 

public class CalculateIncomeCommand
{
    public class CalculateIncomeCommandHandler
    {
        private readonly IBtcIncomeService _btcRateService;
        private readonly IF2PoolRepository _f2PoolRepository;
        private readonly IIncomeRepository _iiIncomeRepository;
        private readonly string _payoutFilePath;
        private readonly string _incomeFilePath;

        public CalculateIncomeCommandHandler(
            IBtcIncomeService btcRateService,
            IF2PoolRepository f2PoolRepository,
            IIncomeRepository iiIncomeRepository,
            string payoutFilePath,
            string incomeFilePath)
        {
            _btcRateService = btcRateService;
            _f2PoolRepository = f2PoolRepository;
            _iiIncomeRepository = iiIncomeRepository;
            _payoutFilePath = payoutFilePath;
            _incomeFilePath = incomeFilePath;
        }

        public async Task Handle()
        {
            var payouts = _f2PoolRepository.GetPayoutData(_payoutFilePath);

            var incomes = await _btcRateService.GetIncomesAsync(payouts);

            await _iiIncomeRepository.WriteIncomeData(incomes, _incomeFilePath);
        }
    }
}