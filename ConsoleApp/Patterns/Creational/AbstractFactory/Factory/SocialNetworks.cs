namespace ConsoleApp.Patterns.Creational.AbstractFactory;

public class SocialNetworks
{
    private List<ISocialNetwork> _networks = [];

    protected void AddSocialNetworkToList(ISocialNetwork network) => _networks.Add(network);

    public List<ISocialNetwork> GetSocialNetworks() => _networks;
}

public class FacebookSocialNetwork : SocialNetworks, ISocialNetwork
{
    public void Post(string message)
    {
        AddSocialNetworkToList(this);
        Console.WriteLine($"Posting '{message}' to Facebook");
    }
}

public class TwitterSocialNetwork : SocialNetworks, ISocialNetwork
{
    public void Post(string message)
    {
        AddSocialNetworkToList(this);
        Console.WriteLine($"Posting '{message}' to Twitter");
    }
}
