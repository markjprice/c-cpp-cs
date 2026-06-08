# Managed leaks with long-lived references

This project is part of Chapter 12, **C# Memory Management and Resource Lifetime**.

## Build and run

From this folder:

```bash
dotnet build
dotnet run
```

Or from the repository root:

```bash
dotnet run --project code/ch12-csharp-memory/11-managed-leaks-long-lived-references/11-managed-leaks-long-lived-references.csproj
```

The project targets `net11.0`. If you are using .NET 10, change `<TargetFramework>net11.0</TargetFramework>` to `<TargetFramework>net10.0</TargetFramework>` in the `.csproj` file.
