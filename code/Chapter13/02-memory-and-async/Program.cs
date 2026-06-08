using System;
using System.IO;
using System.Text;

Packet packet = new(Encoding.UTF8.GetBytes("HEADThis is the packet body."));

Console.WriteLine($"Header: {Encoding.UTF8.GetString(packet.GetHeader())}");
Console.WriteLine($"Payload length: {packet.Payload.Length}");

await using MemoryStream stream = new();
await SendAsync(stream, packet.Payload);

Console.WriteLine($"Bytes written asynchronously: {stream.Length}");

static async Task SendAsync(Stream stream, ReadOnlyMemory<byte> buffer)
{
  await stream.WriteAsync(buffer);
}

public sealed class Packet
{
  private readonly ReadOnlyMemory<byte> _payload;

  public Packet(byte[] payload)
  {
    _payload = payload;
  }

  public ReadOnlyMemory<byte> Payload => _payload;

  public ReadOnlySpan<byte> GetHeader()
  {
    return _payload.Span[..4];
  }
}
