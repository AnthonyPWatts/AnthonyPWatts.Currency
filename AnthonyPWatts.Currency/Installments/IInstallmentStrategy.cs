namespace AnthonyPWatts.Currency.Installments;

public interface IInstallmentStrategy
{
    InstallmentPlan CalculateInstallments(decimal totalAmount, int numberOfInstallments);

    public static void ValidateRequest(decimal totalAmount, int numberOfInstallments)
    {
        const string CountError = "Installment count must be greater than zero.";
        const string AmountNegativeError = "Total amount must be non-negative.";
        const string CurrencyPrecisionError = "Total amount must be a valid currency value with no more than two decimal places.";

        if (numberOfInstallments <= 0)
            throw new ArgumentOutOfRangeException(nameof(numberOfInstallments), CountError);

        if (totalAmount < 0)
            throw new ArgumentOutOfRangeException(nameof(totalAmount), AmountNegativeError);

        if (totalAmount % 0.01m != 0)
            throw new ArgumentOutOfRangeException(nameof(totalAmount), CurrencyPrecisionError);
    }
}

