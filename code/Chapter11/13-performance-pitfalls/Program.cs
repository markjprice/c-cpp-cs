List<Action> actions = [];

for (int i = 0; i < 5; i++)
{
  int captured = i;
  actions.Add(() => Console.WriteLine(captured));
}

foreach (Action action in actions) action();

List<int> numbers = [1, 2, 3, 4, 5];

var query = numbers.Where(n =>
{
  Console.WriteLine($"Filtering {n}");
  return n > 0;
});

Console.WriteLine(query.Count());
Console.WriteLine(query.Sum());

var materialized = query.ToList();
Console.WriteLine(materialized.Count);
Console.WriteLine(materialized.Sum());

object boxed = 10;
Console.WriteLine(boxed);

var nonGeneric = new System.Collections.ArrayList();
nonGeneric.Add(10);
nonGeneric.Add(20);

foreach (object item in nonGeneric) Console.WriteLine(item);

var totalWithLinq = numbers.Where(n => n > 0).Select(n => n * 2).Sum();

int totalWithLoop = 0;
foreach (int number in numbers)
{
  if (number > 0) totalWithLoop += number * 2;
}

Console.WriteLine($"LINQ total: {totalWithLinq}");
Console.WriteLine($"Loop total: {totalWithLoop}");

int[] values = [10, 20, 30, 40, 50];
int[] middle = values[1..4];
Console.WriteLine(string.Join(", ", middle));

int last = values[^1];
Console.WriteLine(last);
