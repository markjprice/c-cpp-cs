using System;

byte[] buffer = [10, 20, 30, 40];

Console.WriteLine($"Safe wrapper result: {ReadFromArray(buffer, 2)}");

unsafe
{
  int value = 42;
  int* pointer = &value;
  Console.WriteLine($"Unsafe local pointer value: {*pointer}");
}

/// <summary>Reads a single byte from unmanaged memory.</summary>
/// <safety>
/// The caller must ensure that <paramref name="pointer"/> plus
/// <paramref name="offset"/> addresses memory that is valid to read.
/// </safety>
public static unsafe byte ReadByte(byte* pointer, int offset)
{
  unsafe
  {
    // SAFETY: The caller is responsible for providing a readable address.
    return pointer[offset];
  }
}

public static byte ReadFromArray(byte[] buffer, int offset)
{
  ArgumentNullException.ThrowIfNull(buffer);
  ArgumentOutOfRangeException.ThrowIfNegative(offset);
  ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(offset, buffer.Length);

  unsafe
  {
    fixed (byte* pointer = buffer)
    {
      // SAFETY: buffer is not null, offset is within bounds, and fixed pins
      // the array for the duration of this block.
      return ReadByte(pointer, offset);
    }
  }
}
