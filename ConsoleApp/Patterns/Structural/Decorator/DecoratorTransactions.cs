namespace ConsoleApp.Patterns.Structural.Decorator;

public class DecoratorTransactions { }


public class BaseTransaction(decimal amount, LogHandler logger) : ITransaction
{
    public readonly decimal Amount = amount;

    public void Process()
    {
        logger($"Processing transaction of amount {Amount}");
    }
}


public abstract class TransactionDecorator(ITransaction transaction) : ITransaction
{
    public ITransaction InnerTransaction = transaction;

    public virtual void Process() => InnerTransaction.Process();
}


public class LoggingTransactionDecorator(ITransaction transaction, LogHandler logger) : TransactionDecorator(transaction)
{
    public override void Process()
    {
        logger($"Logging transaction");
        base.Process();
    }
}


public class NotificationTransactionDecorator(ITransaction transaction, LogHandler logger) : TransactionDecorator(transaction)
{
    public override void Process()
    {
        base.Process();
        logger($"Sending notification about transaction");
    }
}


public class LimitCheckTransactionDecorator(ITransaction transaction, decimal limit, LogHandler logger) : TransactionDecorator(transaction)
{
    private readonly decimal _limit = limit;

    public override void Process()
    {
        BaseTransaction? baseTransaction = GetBaseTransaction(transaction);
        if (baseTransaction != null && baseTransaction!.Amount > _limit)
        {
            logger($"Transaction {baseTransaction.Amount} exceed limit {_limit}, canceling transaction");
        }
        else
        {
            base.Process();
        }
    }

    private BaseTransaction? GetBaseTransaction(ITransaction transaction)
    {
        if (transaction is BaseTransaction baseTransaction)
        { 
            return baseTransaction; 
        }

        if (transaction is TransactionDecorator transactionDecorator)
        {
            return GetBaseTransaction(transactionDecorator.InnerTransaction); 
        }

        return null;
    }
}
