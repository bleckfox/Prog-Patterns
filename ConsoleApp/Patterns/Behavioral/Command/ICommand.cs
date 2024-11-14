namespace ConsoleApp.Patterns.Behavioral.Command;

public interface ICommand
{
    public void Execute();
    public void Undo();
    public bool IsCanceled { get; set; }
}
