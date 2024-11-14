namespace ConsoleApp.Patterns.Structural.Proxy;

public interface IBankAccount
{
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    decimal GetBalance();

    public BankTransactionStateEnum BankTransactionState { get; set; }
}

public enum BankTransactionStateEnum
{
    None,
    Success,
    Canceled
}
