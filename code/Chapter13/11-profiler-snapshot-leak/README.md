# Profiler snapshot leak

Demonstrates how a long-lived event publisher can retain short-lived subscribers, useful for Visual Studio or commercial memory profiler snapshots.

## Build and run

```bash
dotnet build
dotnet run
```

The project targets `net11.0` by default. If you are using .NET 10, change the target framework in the `.csproj` file to `net10.0`.

## Snapshot exercise

Use Visual Studio Memory Usage, JetBrains dotMemory, Redgate ANTS Memory Profiler, or another memory profiler:

1. Start the program.
2. Take a baseline snapshot.
3. Let the leaky subscribers be created.
4. Take another snapshot.
5. Look for retained `StatusPanel` instances and inspect the reference path through `AlertService.AlertRaised`.
