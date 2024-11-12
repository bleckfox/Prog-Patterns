namespace ConsoleApp.Patterns.Structural.Facade;

public class BankingFacade()
{
    private readonly AccountVerification _verification = new();
    private readonly TransactionProcessor _transactionProcessor = new();
    private readonly NotificationService _notificationService = new();

    public void Transfer(string fromAccount, string toAccount, decimal amount)
    {
        Creational.Singleton.SingletonLogger.Instance.Log($"Init Transfer");

        if (_verification.VerifyAccount(fromAccount) && _verification.VerifyAccount(toAccount))
        {
            _transactionProcessor.ProcessTransaction(fromAccount, toAccount, amount);
            _notificationService.SendNotification(fromAccount, $"Transfered amount {amount} to {toAccount}");
            _notificationService.SendNotification(toAccount, $"Received {amount} from {fromAccount}");
        }
    }
}
