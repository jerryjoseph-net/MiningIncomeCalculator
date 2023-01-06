using MiningIncomeCalculator.Core.Models;
using MiningIncomeCalculator.Infrastructure.Extensions;

namespace MiningIncomeCalculator.Infrastructure.UnitTests
{
    public class IncomeExtensionsTests
    {
        [Fact]
        public void ToCsv_Default_GeneratesCorrectCSV()
        {
            // Arrange

            var sut = new List<Income>
            {
                CreateIncome(2020, 12, 31, "0.1", 1000M),
                CreateIncome(2021, 12, 31, "0.2", 1500M),
                CreateIncome(2022, 12, 31, "0.3", 2000M)
            };

            // Act

            var result =  sut.ToCsv();

            // Assert

            Assert.Equal("SEP=;\r\n2020-12-31;0,1;1000;100,0;SEK\r\n2021-12-31;0,2;1500;300,0;SEK\r\n2022-12-31;0,3;2000;600,0;SEK", result);
        }

        private static Income CreateIncome(int year, int month, int day, string amount, decimal rate)
        {
            return new Income(
                new Payout(new DateTime(year, month, day), amount, "FakeAddress", "Paid", "FakeTxId"), 
                rate,
                "SEK");
        }
    }
}