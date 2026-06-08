# Chapter 11: C# Modern Programming

This folder contains complete projects for Chapter 11, **C# Modern Programming**.

Each project is self-contained and can be opened in Visual Studio, VS Code, Rider, or built from the command line.

## Requirements

The projects target `net11.0` because the chapter is written for .NET 11 and C# 15.

```bash
dotnet --version
```

If you are using .NET 10 while experimenting before .NET 11 is available, most projects can be changed from:

```xml
<TargetFramework>net11.0</TargetFramework>
```

to:

```xml
<TargetFramework>net10.0</TargetFramework>
```

The exception is the union-type project, which uses the proposed C# 15 `union` keyword and requires a compiler that supports that feature.

## Build and run

Move into a project folder and run:

```bash
dotnet build
dotnet run
```

For example:

```bash
cd 01-nullability-safer-code
dotnet run
```

## Projects

| Folder | Topic |
|---|---|
| `01-nullability-safer-code` | Nullable reference types, flow analysis, guard clauses, and the null-forgiving operator |
| `02-union-payment-outcomes` | C# 15 union types using payment, API, and promotion examples |
| `03-pattern-matching-control-flow` | Type, property, tuple, relational, logical, list, and recursive patterns |
| `04-delegates-lambdas-functions` | Delegates, `Func<>`, `Action<>`, lambdas, local functions, and higher-order functions |
| `05-closures-and-callbacks` | Closures, captured variables, callbacks, and event-style code |
| `06-extension-methods-fluent-api` | Extension methods and fluent pipelines |
| `07-linq-basics-pipelines` | LINQ filtering, projection, sorting, and method/query syntax |
| `08-linq-deferred-materialization` | Deferred execution, `ToList()`, side effects, and multiple enumeration |
| `09-linq-group-join-aggregate` | `GroupBy`, `Join`, `SelectMany`, and aggregation |
| `10-functional-immutability-records` | Records, `with` expressions, pure functions, tuples, and deconstruction |
| `11-immutable-collections` | `System.Collections.Immutable` and immutable collection updates |
| `12-modern-syntax-enhancements` | Target-typed `new`, collection expressions, primary constructors, raw strings, and required members |
| `13-performance-pitfalls` | Closure allocation, iterator behavior, boxing, multiple enumeration, and manual loops |
| `14-spans-async-streams` | Ranges, indices, `Span<T>`, and `IAsyncEnumerable<T>` |

## Notes about the union-type project

The union examples are intentionally included as C# 15 code because the chapter teaches C# 15. If your installed compiler does not yet support the `union` keyword, the project will not build. That is expected until you use an SDK and compiler version that implements the feature.

The other projects avoid the `union` keyword and should build with current modern C# compilers after adjusting the target framework if needed.
