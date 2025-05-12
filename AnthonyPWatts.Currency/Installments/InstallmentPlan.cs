namespace AnthonyPWatts.Currency.Installments;

public class InstallmentPlan
{
    private readonly List<Installment> _installments;

    public InstallmentPlan(IEnumerable<Installment> installments)
    {
        _installments = [.. installments];
    }

    public IReadOnlyList<Installment> Items => _installments;

    public decimal Total => _installments.Sum(i => i.Amount);

    public override string ToString()
        => string.Join(", ", _installments.Select(i => i.ToString()));
}

