using System;

interface IOldLogger
{
    void LogMessage(string message);
}

interface INewLogger
{
    void LogMessage(string message);
}
public class NewLogger : INewLogger
{
    public void LogMessage(string message)
    {
        Console.WriteLine("{0}", message);
    }
}

class LoggerAdapter : IOldLogger
{
    private readonly INewLogger _newLogger;

    public LoggerAdapter(INewLogger newLogger)
    {
        _newLogger = newLogger;
    }

    public void LogMessage(string message)
    {
        _newLogger.LogMessage(message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        INewLogger newLogger = new NewLogger();

        IOldLogger adapter = new LoggerAdapter(newLogger);

        adapter.LogMessage("Komunikat 1");
        adapter.LogMessage("Komunikat 2");
    }
}
