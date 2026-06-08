int factor = 10;
Func<int, int> multiply = x => x * factor;
Console.WriteLine(multiply(5));

var actions = new List<Action>();

for (int i = 0; i < 3; i++)
{
  actions.Add(() => Console.WriteLine(i));
}

Console.WriteLine("Captured loop variable:");
foreach (var action in actions) action();

var fixedActions = new List<Action>();
for (int i = 0; i < 3; i++)
{
  int captured = i;
  fixedActions.Add(() => Console.WriteLine(captured));
}

Console.WriteLine("Captured local copy:");
foreach (var action in fixedActions) action();

DownloadFile(() => Console.WriteLine("Download complete."));

Button button = new();
button.Click += () => Console.WriteLine("Button clicked.");
button.SimulateClick();

static void DownloadFile(Action onComplete)
{
  Console.WriteLine("Downloading...");
  onComplete();
}

public sealed class Button
{
  public event Action? Click;
  public void SimulateClick() => Click?.Invoke();
}
