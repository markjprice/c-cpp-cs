# Object pool parser

Implements a small object pool for a reusable parser that contains internal state and must be reset before returning to the pool.

## Build and run

```bash
dotnet build
dotnet run
```

The project targets `net11.0` by default. If you are using .NET 10, change the target framework in the `.csproj` file to `net10.0`.
