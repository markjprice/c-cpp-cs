# Chapter 13 C# High-Performance Memory and Diagnostics Projects

These projects accompany Chapter 13, **C# High-Performance Memory and Diagnostics**.

Each folder is a standalone console project. Open a project folder in VS Code, Visual Studio, Rider, or a terminal and run:

```bash
dotnet build
dotnet run
```

The projects target `net11.0` by default. If you are using .NET 10, change `<TargetFramework>net11.0</TargetFramework>` to `<TargetFramework>net10.0</TargetFramework>` in the project file. The unsafe-code project also enables `<AllowUnsafeBlocks>true</AllowUnsafeBlocks>`.

Suggested repository location:

```text
code/ch13-csharp-memory-perf/
```

## Projects

- `01-spans-and-slices`: Span<T>, ReadOnlySpan<T>, array slices, string slices, and avoiding unnecessary copies.
- `02-memory-and-async`: Memory<T> and ReadOnlyMemory<T> for stored buffers and asynchronous APIs.
- `03-stackalloc-small-buffers`: stackalloc with Span<T> for small temporary buffers, with a safe fallback for larger sizes.
- `04-arraypool-large-buffers`: ArrayPool<T> for renting and returning large reusable buffers safely.
- `05-object-pool-parser`: A simple object pool for an expensive parser-like object that can be reset and reused.
- `06-caller-provided-buffers`: APIs that write into caller-provided spans using TryWrite/TryFormat style patterns.
- `07-unsafe-pointers-pinning`: Unsafe pointers, fixed, pinning, and a safe public wrapper around an unsafe operation.
- `08-allocation-pressure-hot-paths`: Comparing readable allocation-heavy code with lower-allocation hot-path alternatives.
- `09-dotnet-counters-demo`: A runnable workload plus instructions for observing allocation rate and GC counters.
- `10-gcdump-dump-workflow`: A repeatable managed-memory growth scenario plus instructions for dotnet-gcdump and dotnet-dump.
- `11-profiler-snapshot-leak`: A small event-subscription retention example designed for memory snapshots and profilers.
- `12-efficient-memory-practices`: A summary project combining clear lifetimes, disposal, bounded collections, spans, and pooling choices.
