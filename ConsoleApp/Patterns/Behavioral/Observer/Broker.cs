namespace ConsoleApp.Patterns.Behavioral.Observer;

public class Broker(LogHandler logger) : ISubject
{
    private readonly List<IObserver> _observers = [];
    private decimal _exchangeRate;

    private readonly LogHandler _logger = logger;

    public decimal ExchangeRate
    {
        get => _exchangeRate;
        set
        {
            _exchangeRate = value;
            NotifyObservers();
        }
    }

    public void NotifyObservers()
    {
        _observers.ForEach(observer =>
        {
            observer.Update(_exchangeRate);
        });
    }

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
        _logger($"Register -> {observer.GetType()}");
    }

    public void UnregisterObserver(IObserver observer)
    {
        _observers.Remove(observer);
        _logger($"Unregister -> {observer.GetType()}");
    }
}
