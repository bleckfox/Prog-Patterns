namespace ConsoleApp.Patterns.Behavioral.Strategy;

public class BankTransaction(IFeeStrategy strategy, LogHandler logger)
{
    private readonly LogHandler _logger = logger;
    private IFeeStrategy _strategy = strategy;

    public void SetFeeStrategy(IFeeStrategy strategy) => _strategy = strategy;

    public decimal ProcessTransaction(decimal amount)
    {
        decimal fee = _strategy.CalculateFee(amount);
        decimal total = amount + fee;
        _logger($"Amout: {amount}, Fee: {fee}, Total: {total}");
        return total;
    }
}
