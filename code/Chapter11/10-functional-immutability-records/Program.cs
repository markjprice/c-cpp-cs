Person original = new("Alice", 30);
Person updated = original with { Age = 31 };

Console.WriteLine(original);
Console.WriteLine(updated);

Product p1 = new("Laptop", 1000M);
Product p2 = new("Laptop", 1000M);
Console.WriteLine($"Products equal: {p1 == p2}");

var (name, price) = p1;
Console.WriteLine($"{name}: {price:C}");

List<int> numbers = [1, 2, 3, 4];
var doubled = numbers.Select(n => n * 2);

Console.WriteLine(string.Join(", ", doubled));
Console.WriteLine(string.Join(", ", numbers));

var updatedNumbers = numbers.Append(10);
Console.WriteLine(string.Join(", ", updatedNumbers));

int total = numbers.Aggregate(0, (sum, value) => sum + value);
Console.WriteLine($"Total: {total}");

Console.WriteLine(Add(2, 3));
Console.WriteLine(Increment());
Console.WriteLine(Increment());

(string Name, int Age) tuple = GetPerson();
var (tupleName, tupleAge) = tuple;
Console.WriteLine($"{tupleName}, {tupleAge}");

static int Add(int x, int y) => x + y;

int counter = 0;
int Increment()
{
  counter++;
  return counter;
}

static (string Name, int Age) GetPerson() => ("Eleanor", 42);

public record Person(string Name, int Age);
public record Product(string Name, decimal Price);
