using System.Collections.Concurrent;

namespace ConsoleApp.Patterns.Concurrency.ThreadPool;

public class BankCreditApp(int id, string appName, decimal requestAmount)
{
    public int Id { get; set; } = id;
    public string AppName {  get; set; } = appName;
    public decimal RequestAmount { get; set; } = requestAmount;
}


public class CreaditAppProgress(BankCreditApp bankCreditApp, LogHandler logger) : IBankCreditApp
{
    private readonly BankCreditApp _bankCreditApp = bankCreditApp;

    public void Process()
    {
        logger($"[Thread {Environment.CurrentManagedThreadId}] Processing app ID: {_bankCreditApp.Id} for {_bankCreditApp.AppName}");

        AssessCreditWorthiness();
        CheckCreditHistory();
        MakeFinalDecision();

        logger($"[Thread {Environment.CurrentManagedThreadId}] Application ID: {_bankCreditApp.Id} processed successfully");
    }

    private void AssessCreditWorthiness()
    {
        logger($"[Thread {Environment.CurrentManagedThreadId}] Assessing creditworthiness for {_bankCreditApp.AppName}");
        Thread.Sleep(1000); // Имитация обработки
    }

    private void CheckCreditHistory()
    {
        logger($"[Thread {Environment.CurrentManagedThreadId}] Checking credit history for {_bankCreditApp.AppName}");
        Thread.Sleep(1000); // Имитация обработки
    }

    private void MakeFinalDecision()
    {
        logger($"[Thread {Environment.CurrentManagedThreadId}] Making final decision for {_bankCreditApp.AppName}");
        Thread.Sleep(1000); // Имитация обработки
    }
}


public class CreditAppManager(LogHandler logger)
{
    private readonly ConcurrentQueue<IBankCreditApp> _taskQueue = new();

    private bool _isRunning = true;

    public void AddTask(IBankCreditApp task)
    {
        _taskQueue.Enqueue(task);
        logger("Credit application task added to queue.");
    }

    public void StartProcessing(int theadCount)
    {
        for (int i = 0; i < theadCount; i++)
        {
            Task.Run(ProcessTasks);
        }
    }

    public void StopProcessing() =>_isRunning = false;

    private void ProcessTasks()
    {
        while (_isRunning || !_taskQueue.IsEmpty)
        {
            if (_taskQueue.TryDequeue(out var task))
            {
                task.Process();
            }
            else
            {
                Thread.Sleep(100);
            }
        }
    }
}
