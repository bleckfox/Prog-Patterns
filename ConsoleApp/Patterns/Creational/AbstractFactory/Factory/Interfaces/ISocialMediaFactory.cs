namespace ConsoleApp.Patterns.Creational.AbstractFactory;

public interface ISocialMediaFactory
{
    IAccount CreateAccount(string username);
    ISocialNetwork CreateSocialNetwork();
}
