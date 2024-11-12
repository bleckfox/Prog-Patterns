namespace ConsoleApp.Patterns.Structural.Adapter;

public class Payments { }


public class PayPallService : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Creational.Singleton.SingletonLogger.Instance.Log($"Processing payment of {amount} through PayPall");
    }
}

public class CryptoService
{
    public void ProcessTransaction(decimal amount)
    {
        Creational.Singleton.SingletonLogger.Instance.Log($"Processing payment of {amount} through CryptoService");
    }
}


public class CryptoServiceAdapter(CryptoService service) : IPaymentProcessor
{
    private readonly CryptoService _cryptoService = service;

    public void ProcessPayment(decimal amount)
    {
        _cryptoService.ProcessTransaction(amount);
    }
}
