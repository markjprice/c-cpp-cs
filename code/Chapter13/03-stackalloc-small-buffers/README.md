# stackalloc small buffers

Uses stackalloc for small temporary buffers and falls back to heap allocation when the requested buffer is too large.

## Build and run

```bash
dotnet build
dotnet run
```

The project targets `net11.0` by default. If you are using .NET 10, change the target framework in the `.csproj` file to `net10.0`.
