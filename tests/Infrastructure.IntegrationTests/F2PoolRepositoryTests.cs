namespace MiningIncomeCalculator.Infrastructure.IntegrationTests;

public class F2PoolRepositoryTests
{
    [Fact]
    public void GetPayoutData_FakeFile_ReturnsPayouts()
    {
        // Arrange 
        var sut = new F2PoolRepository();

        // Act 
        var result = sut.GetPayoutData(Directory.GetCurrentDirectory() + "\\Payout-BTC-Fake.csv");

        // Assert 
        Assert.NotNull(result);
        Assert.Equal(5, result.Count);
    }
}