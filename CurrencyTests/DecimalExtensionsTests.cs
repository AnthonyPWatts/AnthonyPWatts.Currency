using AnthonyPWatts.Currency;

namespace CurrencyTests;

public class DecimalExtensionsTests
{
    [Fact]
    public void TruncateToCurrency_ShouldTruncateDecimalToTwoDecimalPlaces()
    {
        decimal value = 123.4567m;
        decimal result = value.TruncateToCurrency();
        Assert.Equal(123.45m, result);
    }
    [Fact]
    public void RoundToCurrency_ShouldRoundDecimalToTwoDecimalPlaces()
    {
        decimal value = 123.4567m;
        decimal result = value.RoundToCurrency();
        Assert.Equal(123.46m, result);
    }
}
