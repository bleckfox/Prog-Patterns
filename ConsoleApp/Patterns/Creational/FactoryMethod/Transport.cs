namespace ConsoleApp.Patterns.Creational.FactoryMethod;

/// <summary>
/// Базовый класс в фабрике для выбора типа транспорта
/// </summary>
public abstract class Transport(LogHandler logger)
{
    protected readonly LogHandler _logger = logger;
    public abstract void Deliver();
}


/// <summary>
/// Класс для типа "Автомобиль"
/// </summary>
public class Car(LogHandler logger) : Transport(logger)
{
    public override void Deliver()
    {
        _logger("Deliver by car");
    }
}


/// <summary>
/// Класс для типа "Велосипед"
/// </summary>
public class Bike(LogHandler logger) : Transport(logger)
{
    public override void Deliver()
    {
        _logger("Deliver by bike");
    }
}
