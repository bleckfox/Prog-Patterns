namespace ConsoleApp.Patterns.Creational.AbstractFactory;

public class SocialNetworks(LogHandler logger)
{
    private List<ISocialNetwork> _networks = [];

    protected readonly LogHandler _logger = logger;

    protected void AddSocialNetworkToList(ISocialNetwork network) => _networks.Add(network);

    public List<ISocialNetwork> GetSocialNetworks() => _networks;
}

public class FacebookSocialNetwork(LogHandler logger) : SocialNetworks(logger), ISocialNetwork
{
    public void Post(string message)
    {
        AddSocialNetworkToList(this);
        _logger($"Posting '{message}' to Facebook");
    }
}

public class TwitterSocialNetwork(LogHandler logger) : SocialNetworks(logger), ISocialNetwork
{
    public void Post(string message)
    {
        AddSocialNetworkToList(this);
        _logger($"Posting '{message}' to Twitter");
    }
}
