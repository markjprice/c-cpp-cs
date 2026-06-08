object value = "Hello";

if (value is string text)
{
  Console.WriteLine($"String length: {text.Length}");
}

int statusCode = 404;
string message = statusCode switch
{
  200 => "Success",
  404 => "Not Found",
  _ => "Unknown"
};
Console.WriteLine(message);

Console.WriteLine(DescribeTemperature(24));

(string action, bool isAdmin) command = ("Delete", false);
string authorization = command switch
{
  ("Delete", true) => "Allowed",
  ("Delete", false) => "Denied",
  ("View", _) => "Allowed",
  _ => "Unknown"
};
Console.WriteLine(authorization);

Person person = new("Alice", 30, "USA");
string category = person switch
{
  { Age: < 18 } => "Minor",
  { Country: "USA" } => "American Adult",
  _ => "Other"
};
Console.WriteLine(category);

Console.WriteLine(Describe(person));

int number = 42;
bool isValid = number is > 0 and < 100;
Console.WriteLine($"Number valid: {isValid}");

string day = "Saturday";
bool isWeekend = day is "Saturday" or "Sunday";
Console.WriteLine($"Weekend: {isWeekend}");

int[] values = [1, 2, 3, 4, 5];
Console.WriteLine(DescribeList(values));

Order order = new(new Customer("Northwind", new Address("Paris")));

if (order is { Customer: { Address: { City: "Paris" } } })
{
  Console.WriteLine("Order from Paris.");
}

static string DescribeTemperature(int temperature) => temperature switch
{
  int t when t < 0 => "Freezing",
  int t when t < 20 => "Cold",
  int t when t < 30 => "Warm",
  _ => "Hot"
};

static string Describe(Person person) => person switch
{
  ("Alice", 30, _) => "Matched Alice",
  (_, < 18, _) => "Young person",
  _ => "Unknown"
};

static string DescribeList(int[] numbers) => numbers switch
{
  [] => "Empty",
  [1] => "One item",
  [1, 2] => "Two items",
  [1, 2, 3] => "Three items",
  [1, ..] => "Starts with one",
  [_, _, ..] => "At least two items",
  _ => "Other"
};

public record Person(string Name, int Age, string Country);
public record Address(string City);
public record Customer(string Name, Address Address);
public record Order(Customer Customer);
