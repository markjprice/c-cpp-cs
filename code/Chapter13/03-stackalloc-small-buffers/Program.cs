using System;

Console.WriteLine("Small buffer:");
UseTemporaryBuffer(8);

Console.WriteLine();
Console.WriteLine("Larger buffer:");
UseTemporaryBuffer(1024);

static void UseTemporaryBuffer(int requestedLength)
{
  const int MaxStackLimit = 256;

  Span<byte> buffer = requestedLength <= MaxStackLimit
    ? stackalloc byte[requestedLength]
    : new byte[requestedLength];

  for (int i = 0; i < buffer.Length; i++)
  {
    buffer[i] = (byte)(i % 256);
  }

  Console.WriteLine($"Requested length: {requestedLength}");
  Console.WriteLine($"First byte: {buffer[0]}");
  Console.WriteLine($"Last byte: {buffer[^1]}");
  Console.WriteLine(requestedLength <= MaxStackLimit
    ? "Used stackalloc."
    : "Used a heap array fallback.");
}
