namespace ConsoleApp.Patterns.Creational.FactoryMethod;

/// <summary>
/// Базовый класс, для опеределения фабричного метода
/// </summary>
public abstract class Logistic
{
    public abstract Transport CreateTransport();

    public Transport Transport { get; }

    public Logistic()
    {
        Transport = CreateTransport();
    }

    public void PlanDelivery()
    {
        Transport.Deliver();
    }
}


public class CarLogistic : Logistic
{
    public override Transport CreateTransport()
    {
        return new Car();
    }
}


public class BikeLogistic : Logistic
{
    public override Transport CreateTransport()
    {
        return new Bike();
    }
}

