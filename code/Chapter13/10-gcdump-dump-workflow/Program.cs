using System;

Console.WriteLine($"Process ID: {Environment.ProcessId}");
Console.WriteLine("This program keeps batches alive deliberately so you can compare dumps.");
Console.WriteLine("Commands to try in another terminal:");
Console.WriteLine($"dotnet-gcdump collect --process-id {Environment.ProcessId} --output before.gcdump");
Console.WriteLine($"dotnet-dump collect --process-id {Environment.ProcessId} --output app.dmp");
Console.WriteLine();

List<byte[]> retained = new();

for (int round = 1; round <= 10; round++)
{
  Console.WriteLine($"Press Enter to retain another batch. Round {round}/10.");
  Console.ReadLine();

  for (int i = 0; i < 50; i++)
  {
    retained.Add(new byte[100_000]);
  }

  Console.WriteLine($"Retained arrays: {retained.Count:N0}");
  Console.WriteLine($"Approx retained bytes: {retained.Count * 100_000L / 1024 / 1024:N0} MiB");
}

Console.WriteLine("Press Enter to exit.");
Console.ReadLine();
