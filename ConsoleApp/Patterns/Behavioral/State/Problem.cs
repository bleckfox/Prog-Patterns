using System.Threading.Tasks;

namespace ConsoleApp.Patterns.Behavioral.State;

public class Problem
{
    private IProblemState _state;
    private readonly LogHandler _logger;

    public Problem(LogHandler logger)
    {
        _logger = logger;
        _state = new NewProblemState(_logger);
    }

    public void SetState(IProblemState state) => _state = state;

    public void Start() => _state.Start(this);
    public void Review() => _state.Review(this);
    public void Complete() => _state.Complete(this);
}


public class NewProblemState(LogHandler logger) : IProblemState
{
    public void Start(Problem problem)
    {
        problem.SetState(new InProgressProblemState(logger));
        logger("Problem started and is now In Progress.");
    }

    public void Review(Problem problem)
    {
        logger("Cannot review task. Task is not in progress.");
    }

    public void Complete(Problem problem)
    {
        logger("Cannot complete task. Task is not in progress.");
    }
}


public class InProgressProblemState(LogHandler logger) : IProblemState
{
    public void Start(Problem problem)
    {
        logger("Problem is already in progress.");
    }

    public void Review(Problem problem)
    {
        problem.SetState(new InReviewProblemState(logger));
        logger("Problem is now under review.");
    }

    public void Complete(Problem problem)
    {
        logger("Problem needs to be reviewed before completing.");
    }
}


public class InReviewProblemState(LogHandler logger) : IProblemState
{
    public void Start(Problem problem)
    {
        logger("Problem is under review. Cannot restart.");
    }

    public void Review(Problem problem)
    {
        logger("Problem is already under review.");
    }

    public void Complete(Problem problem)
    {
        problem.SetState(new CompletedProblemState(logger));
        logger("Problem has been completed.");
    }
}


public class CompletedProblemState(LogHandler logger) : IProblemState
{
    public void Start(Problem problem)
    {
        logger("Problem is already completed. Cannot start.");
    }

    public void Review(Problem problem)
    {
        logger("Problem is completed. Cannot review.");
    }

    public void Complete(Problem problem)
    {
        logger("Problem is already completed.");
    }
}
