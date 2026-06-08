List<string> players = new();
players.Add("Alice");
players.Add("Bob");
players.Add("Charlie");

players.Remove("Bob");

foreach (string player in players)
{
    Console.WriteLine(player);
}

Dictionary<string, int> scores = new();
scores["Alice"] = 100;
scores["Bob"] = 85;

if (scores.TryGetValue("Bob", out int score))
{
    Console.WriteLine($"Bob scored {score}");
}

DisplayItem(42);
DisplayItem("Hello");
DisplayItem(true);

Pair<string, int> playerScore = new("Alice", 100);
Console.WriteLine($"{playerScore.First}: {playerScore.Second}");

Person person = new() { Name = "Mark" };
PrintName(person);

HashSet<string> uniqueNames = new()
{
    "Alice",
    "Bob",
    "Alice"
};

Console.WriteLine($"Unique names: {uniqueNames.Count}");

static void DisplayItem<T>(T item)
{
    Console.WriteLine(item);
}

static void PrintName<T>(T item)
    where T : Person
{
    Console.WriteLine(item.Name);
}

class Pair<TFirst, TSecond>
{
    public TFirst First { get; set; }
    public TSecond Second { get; set; }

    public Pair(TFirst first, TSecond second)
    {
        First = first;
        Second = second;
    }
}

class Person
{
    public string Name { get; set; } = "";
}
