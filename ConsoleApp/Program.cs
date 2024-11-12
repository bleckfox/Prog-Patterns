using ConsoleApp.Patterns.Creational.Singleton;
using ConsoleApp.Patterns.Creational.FactoryMethod;
using ConsoleApp.Patterns.Creational.AbstractFactory;
using ConsoleApp.Patterns.Creational.Builder;
using ConsoleApp.Patterns.Creational.Prototype;
using ConsoleApp.Patterns.Structural.Facade;
using ConsoleApp.Patterns.Structural.Adapter;
using ConsoleApp.Patterns.Structural.Composite;
using ConsoleApp.Patterns.Structural.Decorator;
using ConsoleApp.Patterns.Structural.Proxy;


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


// Prototype
Document originalDocument = new ("Original Title", "Original Content");

Document clonedDocument = originalDocument.Clone();
clonedDocument.Title = "Cloned Title"; // изменяем название в копии
clonedDocument.Content = "Cloned Content"; // изменяем содержимое в копии

logger.Log($"Original Document -> {originalDocument}");
logger.Log($"Cloned Document -> {clonedDocument}");
logger.Log($"Original Document After Cloning -> {originalDocument}");
Console.WriteLine();


// Facade
BankingFacade banking = new();
banking.Transfer("John Doe", "Jane Smith", 1000m);
Console.WriteLine();


// Adapter
List<IPaymentProcessor> paymentProcessors = [
        new PayPallService(),
        new CryptoServiceAdapter(new CryptoService()),
    ];

paymentProcessors.ForEach(paymentProcessor =>
{
    paymentProcessor.ProcessPayment(100m);
});

Console.WriteLine();


// Composite
IAccountComponent debitAccount = new DebitAccount("Debit", 1000m);
IAccountComponent savingAccount = new SavingAccount("Saving", 2000m);

AccountPackage clientPackage = new("Client package");
clientPackage.AddAccount(debitAccount);
clientPackage.AddAccount(savingAccount);


IAccountComponent corpDebitAccount = new DebitAccount("Corp Debit", 10000m);
AccountPackage corpPackage = new("Corporate Package");
corpPackage.AddAccount(corpDebitAccount);
corpPackage.AddAccount(clientPackage);

corpPackage.DisplayAccountInfo();
logger.Log($"Total Balance in corporate package: {corpPackage.GetBalance()}");

Console.WriteLine();


// Decorator
decimal amount = 500m;
decimal limit = 1000m;

ITransaction transaction = new BaseTransaction(amount);
transaction = new LoggingTransactionDecorator(transaction); // BaseTransaction
transaction = new NotificationTransactionDecorator(transaction); // Logging
transaction = new LimitCheckTransactionDecorator(transaction, limit); // Notification

transaction.Process(); // LimitCheck.Process()

Console.WriteLine();

//     Analog
ITransaction transaction2 = 
    new LimitCheckTransactionDecorator(
        new NotificationTransactionDecorator(
                new LoggingTransactionDecorator(
                        new BaseTransaction(500m)
                )
        ),
        400m
    );

transaction2.Process();

Console.WriteLine();


// Proxy
SomeBankAccount someBankAccount = new();
IBankAccount accountProxyAdmin = new BankAccountProxy(someBankAccount, "Admin");
IBankAccount accountProxyUser = new BankAccountProxy(someBankAccount, "User");
IBankAccount accountProxyViewer = new BankAccountProxy(someBankAccount, "Viewer");

accountProxyAdmin.Deposit(100);
accountProxyAdmin.Withdraw(50);
logger.Log("Admin balance: " + accountProxyAdmin.GetBalance());
Console.WriteLine();

accountProxyUser.Deposit(200);
accountProxyUser.Withdraw(100);
logger.Log("User balance: " + accountProxyUser.GetBalance());
Console.WriteLine();

logger.Log("Viewer balance: " + accountProxyViewer.GetBalance());
accountProxyViewer.Withdraw(50);

Console.WriteLine();
