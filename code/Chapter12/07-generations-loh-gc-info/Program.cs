SmallObject small = new();
byte[] smallBuffer = new byte[1_000];
byte[] largeBuffer = new byte[100_000];

Console.WriteLine($"Generation of small object: {GC.GetGeneration(small)}");
Console.WriteLine($"Generation of small buffer: {GC.GetGeneration(smallBuffer)}");
Console.WriteLine($"Generation of large buffer: {GC.GetGeneration(largeBuffer)}");

Console.WriteLine($"Total managed memory before collection: {GC.GetTotalMemory(false):N0} bytes");

for (int i = 0; i < 10_000; i++)
{
  _ = new SmallObject();
}

Console.WriteLine($"Total managed memory after temporary allocations: {GC.GetTotalMemory(false):N0} bytes");
Console.WriteLine("Avoid calling GC.Collect in ordinary application code. This example only reads GC information.");

public sealed class SmallObject
{
  public int Value { get; set; }
}
