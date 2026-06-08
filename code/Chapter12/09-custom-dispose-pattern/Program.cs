string simplePath = Path.Combine(AppContext.BaseDirectory, "simple-report.md");
using (ReportWriter writer = new(simplePath))
{
  writer.WriteHeading("Mission Log");
}

string detailedPath = Path.Combine(AppContext.BaseDirectory, "detailed-report.md");
using (DetailedResourceOwner owner = new(detailedPath))
{
  owner.Write("Detailed mission log");
}

Console.WriteLine(File.ReadAllText(simplePath));
Console.WriteLine(File.ReadAllText(detailedPath));

public sealed class ReportWriter : IDisposable
{
  private readonly StreamWriter _writer;

  public ReportWriter(string path)
  {
    _writer = new StreamWriter(path);
  }

  public void WriteHeading(string heading)
  {
    _writer.WriteLine($"# {heading}");
  }

  public void Dispose()
  {
    _writer.Dispose();
  }
}

public class ResourceOwner : IDisposable
{
  private bool _disposed;
  private readonly StreamWriter _writer;

  public ResourceOwner(string path)
  {
    _writer = new StreamWriter(path);
  }

  public void Write(string message)
  {
    ObjectDisposedException.ThrowIf(_disposed, this);
    _writer.WriteLine(message);
  }

  public void Dispose()
  {
    Dispose(disposing: true);
    GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (_disposed)
    {
      return;
    }

    if (disposing)
    {
      _writer.Dispose();
    }

    _disposed = true;
  }
}

public sealed class DetailedResourceOwner : ResourceOwner
{
  private bool _disposed;
  private readonly MemoryStream _buffer = new();

  public DetailedResourceOwner(string path) : base(path)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if (!_disposed)
    {
      if (disposing)
      {
        _buffer.Dispose();
      }

      _disposed = true;
    }

    base.Dispose(disposing);
  }
}
