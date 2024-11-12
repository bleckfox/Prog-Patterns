namespace ConsoleApp.Patterns.Structural.Adapter;

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}
