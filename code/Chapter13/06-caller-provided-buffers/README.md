# Caller-provided buffers

Shows a lower-allocation API that writes into a Span<byte> supplied by the caller, plus TryFormat-style formatting into Span<char>.

## Build and run

```bash
dotnet build
dotnet run
```

The project targets `net11.0` by default. If you are using .NET 10, change the target framework in the `.csproj` file to `net10.0`.
