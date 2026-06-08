Point p1 = new() { X = 10, Y = 20 };
Point p2 = p1;
p2.X = 99;

Console.WriteLine($"p1.X: {p1.X}");
Console.WriteLine($"p2.X: {p2.X}");

Ship s1 = new() { Name = "Enterprise" };
Ship s2 = s1;
s2.Name = "Voyager";

Console.WriteLine($"s1.Name: {s1.Name}");
Console.WriteLine($"s2.Name: {s2.Name}");
Console.WriteLine($"ReferenceEquals(s1, s2): {ReferenceEquals(s1, s2)}");

Person a = new("Benjamin Sisko");
Person b = new("Benjamin Sisko");
Person c = a;

Console.WriteLine($"ReferenceEquals(a, b): {ReferenceEquals(a, b)}");
Console.WriteLine($"ReferenceEquals(a, c): {ReferenceEquals(a, c)}");

public struct Point
{
  public int X;
  public int Y;
}

public sealed class Ship
{
  public string Name { get; set; } = "";
}

public sealed record Person(string Name);
