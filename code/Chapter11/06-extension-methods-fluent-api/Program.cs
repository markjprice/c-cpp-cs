string text = "Hello modern C#";
Console.WriteLine(text.IsLong());

List<int> numbers = [5, -2, 10, 1, 0, 7];

var results = numbers.Where(n => n > 0).OrderBy(n => n).Select(n => n * 2);
Console.WriteLine(string.Join(", ", results));

var report = numbers.KeepPositive().DoubleAll().FormatAsCsv();
Console.WriteLine(report);

public static class StringExtensions
{
  public static bool IsLong(this string value) => value.Length > 10;
}

public static class NumberSequenceExtensions
{
  public static IEnumerable<int> KeepPositive(this IEnumerable<int> source) => source.Where(value => value > 0);
  public static IEnumerable<int> DoubleAll(this IEnumerable<int> source) => source.Select(value => value * 2);
  public static string FormatAsCsv(this IEnumerable<int> source) => string.Join(", ", source);
}
