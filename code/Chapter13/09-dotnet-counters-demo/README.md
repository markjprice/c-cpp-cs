# dotnet-counters workload

Provides a repeatable allocation workload for observing allocation rate, GC heap size, and GC counts with dotnet-counters.

## Build and run

```bash
dotnet build
dotnet run
```

The project targets `net11.0` by default. If you are using .NET 10, change the target framework in the `.csproj` file to `net10.0`.

## Diagnostic exercise

1. Run this project with `dotnet run`.
2. Copy the process ID printed by the program.
3. In another terminal, run:

```bash
dotnet-counters monitor --process-id <PID> System.Runtime
```

Watch allocation rate, GC heap size, and GC counts while the workload runs. This project creates allocation pressure, but most objects become unreachable quickly, so it should not behave like an intentional leak.
