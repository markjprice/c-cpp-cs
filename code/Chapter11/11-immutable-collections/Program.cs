using System.Collections.Immutable;

ImmutableList<int> values = ImmutableList.Create(1, 2, 3);
ImmutableList<int> updated = values.Add(4).Remove(2);

Console.WriteLine("Original:");
Console.WriteLine(string.Join(", ", values));

Console.WriteLine("Updated:");
Console.WriteLine(string.Join(", ", updated));

ImmutableDictionary<string, decimal> prices =
  ImmutableDictionary<string, decimal>.Empty
    .Add("Laptop", 1000M)
    .Add("Mouse", 25M);

ImmutableDictionary<string, decimal> discounted = prices.SetItem("Laptop", 900M);

Console.WriteLine($"Original laptop price: {prices["Laptop"]:C}");
Console.WriteLine($"Discounted laptop price: {discounted["Laptop"]:C}");

var builder = ImmutableList.CreateBuilder<string>();
builder.Add("Alice");
builder.Add("Bob");
builder.Add("Charlie");

ImmutableList<string> names = builder.ToImmutable();
Console.WriteLine(string.Join(", ", names));
