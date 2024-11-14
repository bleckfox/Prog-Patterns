namespace ConsoleApp.Patterns.Behavioral.ChainOfResponsibility;

public class Handlers { }


public abstract class TransactionHandler : ITransactionHandler
{
    private ITransactionHandler? _nextHandler;

    public virtual void Handle(BankTransactionCOR transaction)
    {
        _nextHandler?.Handle(transaction);
    }

    public ITransactionHandler SetNext(ITransactionHandler next)
    {
        _nextHandler = next;
        return next;
    }
}


public class BalanceCheckHandler(LogHandler logger) : TransactionHandler
{
    public override void Handle(BankTransactionCOR transaction)
    {
        if (transaction.AccountBalance >= transaction.Amount)
        {
            logger("Balance check passed.");
            base.Handle(transaction);
        }
        else
        {
            logger("Balance check failed: Insufficient money");
        }
    }
}


public class LimitCheckHandler(LogHandler logger) : TransactionHandler
{
    public override void Handle(BankTransactionCOR transaction)
    {
        if (transaction.Amount <= transaction.TransactionLimit)
        {
            logger("Limit check passed.");
            base.Handle(transaction);
        }
        else
        {
            logger("Limit check failed: Amount exceeds limit");
        }
    }
}


public class LoggingTransactionHandler(LogHandler logger) : TransactionHandler
{
    public override void Handle(BankTransactionCOR transaction)
    {
        logger($"Logging transaction of amount {transaction.Amount} for account {transaction.AccountNumber}");
        base.Handle(transaction);
    }
}


public class CompleteTransactionHandler(LogHandler logger) : TransactionHandler
{
    public override void Handle(BankTransactionCOR transaction)
    {
        logger($"Transaction completed successfully for account {transaction.AccountNumber}");
    }
}
