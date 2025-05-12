namespace AnthonyPWatts.Currency.Installments.InstallmentStrategies;

public sealed class FixedFirstInstallment_EvenSplitRoundingIntoSecondInstallmentStrategy : IInstallmentStrategy
{
    private readonly decimal _firstInstallmentAmount;

    public FixedFirstInstallment_EvenSplitRoundingIntoSecondInstallmentStrategy(decimal firstInstallmentAmount)
    {
        if (firstInstallmentAmount <= 0)
            throw new ArgumentOutOfRangeException(nameof(firstInstallmentAmount), "Must be greater than zero.");
        _firstInstallmentAmount = firstInstallmentAmount;
    }

    public InstallmentPlan CalculateInstallments(decimal totalAmount, int numberOfInstallments)
    {
        IInstallmentStrategy.ValidateRequest(totalAmount, numberOfInstallments);

        // Strtegy-specific validation
        if (numberOfInstallments < 2)
            throw new ArgumentOutOfRangeException(nameof(numberOfInstallments), "Must be at least 2 to fix the first installment.");

        if (_firstInstallmentAmount >= totalAmount)
            throw new ArgumentOutOfRangeException(nameof(_firstInstallmentAmount), "First installment exceeds or equals total amount.");

        decimal remaining = totalAmount - _firstInstallmentAmount;
        decimal regularAmount = Math.Floor((remaining / (numberOfInstallments - 1)) * 100) / 100;
        decimal remainder = remaining - (regularAmount * (numberOfInstallments - 1));

        var installments = new List<Installment>
        {
            new Installment(1, _firstInstallmentAmount)
        };

        installments.AddRange(
            Enumerable.Range(2, numberOfInstallments - 1)
                .Select(n => new Installment(
                    n,
                    n == 2 ? regularAmount + remainder : regularAmount)));

        return new InstallmentPlan(installments);
    }
}
