using System;
using System.Buffers;
using System.Security.Cryptography;

const int requestedLength = 100_000;
byte[] buffer = ArrayPool<byte>.Shared.Rent(requestedLength);

try
{
  Console.WriteLine($"Requested: {requestedLength:N0} bytes");
  Console.WriteLine($"Rented array length: {buffer.Length:N0} bytes");

  Span<byte> usable = buffer.AsSpan(0, requestedLength);
  RandomNumberGenerator.Fill(usable);

  int checksum = CalculateChecksum(usable);
  Console.WriteLine($"Checksum of usable data: {checksum}");
}
finally
{
  // Use clearArray: true for sensitive data, such as tokens, keys, or personal data.
  ArrayPool<byte>.Shared.Return(buffer, clearArray: true);
  Console.WriteLine("Returned buffer to the pool.");
}

static int CalculateChecksum(ReadOnlySpan<byte> data)
{
  int total = 0;

  foreach (byte value in data)
  {
    total = (total + value) % 10_000;
  }

  return total;
}
