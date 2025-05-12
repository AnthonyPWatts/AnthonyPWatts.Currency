namespace AnthonyPWatts.Currency.Installments.InstallmentStrategies;

public sealed class EvenSplit_RoundingIntoFirstInstallmentStrategy : IInstallmentStrategy
{
    public InstallmentPlan CalculateInstallments(decimal totalAmount, int numberOfInstallments)
    {
        IInstallmentStrategy.ValidateRequest(totalAmount, numberOfInstallments);

        decimal regularAmount = Math.Floor((totalAmount / numberOfInstallments) * 100) / 100;
        decimal remainder = totalAmount - (regularAmount * numberOfInstallments);

        var installments = Enumerable.Range(1, numberOfInstallments)
            .Select(n => new Installment(
                n,
                n == 1 ? regularAmount + remainder : regularAmount))
            .ToList();

        return new InstallmentPlan(installments);
    }
}
