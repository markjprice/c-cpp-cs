int[] values = [1, 2, 3, 4];
Span<int> slice = values.AsSpan(1, 2);

for (int i = 0; i < slice.Length; i++)
{
  slice[i] *= 10;
}

Console.WriteLine(string.Join(", ", values));

ReadOnlySpan<char> text = "INV-2026-0001".AsSpan();
ReadOnlySpan<char> prefix = text[..3];
ReadOnlySpan<char> year = text[4..8];

Console.WriteLine(prefix.ToString());
Console.WriteLine(year.ToString());

await foreach (int number in GetNumbers()) Console.WriteLine(number);
await foreach (string message in GetMessages()) Console.WriteLine(message);

static async IAsyncEnumerable<int> GetNumbers()
{
  for (int i = 0; i < 5; i++)
  {
    await Task.Delay(50);
    yield return i;
  }
}

static async IAsyncEnumerable<string> GetMessages()
{
  string[] messages = ["Connecting", "Downloading", "Complete"];

  foreach (string message in messages)
  {
    await Task.Delay(50);
    yield return message;
  }
}
