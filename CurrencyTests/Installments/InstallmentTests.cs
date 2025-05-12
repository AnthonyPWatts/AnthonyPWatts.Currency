using AnthonyPWatts.Currency.Installments;

namespace CurrencyTests.Installments;

public class InstallmentTests
{
    [Fact]
    public void Installment_ShouldInitializeCorrectly()
    {
        int installmentNumber = 1;
        decimal amount = 100.00m;

        var installment = new Installment(installmentNumber, amount);

        Assert.Equal(installmentNumber, installment.InstallmentNumber);
        Assert.Equal(amount, installment.Amount);
    }

    [Fact]
    public void Installment_ShouldRoundAmountToTwoDecimalPlaces()
    {
        int installmentNumber = 1;
        decimal amount = 100.005m; // More than two decimal places
        var installment = new Installment(installmentNumber, amount);
        Assert.Equal(100.01m, installment.Amount); // Should round to two decimal places
    }
}
