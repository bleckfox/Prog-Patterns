namespace ConsoleApp.Patterns.Behavioral.Strategy;

public class Strategies
{
}

public class PercentageFeeStrategy(decimal percentage) : IFeeStrategy
{
    private readonly decimal _percentage = percentage;

    public decimal CalculateFee(decimal amount)
    {
        return _percentage * amount;
    }
}


public class FixedFeeStrategy(decimal fixedFee) : IFeeStrategy
{
    private readonly decimal _fixedFee = fixedFee;

    public decimal CalculateFee(decimal amount)
    {
        return _fixedFee;
    }
}
