namespace ConsoleApp.Patterns.Structural.Facade;

public class FacadeClasses { }

public class AccountVerification(LogHandler logger)
{
    public bool VerifyAccount(string accountId)
    {
        logger($"Verifying account {accountId}");
        return true;
    }
}

public class TransactionProcessor(LogHandler logger)
{
    public void ProcessTransaction(string fromAccount, string toAccount, decimal amount)
    {
        logger($"Processing transaction from {fromAccount} to {toAccount} of amount {amount}");
    }
}


public class NotificationService(LogHandler logger)
{
    public void SendNotification(string accountId, string message)
    {
        logger($"Sending notification to {accountId}: {message}");
    }
}
