using System.Text.Json;

namespace ConsoleApp.Patterns.Creational.Builder;

public class UserProfile
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;

    public override string ToString() => JsonSerializer.Serialize(this);
}

