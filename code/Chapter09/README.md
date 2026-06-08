# Chapter 9: C# Fundamentals

This folder contains complete runnable C# projects for Chapter 9, **C# Fundamentals**.

Each project is deliberately small and focused on one teaching point. Open any folder in Visual Studio, VS Code, Rider, or a terminal, then build and run using the .NET CLI.

## Prerequisites

Install the .NET SDK. The examples target .NET 11 because the book is written for the .NET 11/C# 15 timeframe.

Check your SDK:

```bash
dotnet --version
```

## Build and run a project

From inside any project folder containing a `.csproj` file:

```bash
dotnet build
dotnet run
```

For the multi-project namespaces and assemblies example, use the command shown in that project's README.

## Project list

| Folder | Topic |
|---|---|
| `01-hello-top-level` | Minimal C# program using top-level statements |
| `02-traditional-main` | Explicit `Program` class and `Main()` method |
| `03-project-file-global-usings` | `.csproj`, implicit usings, custom global imports, build/run workflow |
| `04-variables-types` | Variables, constants, and built-in data types |
| `05-value-reference-types` | Value-type copying and reference-type sharing |
| `06-nullable-const-readonly-var-dynamic` | Nullable values, `const`, `readonly`, `var`, and `dynamic` |
| `07-operators-control-flow` | Arithmetic, assignment, relational, logical, bitwise, and null-aware operators |
| `08-switch-patterns` | `switch` statements, switch expressions, and pattern matching |
| `09-loops-jump-statements` | `for`, `while`, `do`, `foreach`, `break`, `continue`, and `return` |
| `10-methods-parameters` | Methods, parameters, `ref`, `out`, optional/named arguments, overloads, recursion |
| `11-arrays-basic-collections` | Arrays, multidimensional arrays, jagged arrays, `List<T>`, collection expressions |
| `12-exception-handling` | `try`, `catch`, `finally`, throwing, custom exceptions, `TryParse`, `using` |
| `13-namespaces-assemblies` | Namespaces, aliases, assemblies, class libraries, and project references |
| `14-clean-csharp-practices` | Clean-code examples: names, early returns, deduplication, validation |
