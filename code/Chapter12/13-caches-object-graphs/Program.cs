ProfileCache cache = new(maximumCount: 3);
for (int i = 1; i <= 5; i++)
{
  UserProfile profile = cache.GetProfile(i);
  Console.WriteLine($"Loaded profile {profile.UserId}");
}
Console.WriteLine($"Cache count after bounded loading: {cache.Count}");

Order order = SampleData.LoadOrder(42);
OrderLine line = order.Lines[0];
RecentLineSummary summary = new()
{
  OrderId = order.Id,
  ProductName = line.ProductName,
  Quantity = line.Quantity
};

Console.WriteLine($"Summary: {summary.OrderId}, {summary.ProductName}, {summary.Quantity}");
Console.WriteLine("The summary avoids keeping the whole order graph alive.");

public sealed class ProfileCache
{
  private readonly Dictionary<int, UserProfile> _profiles = new();
  private readonly Queue<int> _order = new();
  private readonly int _maximumCount;

  public ProfileCache(int maximumCount)
  {
    _maximumCount = maximumCount;
  }

  public int Count => _profiles.Count;

  public UserProfile GetProfile(int userId)
  {
    if (_profiles.TryGetValue(userId, out UserProfile? profile))
    {
      return profile;
    }

    profile = new UserProfile(userId);
    _profiles[userId] = profile;
    _order.Enqueue(userId);

    while (_profiles.Count > _maximumCount)
    {
      int oldestUserId = _order.Dequeue();
      _profiles.Remove(oldestUserId);
    }

    return profile;
  }
}

public sealed record UserProfile(int UserId);

public sealed class Order
{
  public int Id { get; set; }
  public Customer Customer { get; set; } = new();
  public List<OrderLine> Lines { get; } = new();
}

public sealed class Customer
{
  public string Name { get; set; } = "";
  public string Address { get; set; } = "";
}

public sealed class OrderLine
{
  public string ProductName { get; set; } = "";
  public int Quantity { get; set; }
}

public sealed class RecentLineSummary
{
  public int OrderId { get; init; }
  public string ProductName { get; init; } = "";
  public int Quantity { get; init; }
}

public static class SampleData
{
  public static Order LoadOrder(int id)
  {
    Order order = new()
    {
      Id = id,
      Customer = new Customer { Name = "Ada Lovelace", Address = "London" }
    };

    order.Lines.Add(new OrderLine { ProductName = "Keyboard", Quantity = 1 });
    order.Lines.Add(new OrderLine { ProductName = "Monitor", Quantity = 2 });
    return order;
  }
}
