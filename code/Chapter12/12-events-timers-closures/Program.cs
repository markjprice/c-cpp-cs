AlertService alertService = new();

using (AlertWindow window = new(alertService))
{
  alertService.RaiseAlert("Red alert");
}

alertService.RaiseAlert("No window should receive this message.");

using StatusPoller poller = new();
await Task.Delay(150);

SearchService search = new();
List<CrewMember> crew =
[
  new("Spock", 7),
  new("Chekov", 3),
  new("Uhura", 6)
];
search.Search(crew, minimumRank: 5);

public sealed class AlertService
{
  public event EventHandler<string>? AlertRaised;

  public void RaiseAlert(string message)
  {
    AlertRaised?.Invoke(this, message);
  }
}

public sealed class AlertWindow : IDisposable
{
  private readonly AlertService _alertService;

  public AlertWindow(AlertService alertService)
  {
    _alertService = alertService;
    _alertService.AlertRaised += OnAlertRaised;
  }

  private void OnAlertRaised(object? sender, string message)
  {
    Console.WriteLine($"Window received: {message}");
  }

  public void Dispose()
  {
    _alertService.AlertRaised -= OnAlertRaised;
  }
}

public sealed class StatusPoller : IDisposable
{
  private readonly Timer _timer;

  public StatusPoller()
  {
    _timer = new Timer(
      callback: CheckStatus,
      state: null,
      dueTime: TimeSpan.Zero,
      period: TimeSpan.FromMilliseconds(50));
  }

  private void CheckStatus(object? state)
  {
    Console.WriteLine("Checking status...");
  }

  public void Dispose()
  {
    _timer.Dispose();
  }
}

public sealed class SearchService
{
  private int _lastMinimumRank;

  public void Search(IEnumerable<CrewMember> crew, int minimumRank)
  {
    _lastMinimumRank = minimumRank;

    foreach (CrewMember member in crew)
    {
      if (member.Rank >= _lastMinimumRank)
      {
        Console.WriteLine(member.Name);
      }
    }
  }
}

public sealed record CrewMember(string Name, int Rank);
