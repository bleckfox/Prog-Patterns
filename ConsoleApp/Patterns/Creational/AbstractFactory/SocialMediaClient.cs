namespace ConsoleApp.Patterns.Creational.AbstractFactory;

public class SocialMediaClient(ISocialMediaFactory factory, string username)
{
    private readonly IAccount _account = factory.CreateAccount(username);
    private readonly ISocialNetwork _socialNetwork = factory.CreateSocialNetwork();

    public void LoginAndPost(string message)
    {
        _account.Login();
        _socialNetwork.Post(message);
    }
}
