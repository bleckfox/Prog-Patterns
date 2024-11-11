namespace ConsoleApp.Patterns.Creational.Builder;

public class UserProfileDirector(IUserProfileBuilder builder)
{
    private readonly IUserProfileBuilder _builder = builder;

    public UserProfile BuildDefaultProfile()
    {
        return _builder
            .SetFirstName("Default")
            .SetLastName("User")
            .SetAge(25)
            .SetEmail("default@example.com")
            .SetAddress("123 Main Street")
            .Build();
    }
}
