namespace ConsoleApp.Patterns.Creational.Builder;

public interface IUserProfileBuilder
{
    IUserProfileBuilder SetFirstName(string firstName);
    IUserProfileBuilder SetLastName(string lastName);
    IUserProfileBuilder SetAge(int age);
    IUserProfileBuilder SetEmail(string email);
    IUserProfileBuilder SetAddress(string address);
    UserProfile Build();
}

