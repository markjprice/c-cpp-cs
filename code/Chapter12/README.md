# Chapter 12: C# Memory Management and Resource Lifetime

This folder contains complete runnable projects for Chapter 12 of **C, C++, C# with an AI Sidekick**.

Each project is intentionally small. The goal is to let readers build and run the examples without copying fragments out of the chapter.

## Requirements

- .NET SDK 11 or later for the book's target framework.
- VS Code, Visual Studio, Rider, or a terminal.

Most examples also run on .NET 10 if you change each project file from `net11.0` to `net10.0`.

## Build and run one project

```bash
cd code/Chapter12/01-managed-memory-runtime
dotnet build
dotnet run
```

Or from the repository root:

```bash
dotnet run --project code/Chapter12/01-managed-memory-runtime/01-managed-memory-runtime.csproj
```

## Project list

1. `01-managed-memory-runtime` - managed memory and references.
2. `02-stack-heap-lifetime` - stack frames, heap objects, and object lifetime.
3. `03-value-reference-identity` - value copying, reference copying, and object identity.
4. `04-boxing-hidden-allocations` - boxing, unboxing, strings, closures, iterators, and LINQ.
5. `05-allocation-pressure` - repeated allocations and collection capacity.
6. `06-reachability-gc-roots` - reachability, roots, static references, and object graphs.
7. `07-generations-loh-gc-info` - GC generations and large object allocation.
8. `08-idisposable-using` - `IDisposable`, `using` statements, and `using` declarations.
9. `09-custom-dispose-pattern` - simple disposal and the full dispose pattern.
10. `10-finalizers-safehandle-async-dispose` - finalizers, `SafeHandle`, and `IAsyncDisposable`.
11. `11-managed-leaks-long-lived-references` - static and long-lived collection leaks.
12. `12-events-timers-closures` - events, timers, callbacks, and captured variables.
13. `13-caches-object-graphs` - cache limits and retaining too much object graph.
14. `14-weakreference-gchandle` - weak references and `GCHandle`.

## Notes for readers

Some examples deliberately demonstrate patterns that can cause memory pressure or leaks. They use small data sizes so that they are safe to run as learning examples.

The examples are not intended to benchmark .NET. For real measurement, use tools such as Visual Studio Diagnostic Tools, JetBrains dotMemory, `dotnet-counters`, `dotnet-gcdump`, or `dotnet-trace`.
