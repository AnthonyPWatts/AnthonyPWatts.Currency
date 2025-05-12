namespace AnthonyPWatts.Currency.Installments.InstallmentStrategies;

public sealed class EvenSplit_RoundingIntoLastInstallmentStrategy : IInstallmentStrategy
{
    public InstallmentPlan CalculateInstallments(decimal totalAmount, int numberOfInstallments)
    {
        IInstallmentStrategy.ValidateRequest(totalAmount, numberOfInstallments);

        decimal regularAmount = Math.Floor((totalAmount / numberOfInstallments) * 100) / 100;
        decimal remainder = totalAmount - (regularAmount * numberOfInstallments);

        var installmentList = Enumerable.Range(1, numberOfInstallments)
            .Select(installmentNumber => new Installment(
                installmentNumber,
                installmentNumber == numberOfInstallments ? regularAmount + remainder : regularAmount))
            .ToList();

        return new InstallmentPlan(installmentList);
    }
}


