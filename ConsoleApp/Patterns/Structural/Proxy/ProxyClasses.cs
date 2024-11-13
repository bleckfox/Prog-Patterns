namespace ConsoleApp.Patterns.Structural.Proxy;

public class ProxyClasses { }


public class SomeBankAccount(LogHandler logger) : IBankAccount
{
    private readonly LogHandler _logger = logger;
    private decimal _balance;

    private void LogOperation(string operationType, decimal amount)
    {
        _logger($"{operationType} {amount}. New balace is {_balance}");
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
            _logger($"Insufficient money");
        }
    }

    public decimal GetBalance() => _balance;
}


public class BankAccountProxy(IBankAccount bankAccount, string role, LogHandler logger) : IBankAccount
{
    private readonly IBankAccount _bankAccount = bankAccount;
    private readonly string _role = role;
    private readonly LogHandler _logger = logger;

    public void Deposit(decimal amount)
    {
        if (_role == "Admin" || _role == "User")
        {
            _bankAccount.Deposit(amount);
        }
        else
        {
            _logger("Access denied: Insufficient permissions for Deposit.");
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
            _logger("Access denied: Insufficient permissions for Withdraw.");
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
            _logger("Access denied: Insufficient permissions to view balance.");
            return 0;
        }
    }
}
