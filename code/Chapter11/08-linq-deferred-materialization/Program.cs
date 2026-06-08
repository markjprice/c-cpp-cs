List<int> numbers = [1, 2, 3];

var query = numbers.Where(n =>
{
  Console.WriteLine($"Filtering {n}");
  return n > 1;
});

Console.WriteLine("Query created.");
numbers.Add(10);

Console.WriteLine("Enumerating deferred query:");
foreach (int value in query) Console.WriteLine(value);

List<int> snapshot = numbers.Where(n => n > 1).ToList();
numbers.Add(20);

Console.WriteLine("Snapshot after source changes:");
Console.WriteLine(string.Join(", ", snapshot));

int count = 0;
var sideEffectQuery = numbers.Select(n =>
{
  count++;
  return n * 2;
});

Console.WriteLine($"Before enumeration: {count}");
foreach (var value in sideEffectQuery) { }
Console.WriteLine($"After first enumeration: {count}");
foreach (var value in sideEffectQuery) { }
Console.WriteLine($"After second enumeration: {count}");

var materialized = sideEffectQuery.ToList();
Console.WriteLine($"Materialized count: {materialized.Count}");
