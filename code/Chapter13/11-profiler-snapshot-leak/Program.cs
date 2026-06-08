using System;

AlertService alerts = new();

Console.WriteLine($"Process ID: {Environment.ProcessId}");
Console.WriteLine("Create subscribers without disposing them:");
CreateLeakySubscribers(alerts, count: 1_000);
Console.WriteLine("Subscribers created. They are still reachable through the event.");

alerts.RaiseAlert("First alert");
Console.WriteLine("Take a memory snapshot now if using a profiler.");
Console.WriteLine("Press Enter to create and dispose subscribers correctly.");
Console.ReadLine();

CreateDisposedSubscribers(alerts, count: 1_000);
Console.WriteLine("Disposed subscribers created and unsubscribed.");
alerts.RaiseAlert("Second alert");

Console.WriteLine("Press Enter to exit.");
Console.ReadLine();

static void CreateLeakySubscribers(AlertService alerts, int count)
{
  for (int i = 0; i < count; i++)
  {
    _ = new StatusPanel(alerts, $"Leaky-{i}");
  }
}

static void CreateDisposedSubscribers(AlertService alerts, int count)
{
  for (int i = 0; i < count; i++)
  {
    using StatusPanel panel = new(alerts, $"Disposed-{i}");
  }
}

public sealed class AlertService
{
  public event EventHandler<string>? AlertRaised;

  public void RaiseAlert(string message)
  {
    AlertRaised?.Invoke(this, message);
  }
}

public sealed class StatusPanel : IDisposable
{
  private readonly AlertService _alerts;
  private readonly string _name;
  private readonly byte[] _displayBuffer = new byte[16_384];

  public StatusPanel(AlertService alerts, string name)
  {
    _alerts = alerts;
    _name = name;
    _alerts.AlertRaised += OnAlertRaised;
  }

  private void OnAlertRaised(object? sender, string message)
  {
    _displayBuffer[0] = (byte)message.Length;
  }

  public void Dispose()
  {
    _alerts.AlertRaised -= OnAlertRaised;
  }

  public override string ToString() => _name;
}
