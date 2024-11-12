namespace ConsoleApp.Patterns.Structural.Composite;

public interface IAccountComponent
{
    void DisplayAccountInfo(string indent = "");
    decimal GetBalance();
}
