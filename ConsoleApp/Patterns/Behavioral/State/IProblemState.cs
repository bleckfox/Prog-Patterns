namespace ConsoleApp.Patterns.Behavioral.State;

public interface IProblemState
{
    public void Start(Problem problem);
    public void Review(Problem problem);
    public void Complete(Problem problem);
}
