using ConsoleApp.Patterns.Creational.Singleton;
using ConsoleApp.Patterns.Creational.FactoryMethod;
using ConsoleApp.Patterns.Creational.AbstractFactory;
using ConsoleApp.Patterns.Creational.Builder;
using System.IO;


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


// Abstract Factory
Accounts accounts = new ();

ISocialMediaFactory facebookFactory = new FacebookFactory();
SocialMediaClient facebookClient = new (facebookFactory, "user123");
facebookClient.LoginAndPost("Hello, Facebook!");

ISocialMediaFactory twitterFactory = new TwitterFactory();
SocialMediaClient twitterClient = new (twitterFactory, "user456");
twitterClient.LoginAndPost("Hello, Twitter!");

accounts.GetAcccountsList();
Console.WriteLine();


// Builder
UserProfileBuilder userProfileBuilder = new();
UserProfile userProfile = userProfileBuilder
            .SetFirstName("John")
            .SetLastName("Doe")
            .SetAge(30)
            .SetEmail("john.doe@example.com")
            .SetAddress("456 Elm Street")
            .Build();

logger.Log($"User profile -> {userProfile}");

UserProfileDirector userProfileDirector = new(userProfileBuilder);
UserProfile defaultProfile = userProfileDirector.BuildDefaultProfile();
logger.Log($"User profile -> {defaultProfile}");
Console.WriteLine();
