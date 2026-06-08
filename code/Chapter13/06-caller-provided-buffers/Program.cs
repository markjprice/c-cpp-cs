using System;

Span<byte> stackHeader = stackalloc byte[4];
WriteHeader(messageType: 7, stackHeader);
Console.WriteLine($"Header bytes: {string.Join(", ", stackHeader.ToArray())}");

byte[] heapHeader = new byte[4];
WriteHeader(messageType: 42, heapHeader);
Console.WriteLine($"Heap header bytes: {string.Join(", ", heapHeader)}");

Span<char> formatted = stackalloc char[32];
if (TryWriteOrderCode(1234, formatted, out int charsWritten))
{
  Console.WriteLine($"Order code: {formatted[..charsWritten].ToString()}");
}

static void WriteHeader(int messageType, Span<byte> destination)
{
  if (destination.Length < 4)
  {
    throw new ArgumentException(
      "The destination span must contain at least 4 bytes.",
      nameof(destination));
  }

  destination[0] = (byte)messageType;
  destination[1] = 0;
  destination[2] = 0;
  destination[3] = 0;
}

static bool TryWriteOrderCode(
  int orderId,
  Span<char> destination,
  out int charsWritten)
{
  const string prefix = "ORD-";

  if (destination.Length < prefix.Length + 4)
  {
    charsWritten = 0;
    return false;
  }

  prefix.AsSpan().CopyTo(destination);

  if (!orderId.TryFormat(destination[prefix.Length..], out int digitsWritten, "0000"))
  {
    charsWritten = 0;
    return false;
  }

  charsWritten = prefix.Length + digitsWritten;
  return true;
}
