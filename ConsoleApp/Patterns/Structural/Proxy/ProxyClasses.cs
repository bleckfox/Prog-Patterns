namespace ConsoleApp.Patterns.Structural.Proxy;

public class ProxyClasses { }


public class SomeBankAccount(LogHandler logger) : IBankAccount
{
    private readonly LogHandler _logger = logger;
    private decimal _balance;

    private BankTransactionStateEnum _bankTransactionState;

    public BankTransactionStateEnum BankTransactionState { get => _bankTransactionState; set => _bankTransactionState = value; }

    private void LogOperation(string operationType, decimal amount)
    {
        _logger($"{operationType} {amount}. New balace is {_balance}");
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
        LogOperation("Deposited", amount);
        BankTransactionState = BankTransactionStateEnum.Success;
    }

    public void Withdraw(decimal amount)
    {
        if (_balance >= amount)
        {
            _balance -= amount;
            LogOperation("Withdrew", amount);
            BankTransactionState = BankTransactionStateEnum.Success;
        }
        else
        {
            _logger($"Insufficient money");
            BankTransactionState = BankTransactionStateEnum.Canceled;
        }
    }

    public decimal GetBalance() => _balance;
}


public class BankAccountProxy(IBankAccount bankAccount, string role, LogHandler logger) : IBankAccount
{
    private readonly IBankAccount _bankAccount = bankAccount;
    private readonly string _role = role;
    private readonly LogHandler _logger = logger;

    private BankTransactionStateEnum _transactionState;

    public BankTransactionStateEnum BankTransactionState { get => _transactionState; set => _transactionState = value; }

    public void Deposit(decimal amount)
    {
        if (_role == "Admin" || _role == "User")
        {
            _bankAccount.Deposit(amount);
            BankTransactionState = _bankAccount.BankTransactionState;
        }
        else
        {
            _logger("Access denied: Insufficient permissions for Deposit.");
            BankTransactionState = BankTransactionStateEnum.Canceled;
        }
    }

    public void Withdraw(decimal amount)
    {
        if (_role == "Admin" || _role == "User")
        {
            _bankAccount.Withdraw(amount);
            BankTransactionState = _bankAccount.BankTransactionState;
        }
        else
        {
            _logger("Access denied: Insufficient permissions for Withdraw.");
            BankTransactionState = BankTransactionStateEnum.Canceled;
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
            BankTransactionState = BankTransactionStateEnum.Canceled;
            return 0;
        }
    }
}
