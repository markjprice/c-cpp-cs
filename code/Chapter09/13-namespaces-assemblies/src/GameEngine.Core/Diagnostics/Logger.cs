namespace Company.Diagnostics;

public class Logger
{
    public void Write(string message)
    {
        Console.WriteLine($"[Diagnostics] {message}");
    }
}
