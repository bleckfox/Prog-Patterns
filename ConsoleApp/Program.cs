using ConsoleApp;
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
using ConsoleApp.Patterns.Behavioral.Observer;
using ConsoleApp.Patterns.Behavioral.Strategy;
using ConsoleApp.Patterns.Behavioral.Command;
using ConsoleApp.Patterns.Behavioral.State;
using ConsoleApp.Patterns.Behavioral.ChainOfResponsibility;
using ConsoleApp.Patterns.Concurrency.ThreadPool;


int patternIndent = 10;

// Singleton
Console.WriteLine(string.Join("", $"{DateTime.Now:G}: ", new string('-', patternIndent), " Singleton"));
SingletonLogger logger = SingletonLogger.Instance;
SingletonLogger logger2 = SingletonLogger.Instance;

logger.Log($"Message from {nameof(logger)}");
logger2.Log($"Message from {nameof(logger2)}");

logger.Log(ReferenceEquals(logger, logger2).ToString());
Console.WriteLine();



// Use delegate for log in classes below
LogHandler logHandler = logger.Log;




// Factory Method
// Console.ReadLine() - для ввода
logHandler(new string('-', patternIndent) + " Factory Method");
Logistic logistic = "car" switch
{
    "car" => new CarLogistic(logHandler),
    "bike" => new BikeLogistic(logHandler),
    _ => throw new Exception("Неизвестный тип транспорта")
};

logistic.PlanDelivery();

logHandler($"Logistic type: {logistic.GetType()}");
logHandler($"Transport type: {logistic.Transport.GetType()}");
Console.WriteLine();


// Abstract Factory
logHandler(new string('-', patternIndent) + " Abstracrt Factory");
Accounts accounts = new (logHandler);

ISocialMediaFactory facebookFactory = new FacebookFactory(logHandler);
SocialMediaClient facebookClient = new (facebookFactory, "user123");
facebookClient.LoginAndPost("Hello, Facebook!");

ISocialMediaFactory twitterFactory = new TwitterFactory(logHandler);
SocialMediaClient twitterClient = new (twitterFactory, "user456");
twitterClient.LoginAndPost("Hello, Twitter!");

accounts.GetAcccountsList();
Console.WriteLine();


// Builder
logHandler(new string('-', patternIndent) + " Builder");
UserProfileBuilder userProfileBuilder = new();
UserProfile userProfile = userProfileBuilder
            .SetFirstName("John")
            .SetLastName("Doe")
            .SetAge(30)
            .SetEmail("john.doe@example.com")
            .SetAddress("456 Elm Street")
            .Build();

logHandler($"User profile -> {userProfile}");

UserProfileDirector userProfileDirector = new(userProfileBuilder);
UserProfile defaultProfile = userProfileDirector.BuildDefaultProfile();
logHandler($"User profile -> {defaultProfile}");
Console.WriteLine();


// Prototype
logHandler(new string('-', patternIndent) + " Prototype");
Document originalDocument = new ("Original Title", "Original Content");

Document clonedDocument = originalDocument.Clone();
clonedDocument.Title = "Cloned Title"; // изменяем название в копии
clonedDocument.Content = "Cloned Content"; // изменяем содержимое в копии

logHandler($"Original Document -> {originalDocument}");
logHandler($"Cloned Document -> {clonedDocument}");
logHandler($"Original Document After Cloning -> {originalDocument}");
Console.WriteLine();


// Facade
logHandler(new string('-', patternIndent) + " Facade");
BankingFacade banking = new(logHandler);
banking.Transfer("John Doe", "Jane Smith", 1000m);
Console.WriteLine();


// Adapter
logHandler(new string('-', patternIndent) + " Adapter");
List<IPaymentProcessor> paymentProcessors = [
        new PayPallService(logHandler),
        new CryptoServiceAdapter(new CryptoService(logHandler)),
    ];

paymentProcessors.ForEach(paymentProcessor =>
{
    paymentProcessor.ProcessPayment(100m);
});

Console.WriteLine();


// Composite
logHandler(new string('-', patternIndent) + " Composite");
IAccountComponent debitAccount = new DebitAccount("Debit", 1000m, logHandler);
IAccountComponent savingAccount = new SavingAccount("Saving", 2000m, logHandler);

AccountPackage clientPackage = new("Client package", logHandler);
clientPackage.AddAccount(debitAccount);
clientPackage.AddAccount(savingAccount);


IAccountComponent corpDebitAccount = new DebitAccount("Corp Debit", 10000m, logHandler);
AccountPackage corpPackage = new("Corporate Package", logHandler);
corpPackage.AddAccount(corpDebitAccount);
corpPackage.AddAccount(clientPackage);

corpPackage.DisplayAccountInfo();
logHandler($"Total Balance in corporate package: {corpPackage.GetBalance()}");

Console.WriteLine();


// Decorator
logHandler(new string('-', patternIndent) + " Decorator");
decimal amount = 500m;
decimal limit = 1000m;

ITransaction transaction = new BaseTransaction(amount, logHandler);
transaction = new LoggingTransactionDecorator(transaction, logHandler); // BaseTransaction
transaction = new NotificationTransactionDecorator(transaction, logHandler); // Logging
transaction = new LimitCheckTransactionDecorator(transaction, limit, logHandler); // Notification

transaction.Process(); // LimitCheck.Process()

Console.WriteLine();

//     Analog
ITransaction transaction2 = 
    new LimitCheckTransactionDecorator(
        new NotificationTransactionDecorator(
                new LoggingTransactionDecorator(
                        new BaseTransaction(500m, logHandler), logHandler
                ), logHandler
        ),
        400m,
        logHandler
    );

transaction2.Process();

Console.WriteLine();


// Proxy
logHandler(new string('-', patternIndent) + " Proxy");
SomeBankAccount someBankAccount = new(logHandler);
IBankAccount accountProxyAdmin = new BankAccountProxy(someBankAccount, "Admin", logHandler);
IBankAccount accountProxyUser = new BankAccountProxy(someBankAccount, "User", logHandler);
IBankAccount accountProxyViewer = new BankAccountProxy(someBankAccount, "Viewer", logHandler);

// work with the same bank account
accountProxyAdmin.Deposit(100);
accountProxyAdmin.Withdraw(50);
logHandler("Admin balance: " + accountProxyAdmin.GetBalance());
Console.WriteLine();

accountProxyUser.Deposit(200);
accountProxyUser.Withdraw(100);
logHandler("User balance: " + accountProxyUser.GetBalance());
Console.WriteLine();

logHandler("Viewer balance: " + accountProxyViewer.GetBalance());
accountProxyViewer.Withdraw(50);

Console.WriteLine();


// Observer
logHandler(new string('-', patternIndent) + " Observer");

Broker broker = new(logHandler);
MobileAppClient mobileAppClient = new("MobileClient", logHandler);
WebAppClient webAppClient = new("WebClient", logHandler);

broker.RegisterObserver(mobileAppClient);
broker.RegisterObserver(webAppClient);

broker.ExchangeRate = 96.5m;
broker.ExchangeRate = 95.4m;

broker.UnregisterObserver(mobileAppClient);

broker.ExchangeRate = 100m;

Console.WriteLine();


// Strategy
logHandler(new string('-', patternIndent) + " Strategy");

// 2%
BankTransaction bankTransaction = new(new PercentageFeeStrategy(0.02m), logHandler);

bankTransaction.ProcessTransaction(100);

bankTransaction.SetFeeStrategy(new FixedFeeStrategy(5));

bankTransaction.ProcessTransaction(100);

Console.WriteLine();


// Command
logHandler(new string('-', patternIndent) + " Command");

//SomeBankAccount bankAccount = new(logHandler);  -- right way is using proxy
SomeBankCommandManager bankCommandManager = new(logHandler);

DepositCommand depositCommand = new((BankAccountProxy)accountProxyUser, 100m);
WithdrawCommand withdrawCommand = new((BankAccountProxy)accountProxyUser, 50m);

bankCommandManager.ExecuteCommand(depositCommand);
bankCommandManager.ExecuteCommand(withdrawCommand);

bankCommandManager.GetHistory();

bankCommandManager.UndoLastCommand();
bankCommandManager.GetHistory();

bankCommandManager.ExecuteCommand(new WithdrawCommand((BankAccountProxy)accountProxyUser, 110m));

bankCommandManager.GetHistory();

bankCommandManager.ExecuteCommand(new WithdrawCommand((BankAccountProxy)accountProxyUser, 1100m));
bankCommandManager.GetHistory();

Console.WriteLine();


// State
logHandler(new string('-', patternIndent) + " State");

Problem problem = new(logHandler); // state -> New

problem.Start();    // state -> In progress
problem.Start();

problem.Review();   // state -> Review
problem.Review();

problem.Complete(); // state -> Completed

problem.Review();

Console.WriteLine();


// Chain of Responsibility
logHandler(new string('-', patternIndent) + " Chain of Responsibility");

BankTransactionCOR bankTransactionCOR = new(200m, "acc12", 500m, 300m);

BalanceCheckHandler balanceCheck = new(logHandler);

balanceCheck
    .SetNext(new LimitCheckHandler(logHandler))
    .SetNext(new LoggingTransactionHandler(logHandler))
    .SetNext(new CompleteTransactionHandler(logHandler));

balanceCheck.Handle(bankTransactionCOR);

Console.WriteLine();


// Thread pool
logHandler(new string('-', patternIndent) + " Thread pool");

CreditAppManager creditAppManager = new(logHandler);

for(int i = 0; i <= 5; i++)
{
    creditAppManager.AddTask(
        new CreaditAppProgress(
            new BankCreditApp(i, $"App {i}", i * 1000),
            logHandler
        )
    );
}

creditAppManager.StartProcessing(3);

Thread.Sleep(100);

creditAppManager.StopProcessing();

creditAppManager.StartProcessing(2);

logHandler("All credit applications have been processed.");

Console.WriteLine();