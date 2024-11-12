namespace ConsoleApp.Patterns.Structural.Proxy;

public class ProxyClasses { }


public class SomeBankAccount : IBankAccount
{
    private decimal _balance;

    private void LogOperation(string operationType, decimal amount)
    {
        Creational.Singleton.SingletonLogger.Instance.Log($"{operationType} {amount}. New balace is {_balance}");
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
        LogOperation("Deposited", amount);
    }

    public void Withdraw(decimal amount)
    {
        if (_balance >= amount)
        {
            _balance -= amount;
            LogOperation("Withdrew", amount);
        }
        else
        {
            Creational.Singleton.SingletonLogger.Instance.Log($"Insufficient money");
        }
    }

    public decimal GetBalance() => _balance;
}


public class BankAccountProxy(IBankAccount bankAccount, string role) : IBankAccount
{
    private readonly IBankAccount _bankAccount = bankAccount;
    private readonly string _role = role;

    public void Deposit(decimal amount)
    {
        if (_role == "Admin" || _role == "User")
        {
            _bankAccount.Deposit(amount);
        }
        else
        {
            Creational.Singleton.SingletonLogger.Instance.Log("Access denied: Insufficient permissions for Deposit.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (_role == "Admin" || _role == "User")
        {
            _bankAccount.Withdraw(amount);
        }
        else
        {
            Creational.Singleton.SingletonLogger.Instance.Log("Access denied: Insufficient permissions for Withdraw.");
        }
    }

    public decimal GetBalance()
    {
        if (_role == "Admin" || _role == "User" || _role == "Viewer")
        {
            return _bankAccount.GetBalance();
        }
        else
        {
            Creational.Singleton.SingletonLogger.Instance.Log("Access denied: Insufficient permissions to view balance.");
            return 0;
        }
    }
}
