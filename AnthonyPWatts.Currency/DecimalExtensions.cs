namespace AnthonyPWatts.Currency;

public static class DecimalExtensions
{
    /// <summary>
    /// Truncates a decimal to two decimal places, effectively rounding down.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static decimal TruncateToCurrency(this decimal value)
    {
        return Math.Floor(value * 100) / 100;
    }

    /// <summary>
    /// Rounds a decimal to two decimal places, rounding up or down as appropriate.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static decimal RoundToCurrency(this decimal value)
    {
        return Math.Round(value, 2, MidpointRounding.AwayFromZero);
    }

}

