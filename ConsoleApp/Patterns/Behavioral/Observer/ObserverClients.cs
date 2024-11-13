namespace ConsoleApp.Patterns.Behavioral.Observer;

public class ObserverClients
{
    protected string GetMessage(string name, decimal exchangeRate)
    {
        return $"{name} received an update. Current exchange rate -> {exchangeRate}";
    }
}


public class MobileAppClient(string name, LogHandler logger) : ObserverClients, IObserver
{
    private readonly string _name = name;
    private readonly LogHandler _logger = logger;

    public void Update(decimal exchangeRate)
    {
        _logger(GetMessage(_name, exchangeRate));
    }
}


public class WebAppClient(string name, LogHandler logger) : ObserverClients, IObserver
{
    private readonly string _name = name;
    private readonly LogHandler _logger = logger;

    public void Update(decimal exchangeRate)
    {
        _logger(GetMessage(_name, exchangeRate));
    }
}

