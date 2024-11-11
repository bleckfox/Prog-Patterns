namespace ConsoleApp.Patterns.Creational.AbstractFactory;

public class SocialMediaFactories { }

public class FacebookFactory : ISocialMediaFactory
{
    public IAccount CreateAccount(string username) => new FacebookAccount(username);

    public ISocialNetwork CreateSocialNetwork() => new FacebookSocialNetwork();
}

public class TwitterFactory : ISocialMediaFactory
{
    public IAccount CreateAccount(string username) => new TwitterAccount(username);

    public ISocialNetwork CreateSocialNetwork() => new TwitterSocialNetwork();
}

