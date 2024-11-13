namespace ConsoleApp.Patterns.Structural.Facade;

public class BankingFacade(LogHandler logger)
{
    private readonly AccountVerification _verification = new(logger);
    private readonly TransactionProcessor _transactionProcessor = new(logger);
    private readonly NotificationService _notificationService = new(logger);

    private readonly LogHandler _logger = logger;

    public void Transfer(string fromAccount, string toAccount, decimal amount)
    {
        _logger($"Init Transfer");

        if (_verification.VerifyAccount(fromAccount) && _verification.VerifyAccount(toAccount))
        {
            _transactionProcessor.ProcessTransaction(fromAccount, toAccount, amount);
            _notificationService.SendNotification(fromAccount, $"Transfered amount {amount} to {toAccount}");
            _notificationService.SendNotification(toAccount, $"Received {amount} from {fromAccount}");
        }
    }
}
