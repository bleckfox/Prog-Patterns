using ConsoleApp.Patterns.Structural.Proxy;

namespace ConsoleApp.Patterns.Behavioral.Command;

public class Commands { }


public class DepositCommand(BankAccountProxy bankAccount, decimal amount) : ICommand
{
    private readonly BankAccountProxy _bankAccount = bankAccount;
    private readonly decimal _amount = amount;

    private bool _isCanceled;

    public bool IsCanceled { get => _isCanceled; set => _isCanceled = value; }

    public void Execute()
    {
        _bankAccount.Deposit(_amount);
        IsCanceled = _bankAccount.BankTransactionState == BankTransactionStateEnum.Canceled || _bankAccount.BankTransactionState == BankTransactionStateEnum.None;
    }

    public void Undo()
    {
        _bankAccount.Withdraw(_amount);
        IsCanceled = _bankAccount.BankTransactionState == BankTransactionStateEnum.Canceled || _bankAccount.BankTransactionState == BankTransactionStateEnum.None;
    }
}



public class WithdrawCommand(BankAccountProxy bankAccount, decimal amount) : ICommand
{
    private readonly BankAccountProxy _bankAccount = bankAccount;
    private readonly decimal _amount = amount;

    private bool _isCanceled;

    public bool IsCanceled { get => _isCanceled; set => _isCanceled = value; }

    public void Execute()
    {
        _bankAccount.Withdraw(_amount);
        IsCanceled = _bankAccount.BankTransactionState == BankTransactionStateEnum.Canceled || _bankAccount.BankTransactionState == BankTransactionStateEnum.None;
    }

    public void Undo()
    {
        _bankAccount.Deposit(_amount);
        IsCanceled = _bankAccount.BankTransactionState == BankTransactionStateEnum.Canceled || _bankAccount.BankTransactionState == BankTransactionStateEnum.None;
    }
}



public class SomeBankCommandManager(LogHandler logger)
{
    private readonly Stack<ICommand> _commandsHistory = [];
    private readonly LogHandler _logger = logger;

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        if (!command.IsCanceled)
        {
            _commandsHistory.Push(command);
        }
    }

    public void UndoLastCommand()
    {
        if (_commandsHistory.Count > 0)
        {
            ICommand command = _commandsHistory.Pop();
            command.Undo();
        }
    }

    public void GetHistory()
    {
        _logger(new string('-', 5) + " account history");
        foreach (ICommand command in _commandsHistory)
        {
            _logger($"{command.GetType()}");
        }
        _logger(new string('-', 5));
    }
}

