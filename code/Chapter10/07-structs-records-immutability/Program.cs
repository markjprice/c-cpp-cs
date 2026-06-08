Point p1 = new() { X = 10, Y = 20 };
Point p2 = p1;
p2.X = 99;

Console.WriteLine($"p1.X: {p1.X}");
Console.WriteLine($"p2.X: {p2.X}");

Coordinate coordinate = new(5, 8);
Console.WriteLine($"{coordinate.X}, {coordinate.Y}");

Person person = new("Mark", "Price");
Console.WriteLine(person);

Player player1 = new() { Name = "Alice" };
Player player2 = new() { Name = "Alice" };
Console.WriteLine($"Class reference equality: {player1 == player2}");

Person person1 = new("Mark", "Price");
Person person2 = new("Mark", "Price");
Console.WriteLine($"Record value equality: {person1 == person2}");

Difficulty level = Difficulty.Hard;
Console.WriteLine($"Difficulty: {level}");

struct Point
{
    public int X;
    public int Y;
}

readonly struct Coordinate
{
    public int X { get; }
    public int Y { get; }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}

record Person(string FirstName, string LastName);

class Player
{
    public string Name { get; set; } = "";
}

enum Difficulty
{
    Easy,
    Medium,
    Hard
}
