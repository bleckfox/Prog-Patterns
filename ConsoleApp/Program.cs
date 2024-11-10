
// Singleton
using ConsoleApp.Patterns.Creational.Singleton;

SingletonLogger logger = SingletonLogger.Instance;
SingletonLogger logger2 = SingletonLogger.Instance;

logger.Log($"Message from {nameof(logger)}");
logger2.Log($"Message from {nameof(logger2)}");

Console.WriteLine(ReferenceEquals(logger, logger2));

