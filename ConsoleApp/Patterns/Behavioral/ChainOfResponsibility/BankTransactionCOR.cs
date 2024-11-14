namespace ConsoleApp.Patterns.Behavioral.ChainOfResponsibility;

public class BankTransactionCOR(
    decimal amount, 
    string accountNumber, 
    decimal accountBalance,
    decimal transactionLimit
    )
{
    public decimal Amount { get; set; } = amount;
    public string AccountNumber { get; set; } = accountNumber;
    public decimal AccountBalance { get; set; } = accountBalance;
    public decimal TransactionLimit { get; set; } = transactionLimit;
}
