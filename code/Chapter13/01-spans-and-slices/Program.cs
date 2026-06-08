using System;

Console.WriteLine("Span<T> and slices");
Console.WriteLine(new string('-', 40));

int[] numbers = [10, 20, 30, 40, 50];
Span<int> middle = numbers.AsSpan(start: 1, length: 3);

middle[0] = 99;
Console.WriteLine($"After changing middle[0], numbers[1] = {numbers[1]}");

int[] copy = numbers[1..4];
copy[0] = 123;
Console.WriteLine($"After changing copy[0], numbers[1] = {numbers[1]}");

ReadOnlySpan<int> readOnlyMiddle = numbers.AsSpan(1, 3);
Console.WriteLine($"Sum of middle values = {Sum(readOnlyMiddle)}");

string registry = "NCC-1701-D";
ReadOnlySpan<char> prefix = registry.AsSpan(0, 3);
Console.WriteLine($"Registry starts with NCC: {prefix.SequenceEqual("NCC")}");

static int Sum(ReadOnlySpan<int> values)
{
  int total = 0;

  foreach (int value in values)
  {
    total += value;
  }

  return total;
}
