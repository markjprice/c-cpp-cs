using System;
using System.Text;

List<Item> items = Enumerable.Range(1, 10_000)
  .Select(i => new Item(i, i % 3 == 0, i % 100))
  .ToList();

string readable = BuildCsvReadable(items.Take(10));
string builderBased = BuildCsvWithBuilder(items.Take(10));

Console.WriteLine("Readable version:");
Console.WriteLine(readable);
Console.WriteLine("StringBuilder version:");
Console.WriteLine(builderBased);

Console.WriteLine($"LINQ average score: {AverageValidScoreWithLinq(items):N2}");
Console.WriteLine($"Loop average score: {AverageValidScoreWithLoop(items):N2}");

static string BuildCsvReadable(IEnumerable<Item> items)
{
  string result = "";

  foreach (Item item in items)
  {
    result += $"{item.Id},{item.Score}{Environment.NewLine}";
  }

  return result;
}

static string BuildCsvWithBuilder(IEnumerable<Item> items)
{
  StringBuilder builder = new();

  foreach (Item item in items)
  {
    builder.Append(item.Id);
    builder.Append(',');
    builder.Append(item.Score);
    builder.AppendLine();
  }

  return builder.ToString();
}

static double AverageValidScoreWithLinq(IEnumerable<Item> values)
{
  return values
    .Where(value => value.IsValid)
    .Select(value => value.Score)
    .Average();
}

static double AverageValidScoreWithLoop(IEnumerable<Item> values)
{
  int count = 0;
  double total = 0;

  foreach (Item value in values)
  {
    if (value.IsValid)
    {
      total += value.Score;
      count++;
    }
  }

  return count == 0 ? 0 : total / count;
}

public record Item(int Id, bool IsValid, int Score);
