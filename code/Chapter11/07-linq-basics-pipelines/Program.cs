List<int> numbers = [1, 2, 3, 4, 5, 6];

List<int> evenNumbers = [];
foreach (int number in numbers)
{
  if (number % 2 == 0) evenNumbers.Add(number * 2);
}

Console.WriteLine("Loop result:");
Console.WriteLine(string.Join(", ", evenNumbers));

var linqEvenNumbers = numbers.Where(n => n % 2 == 0).Select(n => n * 2);
Console.WriteLine("LINQ result:");
Console.WriteLine(string.Join(", ", linqEvenNumbers));

var querySyntax = from n in numbers where n % 2 == 0 orderby n select n * 2;
Console.WriteLine("Query syntax:");
Console.WriteLine(string.Join(", ", querySyntax));

List<string> names = ["Mark", "Alice", "Bob", "Charlotte", "Eleanor"];
var longNames = names.Where(name => name.Length > 5).Select(name => name.ToUpper());
Console.WriteLine("Long names:");
Console.WriteLine(string.Join(", ", longNames));

var pipeline = numbers.Where(n => n > 2).OrderByDescending(n => n).Select(n => $"Value: {n}");
Console.WriteLine("Pipeline:");
foreach (string item in pipeline) Console.WriteLine(item);
