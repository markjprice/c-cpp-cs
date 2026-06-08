for (int i = 0; i < 5; i++)
{
  CrewRegistry.Members.Add(new CrewMember($"Crew member {i}", "Operations"));
}

Console.WriteLine($"Static registry count: {CrewRegistry.Members.Count}");
CrewRegistry.Members.Clear();
Console.WriteLine($"After clearing: {CrewRegistry.Members.Count}");

RequestLog log = new(maximumCount: 3);
for (int i = 1; i <= 10; i++)
{
  log.Add(new RequestInfo(i, DateTimeOffset.UtcNow));
}

Console.WriteLine($"Bounded request log count: {log.Count}");

public static class CrewRegistry
{
  public static List<CrewMember> Members { get; } = new();
}

public sealed record CrewMember(string Name, string Role);
public sealed record RequestInfo(int Id, DateTimeOffset Timestamp);

public sealed class RequestLog
{
  private readonly Queue<RequestInfo> _requests = new();
  private readonly int _maximumCount;

  public RequestLog(int maximumCount)
  {
    _maximumCount = maximumCount;
  }

  public int Count => _requests.Count;

  public void Add(RequestInfo request)
  {
    _requests.Enqueue(request);

    while (_requests.Count > _maximumCount)
    {
      _requests.Dequeue();
    }
  }
}
