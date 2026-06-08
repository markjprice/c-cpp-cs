Player player1 = new() { Name = "Alice" };
Player player2 = new() { Name = "Bob" };

Console.WriteLine($"{player1.Name}, {player2.Name}");
Console.WriteLine($"Player count: {Player.PlayerCount}");

int sum = Calculator.Add(5, 3);
Console.WriteLine($"Sum: {sum}");

Console.WriteLine($"Configuration version: {Configuration.Version}");
Console.WriteLine(StringUtilities.Reverse("CSharp"));

int health = GameMath.Clamp(150, 0, 100);
Console.WriteLine($"Clamped health: {health}");

Console.WriteLine($"Debug mode: {Settings.DebugMode}");

class Player
{
    public static int PlayerCount = 0;
    public string Name { get; set; } = "";

    public Player()
    {
        PlayerCount++;
    }
}

class Calculator
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}

class Configuration
{
    public static string Version;

    static Configuration()
    {
        Version = "1.0";
    }
}

static class StringUtilities
{
    public static string Reverse(string text)
    {
        char[] chars = text.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}

static class GameMath
{
    public static int Clamp(int value, int min, int max)
    {
        if (value < min)
        {
            return min;
        }

        if (value > max)
        {
            return max;
        }

        return value;
    }
}

class Settings
{
    public static bool DebugMode = true;
}
