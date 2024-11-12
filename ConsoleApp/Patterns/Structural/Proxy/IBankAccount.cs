namespace ConsoleApp.Patterns.Structural.Proxy;

public interface IBankAccount
{
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    decimal GetBalance();
}
