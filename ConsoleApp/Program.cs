using ConsoleApp.Patterns.Creational.Singleton;
using ConsoleApp.Patterns.Creational.FactoryMethod;


// Singleton
SingletonLogger logger = SingletonLogger.Instance;
SingletonLogger logger2 = SingletonLogger.Instance;

logger.Log($"Message from {nameof(logger)}");
logger2.Log($"Message from {nameof(logger2)}");

Console.WriteLine(ReferenceEquals(logger, logger2));
Console.WriteLine();

// Factory Method
// Console.ReadLine() - для ввода
Logistic logistic = "car" switch
{
    "car" => new CarLogistic(),
    "bike" => new BikeLogistic(),
    _ => throw new Exception("Неизвестный тип транспорта")
};

logistic.PlanDelivery();

logger.Log($"Logistic type: {logistic.GetType()}");
logger.Log($"Transport type: {logistic.Transport.GetType()}");
Console.WriteLine();