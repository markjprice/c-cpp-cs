Console.WriteLine("Basic try/catch:");
try
{
    int number = int.Parse("abc");
    Console.WriteLine(number);
}
catch
{
    Console.WriteLine("An error occurred.");
}

Console.WriteLine("Specific exception:");
try
{
    int number = int.Parse("abc");
    Console.WriteLine(number);
}
catch (FormatException ex)
{
    Console.WriteLine($"Invalid number format: {ex.Message}");
}

Console.WriteLine("Multiple catch blocks:");
try
{
    string[] names = { "Alice" };
    Console.WriteLine(names[5]);
}
catch (FormatException)
{
    Console.WriteLine("Format error.");
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("Invalid index.");
}

Console.WriteLine("finally block:");
try
{
    Console.WriteLine("Processing...");
}
catch
{
    Console.WriteLine("Error.");
}
finally
{
    Console.WriteLine("Cleanup complete.");
}

Console.WriteLine("Validation instead of exceptions for expected input:");
string userInput = "42";
if (int.TryParse(userInput, out int parsed))
{
    Console.WriteLine(parsed);
}
else
{
    Console.WriteLine("Invalid input.");
}

Console.WriteLine("Throwing and catching a custom exception:");
try
{
    ValidateLevel(-1);
}
catch (InvalidLevelException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("using statement with a disposable resource:");
string path = "data.txt";
File.WriteAllText(path, "Hello from a file.");
using StreamReader reader = new(path);
string text = reader.ReadToEnd();
Console.WriteLine(text);

static void ValidateLevel(int level)
{
    if (level < 0)
    {
        throw new InvalidLevelException("Level cannot be below zero.");
    }
}

class InvalidLevelException : Exception
{
    public InvalidLevelException(string message)
        : base(message)
    {
    }
}
