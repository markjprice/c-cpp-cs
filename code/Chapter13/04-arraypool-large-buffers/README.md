# ArrayPool large buffers

Rents a large buffer from ArrayPool<T>, uses only the requested slice, and returns it safely in a finally block.

## Build and run

```bash
dotnet build
dotnet run
```

The project targets `net11.0` by default. If you are using .NET 10, change the target framework in the `.csproj` file to `net10.0`.
