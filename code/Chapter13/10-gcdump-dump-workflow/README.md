# GC dump and process dump workflow

Creates a repeatable managed heap growth scenario so readers can collect before-and-after GC dumps or process dumps.

## Build and run

```bash
dotnet build
dotnet run
```

The project targets `net11.0` by default. If you are using .NET 10, change the target framework in the `.csproj` file to `net10.0`.

## Diagnostic exercise

This project intentionally keeps arrays reachable in a list. Use it to practice the workflow from the chapter:

```text
Reproduce -> Observe -> Capture -> Compare -> Explain -> Fix -> Verify
```

Suggested commands:

```bash
dotnet-gcdump ps
dotnet-gcdump collect --process-id <PID> --output before.gcdump
dotnet-gcdump collect --process-id <PID> --output after.gcdump

dotnet-dump collect --process-id <PID> --output app.dmp
dotnet-dump analyze app.dmp
```

Inside `dotnet-dump analyze`, try `dumpheap -stat`.
