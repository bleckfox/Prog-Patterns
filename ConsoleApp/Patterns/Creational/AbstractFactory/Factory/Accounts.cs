namespace ConsoleApp.Patterns.Creational.AbstractFactory;

public class Accounts
{
    private readonly static List<IAccount> _accounts = [];

    protected static void AddAccounntToList(IAccount account) => _accounts.Add(account);

    public void GetAcccountsList()
    {
        _accounts.ForEach(account =>
        {
            Console.WriteLine($"account -> {account.GetType()}");
        });
    }
}

public class FacebookAccount(string username) : Accounts, IAccount
{
    public string UserName { get; private set; } = username;

    public void Login()
    {
        AddAccounntToList(this);
        Console.WriteLine($"Logging into Facebook as {UserName}");
    }
}


public class TwitterAccount(string username) : Accounts, IAccount
{
    public string UserName { get; private set; } = username;

    public void Login()
    {
        AddAccounntToList(this);
        Console.WriteLine($"Logging into Twitter as {UserName}");
    }
}