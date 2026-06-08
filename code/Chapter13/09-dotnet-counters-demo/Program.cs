using System;
using System.Diagnostics;

Console.WriteLine($"Process ID: {Environment.ProcessId}");
Console.WriteLine("In another terminal, run:");
Console.WriteLine($"dotnet-counters monitor --process-id {Environment.ProcessId} System.Runtime");
Console.WriteLine();
Console.WriteLine("Press Enter to start the allocation workload.");
Console.ReadLine();

Stopwatch stopwatch = Stopwatch.StartNew();
long totalBytes = 0;

while (stopwatch.Elapsed < TimeSpan.FromSeconds(20))
{
  byte[][] batch = new byte[200][];

  for (int i = 0; i < batch.Length; i++)
  {
    batch[i] = new byte[8_192];
    totalBytes += batch[i].Length;
  }

  // Allow most objects to become unreachable quickly.
  batch = [];
  await Task.Delay(50);
}

Console.WriteLine($"Allocated about {totalBytes / 1024 / 1024:N0} MiB during the workload.");
Console.WriteLine("Watch whether the managed heap grows forever or stabilizes after collections.");
