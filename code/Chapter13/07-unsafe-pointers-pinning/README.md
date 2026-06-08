# Unsafe pointers and pinning

Demonstrates a small unsafe operation, fixed pinning, safety comments, and a safe public wrapper that validates inputs first.

## Build and run

```bash
dotnet build
dotnet run
```

The project targets `net11.0` by default. If you are using .NET 10, change the target framework in the `.csproj` file to `net10.0`.

This project enables unsafe code in the `.csproj` file because it demonstrates pointers and pinning. Keep unsafe code small and reviewed.
