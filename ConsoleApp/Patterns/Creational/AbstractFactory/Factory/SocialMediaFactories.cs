namespace ConsoleApp.Patterns.Creational.AbstractFactory;

public class SocialMediaFactories { }

public class FacebookFactory(LogHandler logger) : ISocialMediaFactory
{
    public IAccount CreateAccount(string username) => new FacebookAccount(username, logger);

    public ISocialNetwork CreateSocialNetwork() => new FacebookSocialNetwork(logger);
}

public class TwitterFactory(LogHandler logger) : ISocialMediaFactory
{
    public IAccount CreateAccount(string username) => new TwitterAccount(username, logger);

    public ISocialNetwork CreateSocialNetwork() => new TwitterSocialNetwork(logger);
}

