using AnthonyPWatts.Currency.Installments.InstallmentStrategies;

namespace AnthonyPWatts.Currency.Installments;

public static class InstallmentStrategyFactory
{
    public static IInstallmentStrategy GetStrategy(InstallmentStrategyType strategyType, int? fixedFirstInstallment = null)
    {
        return strategyType switch
        {
            InstallmentStrategyType.EvenSplit_RoundingIntoFirstInstallment => new EvenSplit_RoundingIntoFirstInstallmentStrategy(),
            InstallmentStrategyType.EvenSplit_RoundingIntoLastInstallment => new EvenSplit_RoundingIntoLastInstallmentStrategy(),
            InstallmentStrategyType.FixedFirstInstallment_EvenSplitRoundingIntoSecondInstallment =>
                fixedFirstInstallment.HasValue
                    ? new FixedFirstInstallment_EvenSplitRoundingIntoSecondInstallmentStrategy(fixedFirstInstallment.Value)
                    : throw new ArgumentNullException(nameof(fixedFirstInstallment), "Fixed first installment amount must be provided for this strategy."),
                    InstallmentStrategyType.WholePounds_FirstInstallmentHandlesFraction => new WholePounds_FirstInstallmentHandlesFractionStrategy(),
            _ => throw new NotSupportedException($"Strategy {strategyType} is not supported.")
        };
    }
}