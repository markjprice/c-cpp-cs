List<string> names = new();
names.Add("Alice");
names.Add("Bob");

Dictionary<string, List<int>> data = new()
{
  ["Engineering"] = [90, 95, 100],
  ["Sales"] = [70, 80]
};

int[] first = [1, 2];
int[] second = [.. first, 3, 4];
Console.WriteLine(string.Join(", ", second));

Customer customer = new() { Name = "Alice" };
Console.WriteLine(customer.Name);

Product product = new("Laptop", 1000M);
Console.WriteLine(product.DisplayName);

string name = "Alice";
string json = $$"""
{
  "name": "{{name}}",
  "items": {{second.Length}}
}
""";

Console.WriteLine(json);

var report = new ReportBuilder("Sales").Build();
Console.WriteLine(report);

public class Product(string name, decimal price)
{
  public string Name { get; } = name;
  public decimal Price { get; } = price;
  public string DisplayName => $"{Name}: {Price:C}";
}

public class Customer
{
  public required string Name { get; init; }
}

public class ReportBuilder(string title)
{
  public string Build() => $"Report: {title}";
}
