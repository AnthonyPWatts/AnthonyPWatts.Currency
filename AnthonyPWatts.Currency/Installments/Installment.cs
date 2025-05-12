namespace AnthonyPWatts.Currency.Installments;

public class Installment
{
    public int InstallmentNumber { get; }
    public decimal Amount { get; }

    public Installment(int installmentNumber, decimal amount)
    {
        InstallmentNumber = installmentNumber;
        Amount = Math.Round(amount, 2);
    }

    public override string ToString() => $"#{InstallmentNumber}: £{Amount:F2}";
}

