using System;
using System.Buffers;
using System.IO;

RecentMessages messages = new(maximumCount: 3);
messages.Add("Started");
messages.Add("Loaded configuration");
messages.Add("Processed request 1");
messages.Add("Processed request 2");

Console.WriteLine("Recent messages:");
foreach (string message in messages.Items)
{
  Console.WriteLine($"- {message}");
}

Order order = new(
  Id: 101,
  Customer: new Customer("Ada Lovelace", "ada@example.com"),
  Total: 149.99M,
  Lines: [new OrderLine("Book", 1), new OrderLine("USB cable", 2)]);

OrderSummary summary = OrderSummary.FromOrder(order);
Console.WriteLine($"Summary: {summary.OrderId}, {summary.CustomerName}, {summary.Total:C}");

using MissionLog log = new("mission-log.txt");
log.Write("Memory practices demo completed.");

byte[] rented = ArrayPool<byte>.Shared.Rent(1024);
try
{
  Span<byte> destination = rented.AsSpan(0, 4);
  WriteHeader(12, destination);
  Console.WriteLine($"Header: {string.Join(", ", destination.ToArray())}");
}
finally
{
  ArrayPool<byte>.Shared.Return(rented, clearArray: true);
}

static void WriteHeader(int messageType, Span<byte> destination)
{
  if (destination.Length < 4)
  {
    throw new ArgumentException("Destination must be at least four bytes.", nameof(destination));
  }

  destination[0] = (byte)messageType;
  destination[1] = 0;
  destination[2] = 0;
  destination[3] = 0;
}

public sealed class RecentMessages
{
  private readonly Queue<string> _messages = new();
  private readonly int _maximumCount;

  public RecentMessages(int maximumCount)
  {
    _maximumCount = maximumCount;
  }

  public IEnumerable<string> Items => _messages;

  public void Add(string message)
  {
    _messages.Enqueue(message);

    while (_messages.Count > _maximumCount)
    {
      _messages.Dequeue();
    }
  }
}

public sealed class MissionLog : IDisposable
{
  private readonly StreamWriter _writer;

  public MissionLog(string path)
  {
    _writer = new StreamWriter(path);
  }

  public void Write(string message)
  {
    _writer.WriteLine(message);
  }

  public void Dispose()
  {
    _writer.Dispose();
  }
}

public record Customer(string Name, string Email);
public record OrderLine(string ProductName, int Quantity);
public record Order(int Id, Customer Customer, decimal Total, IReadOnlyList<OrderLine> Lines);
public record OrderSummary(int OrderId, string CustomerName, decimal Total)
{
  public static OrderSummary FromOrder(Order order)
  {
    return new OrderSummary(order.Id, order.Customer.Name, order.Total);
  }
}
