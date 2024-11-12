namespace ConsoleApp.Patterns.Structural.Facade;

public class FacadeClasses { }

public class AccountVerification
{
    public bool VerifyAccount(string accountId)
    {
        Creational.Singleton.SingletonLogger.Instance.Log($"Verifying account {accountId}");
        return true;
    }
}

public class TransactionProcessor
{
    public void ProcessTransaction(string fromAccount, string toAccount, decimal amount)
    {
        Creational.Singleton.SingletonLogger.Instance.Log($"Processing transaction from {fromAccount} to {toAccount} of amount {amount}");
    }
}


public class NotificationService
{
    public void SendNotification(string accountId, string message)
    {
        Creational.Singleton.SingletonLogger.Instance.Log($"Sending notification to {accountId}: {message}");
    }
}
