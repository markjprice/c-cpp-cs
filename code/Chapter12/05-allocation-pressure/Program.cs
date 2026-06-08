const int count = 100_000;

List<int> growsRepeatedly = new();
for (int i = 0; i < count; i++)
{
  growsRepeatedly.Add(i);
}
Console.WriteLine($"List without capacity: {growsRepeatedly.Count:N0} items");

List<int> preSized = new(capacity: count);
for (int i = 0; i < count; i++)
{
  preSized.Add(i);
}
Console.WriteLine($"List with capacity: {preSized.Count:N0} items");

long before = GC.GetAllocatedBytesForCurrentThread();
CreateManyMessages(10_000);
long after = GC.GetAllocatedBytesForCurrentThread();

Console.WriteLine($"Approximate bytes allocated while creating messages: {after - before:N0}");

static void CreateManyMessages(int count)
{
  for (int i = 0; i < count; i++)
  {
    string message = $"Item number: {i}";
    Process(message);
  }
}

static void Process(string message)
{
  if (message.Length == 0)
  {
    Console.WriteLine("Impossible in this example.");
  }
}
