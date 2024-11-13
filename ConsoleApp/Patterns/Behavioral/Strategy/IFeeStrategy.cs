namespace ConsoleApp.Patterns.Behavioral.Strategy;

public interface IFeeStrategy
{
    public decimal CalculateFee(decimal amount);
}
