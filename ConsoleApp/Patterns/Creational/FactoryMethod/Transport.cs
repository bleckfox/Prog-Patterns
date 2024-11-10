namespace ConsoleApp.Patterns.Creational.FactoryMethod;

/// <summary>
/// Базовый класс в фабрике для выбора типа транспорта
/// </summary>
public abstract class Transport
{
    public abstract void Deliver();
}


/// <summary>
/// Класс для типа "Автомобиль"
/// </summary>
public class Car : Transport
{
    public override void Deliver()
    {
        Console.WriteLine("Deliver by car");
    }
}


/// <summary>
/// Класс для типа "Велосипед"
/// </summary>
public class Bike : Transport
{
    public override void Deliver()
    {
        Console.WriteLine("Deliver by bike");
    }
}
