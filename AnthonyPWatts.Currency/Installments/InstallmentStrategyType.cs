namespace AnthonyPWatts.Currency.Installments;

public enum InstallmentStrategyType
{
    EvenSplit_RoundingIntoFirstInstallment,
    EvenSplit_RoundingIntoLastInstallment,
    FixedFirstInstallment_EvenSplitRoundingIntoSecondInstallment,
    WholePounds_FirstInstallmentHandlesFraction,
}
