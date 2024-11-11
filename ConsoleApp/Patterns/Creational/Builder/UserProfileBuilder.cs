namespace ConsoleApp.Patterns.Creational.Builder;

public class UserProfileBuilder : IUserProfileBuilder
{
    private readonly UserProfile _userProfile = new();

    public IUserProfileBuilder SetFirstName(string firstName)
    {
        _userProfile.FirstName = firstName;
        return this;
    }

    public IUserProfileBuilder SetLastName(string lastName)
    {
        _userProfile.LastName = lastName;
        return this;
    }

    public IUserProfileBuilder SetAge(int age)
    {
        _userProfile.Age = age;
        return this;
    }

    public IUserProfileBuilder SetEmail(string email)
    {
        _userProfile.Email = email;
        return this;
    }

    public IUserProfileBuilder SetAddress(string address)
    {
        _userProfile.Address = address;
        return this;
    }

    public UserProfile Build() => _userProfile;
}
