using AnthonyPWatts.Currency.Installments;

decimal amount = 255.13M;
int numberOfInstallments = 11;


Console.WriteLine("Testing EvenSplit_RoundingIntoFirstInstallment strategy:");
var strategy1 = InstallmentStrategyFactory.GetStrategy(InstallmentStrategyType.EvenSplit_RoundingIntoFirstInstallment);
var result1 = strategy1.CalculateInstallments(amount, numberOfInstallments);
Console.WriteLine(result1);
Console.WriteLine(result1.Total);
Console.WriteLine();

Console.WriteLine("Testing EvenSplit_RoundingIntoLastInstallment strategy:");
var strategy2 = InstallmentStrategyFactory.GetStrategy(InstallmentStrategyType.EvenSplit_RoundingIntoLastInstallment);
var result2 = strategy2.CalculateInstallments(amount, numberOfInstallments);
Console.WriteLine(result2);
Console.WriteLine(result2.Total);
Console.WriteLine();

Console.WriteLine("Testing FixedFirstInstallment_EvenSplitRoundingIntoSecondInstallment strategy:");
int fixedFirstInstallment = 50;
var strategy3 = InstallmentStrategyFactory.GetStrategy(InstallmentStrategyType.FixedFirstInstallment_EvenSplitRoundingIntoSecondInstallment, fixedFirstInstallment);
var result3 = strategy3.CalculateInstallments(amount, numberOfInstallments);
Console.WriteLine(result3);
Console.WriteLine(result3.Total);
Console.WriteLine();

Console.WriteLine("Testing WholePounds_FirstInstallmentHandlesFraction strategy:");
var strategy4 = InstallmentStrategyFactory.GetStrategy(InstallmentStrategyType.WholePounds_FirstInstallmentHandlesFraction);
var result4 = strategy4.CalculateInstallments(amount, numberOfInstallments);
Console.WriteLine(result4);
Console.WriteLine(result4.Total);
Console.WriteLine();



Console.WriteLine("Press any key to exit...");
Console.ReadKey();
