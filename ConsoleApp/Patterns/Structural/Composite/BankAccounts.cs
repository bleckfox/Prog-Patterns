﻿namespace ConsoleApp.Patterns.Structural.Composite;

public class BankAccounts { }


public class DebitAccount(string accountNumber, decimal amount) : IAccountComponent
{
    private string _accountNumber = accountNumber;
    private decimal _balance = amount;

    public void DisplayAccountInfo(string indent = "")
    {
        Creational.Singleton.SingletonLogger.Instance.Log($"{indent}{nameof(DebitAccount)} {_accountNumber} - Balance: {_balance}");
    }

    public decimal GetBalance() => _balance;
}


public class SavingAccount(string accountNumber, decimal amount) : IAccountComponent
{
    private string _accountNumber = accountNumber;
    private decimal _balance = amount;

    public void DisplayAccountInfo(string indent = "")
    {
        Creational.Singleton.SingletonLogger.Instance.Log($"{indent}{nameof(SavingAccount)} {_accountNumber} - Balance: {_balance}");
    }

    public decimal GetBalance() => _balance;
}


public class AccountPackage(string packageName) : IAccountComponent
{
    private readonly string _packageName = packageName;
    private List<IAccountComponent> _accounts = [];


    public void DisplayAccountInfo(string indent = "")
    {
        Creational.Singleton.SingletonLogger.Instance.Log(string.Join("", indent, nameof(AccountPackage), ": ", _packageName));

        _accounts.ForEach(account =>
        {
            account.DisplayAccountInfo(indent + "  ");
        });
    }

    public decimal GetBalance()
    {
        decimal total = 0;

        _accounts.ForEach(account =>
        {
            total += account.GetBalance();
        });

        return total;
    }

    public void AddAccount(IAccountComponent account) => _accounts.Add(account);
}
