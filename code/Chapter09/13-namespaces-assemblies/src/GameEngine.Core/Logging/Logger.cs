namespace GameEngine.Logging;

public class Logger
{
    public void Write(string message)
    {
        Console.WriteLine($"[GameEngine] {message}");
    }
}
