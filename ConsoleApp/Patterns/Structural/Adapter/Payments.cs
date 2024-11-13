namespace ConsoleApp.Patterns.Structural.Adapter;

public class Payments { }


public class PayPallService(LogHandler logger) : IPaymentProcessor
{
    private readonly LogHandler _logger = logger;

    public void ProcessPayment(decimal amount)
    {
        _logger($"Processing payment of {amount} through PayPall");
    }
}

public class CryptoService(LogHandler logger)
{
    private readonly LogHandler _logger = logger;

    public void ProcessTransaction(decimal amount)
    {
        _logger($"Processing payment of {amount} through CryptoService");
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
