using System;

namespace ConsoleApp.Patterns.Creational.Singleton;

public class SingletonLogger
{
    /// <summary>
    /// Приватное поле для обращения к экземпляру
    /// </summary>
    private static SingletonLogger _instance;

    /// <summary>
    /// Приватный конструктор, чтобы не создавать снаружи
    /// </summary>
    private SingletonLogger() { }

    /// <summary>
    /// Метод для получения доступа к экземпляру
    /// </summary>
    public static SingletonLogger Instance
    {
        get
        {
            // same variant
            //if (_instance == null)
            //{
            //    _instance = new SingletonLogger();
            //}

            //return _instance;

            return _instance ??= new SingletonLogger();
        }
    }

    public void Log(string message) => Console.WriteLine($"{DateTime.Now:G}: {message}");
}
