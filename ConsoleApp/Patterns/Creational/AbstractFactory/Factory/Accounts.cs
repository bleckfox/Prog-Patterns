namespace ConsoleApp.Patterns.Creational.AbstractFactory;

public class Accounts(LogHandler logger)
{
    protected readonly LogHandler _logger = logger;

    private readonly static List<IAccount> _accounts = [];

    protected static void AddAccounntToList(IAccount account) => _accounts.Add(account);

    public void GetAcccountsList()
    {
        _accounts.ForEach(account =>
        {
            _logger($"account -> {account.GetType()}");
        });
    }
}

public class FacebookAccount(string username, LogHandler logger) : Accounts(logger), IAccount
{
    public string UserName { get; private set; } = username;

    public void Login()
    {
        AddAccounntToList(this);
        _logger($"Logging into Facebook as {UserName}");
    }
}


public class TwitterAccount(string username, LogHandler logger) : Accounts(logger), IAccount
{
    public string UserName { get; private set; } = username;

    public void Login()
    {
        AddAccounntToList(this);
        _logger($"Logging into Twitter as {UserName}");
    }
}