namespace ConsoleApp.Patterns.Behavioral.ChainOfResponsibility;

public interface ITransactionHandler
{
    ITransactionHandler SetNext(ITransactionHandler next);
    public void Handle(BankTransactionCOR transaction);
}
