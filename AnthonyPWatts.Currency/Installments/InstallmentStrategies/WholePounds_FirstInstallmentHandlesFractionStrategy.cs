namespace AnthonyPWatts.Currency.Installments.InstallmentStrategies;

public sealed class WholePounds_FirstInstallmentHandlesFractionStrategy : IInstallmentStrategy
{
    public InstallmentPlan CalculateInstallments(decimal totalAmount, int numberOfInstallments)
    {
        IInstallmentStrategy.ValidateRequest(totalAmount, numberOfInstallments);

        int totalAsWholePoundsOnly = (int)totalAmount;
        int installmentAmount = totalAsWholePoundsOnly / numberOfInstallments;
        decimal remainder = totalAmount - (installmentAmount * numberOfInstallments);

        var installments = Enumerable.Range(1, numberOfInstallments)
            .Select(n => new Installment(
                n,
                n == 1 ? installmentAmount + remainder : installmentAmount))
            .ToList();

        return new InstallmentPlan(installments);
    }
}
