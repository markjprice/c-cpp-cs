using Microsoft.Win32.SafeHandles;

Console.WriteLine("Creating a finalizable object. Do not rely on finalizers for prompt cleanup.");
_ = new FinalizableThing("example");

using (FileStream stream = File.Open(
  Path.Combine(AppContext.BaseDirectory, "safehandle-demo.txt"),
  FileMode.OpenOrCreate,
  FileAccess.ReadWrite))
{
  SafeFileHandle handle = stream.SafeFileHandle;
  Console.WriteLine($"Safe handle is invalid: {handle.IsInvalid}");
}

await using AsyncLogWriter writer = await AsyncLogWriter.OpenAsync(
  Path.Combine(AppContext.BaseDirectory, "async-log.txt"));
await writer.WriteAsync("Async disposal example");

Console.WriteLine("Async writer disposed with await using.");

public sealed class FinalizableThing
{
  private readonly string _name;

  public FinalizableThing(string name)
  {
    _name = name;
  }

  ~FinalizableThing()
  {
    // Finalizers are unpredictable and should be rare.
    Console.Error.WriteLine($"Finalizer eventually ran for {_name}.");
  }
}

public sealed class AsyncLogWriter : IAsyncDisposable
{
  private readonly StreamWriter _writer;

  private AsyncLogWriter(StreamWriter writer)
  {
    _writer = writer;
  }

  public static async Task<AsyncLogWriter> OpenAsync(string path)
  {
    FileStream stream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true);
    StreamWriter writer = new(stream);
    await writer.WriteLineAsync("Log opened");
    return new AsyncLogWriter(writer);
  }

  public Task WriteAsync(string message) => _writer.WriteLineAsync(message);

  public async ValueTask DisposeAsync()
  {
    await _writer.FlushAsync();
    await _writer.DisposeAsync();
  }
}
