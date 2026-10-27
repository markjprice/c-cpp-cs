# Chapter 11 online section - Performance and pitfalls

- [Chapter 11 online section - Performance and pitfalls](#chapter-11-online-section---performance-and-pitfalls)
- [Readable code first, optimize second](#readable-code-first-optimize-second)
- [Allocations caused by closures](#allocations-caused-by-closures)
- [Iterator allocations](#iterator-allocations)
- [Boxing in LINQ](#boxing-in-linq)
- [Multiple enumeration](#multiple-enumeration)
- [Deferred execution pitfalls](#deferred-execution-pitfalls)
- [Ranges and indices](#ranges-and-indices)
- [Spans](#spans)
- [Async streams and `IAsyncEnumerable<T>`](#async-streams-and-iasyncenumerablet)
- [Async LINQ concepts](#async-linq-concepts)
- [`IEnumerable<T>` versus `IAsyncEnumerable<T>`](#ienumerablet-versus-iasyncenumerablet)
- [Why LINQ is not always the fastest solution](#why-linq-is-not-always-the-fastest-solution)

Modern C# provides powerful abstractions that improve readability, maintainability, and developer productivity. Features such as LINQ, lambdas, pattern matching, records, async streams, and immutable data structures allow applications to be expressed more declaratively and safely than older procedural styles.

However, abstractions are not free. Many modern language features introduce:
- Hidden allocations
- Deferred execution
- Additional object creation
- Iterator overhead
- Boxing
- Garbage collection pressure

In most business applications, these costs are acceptable and often insignificant compared to the benefits of clearer code. But developers should still understand how modern C# features behave internally so they can recognize performance bottlenecks when they occur.

The goal is not to avoid modern C# features. The goal is to use them intelligently.

# Readable code first, optimize second

One of the biggest mistakes beginners make is prematurely optimizing code before measuring whether performance is actually a problem. For example, this LINQ query is perfectly reasonable:
```cs
var names = employees
    .Where(employee => employee.IsActive)
    .Select(employee => employee.Name);
```

Replacing it immediately with low-level loops for “performance reasons” usually makes code harder to maintain while producing no measurable benefit. Modern hardware is extremely fast, and developer time is usually more expensive than CPU time.

Good engineering practice is:
- Write clear code first
- Measure performance
- Optimize only proven bottlenecks

This principle becomes especially important in modern C#, where concise declarative code is often easier to reason about than procedural micro-optimizations.

# Allocations caused by closures

As discussed earlier, lambdas can capture variables from surrounding scopes:
```cs
int factor = 2;

Func<int, int> multiply =
    x => x * factor;
```

This creates a closure object internally so the lambda can continue accessing factor. Closures are extremely useful, but they also allocate memory on the managed heap. In most applications this overhead is negligible, but excessive closure creation inside high-frequency loops can increase garbage collection pressure:
```cs
for (int i = 0; i < 100000; i++)
{
    actions.Add(() => Console.WriteLine(i));
}
```

This may generate many allocations and unexpected behavior due to captured variables.

When performance is important:
- Avoid unnecessary captures
- Reuse delegates where possible
- Profile allocation-heavy code

> **Prompt**: Show how closures create heap allocations internally.

# Iterator allocations

Many LINQ operations use iterators internally:
```cs
var query = numbers
    .Where(n => n > 0)
    .Select(n => n * 2);
```

This query typically creates iterator objects that manage deferred execution. Again, these allocations are usually small, but deeply chained LINQ pipelines in hot paths can produce measurable overhead.

This does not mean LINQ is “bad.” It simply means developers should understand the tradeoff between readability, abstraction, and allocation cost. In performance-sensitive code, simple loops can sometimes outperform LINQ significantly.

> **Prompt**: Explain hidden allocations in modern C# with diagrams and examples.

# Boxing in LINQ

Boxing occurs when value types are converted into reference types:
```cs
int number = 10;

object value = number;
```

This creates a heap allocation. Some LINQ operations may trigger boxing unintentionally, especially when using non-generic collections, working through interfaces, or storing value types as object. For example:
```cs
ArrayList values = new();

values.Add(10);
```

The integer becomes boxed because ArrayList stores objects rather than strongly typed generic values. Modern generic collections such as `List<T>` largely avoid this problem, but boxing can still appear in advanced scenarios.

Repeated boxing inside large loops can negatively affect performance and garbage collection behavior.

# Multiple enumeration

Deferred execution can sometimes cause sequences to execute repeatedly:
```cs
var query = numbers
    .Where(n => n > 0);

Console.WriteLine(query.Count()); // Executes query.

Console.WriteLine(query.Sum()); // Executes query a second time.
```

The filtering operation executes twice because the sequence is enumerated twice. This becomes expensive when:
- The query performs database access
- The source sequence is large
- The transformation logic is costly

Materializing results avoids repeated enumeration:
```cs
var results = query.ToList(); // Executes query once.

Console.WriteLine(results.Count()); // No query execution.

Console.WriteLine(results.Sum()); // No query execution.
```

However, materialization trades CPU cost for additional memory usage. Understanding when LINQ executes is one of the most important performance concepts in modern C#.

# Deferred execution pitfalls

Deferred execution can also create subtle correctness issues:
```cs
List<int> numbers = [1, 2, 3];

var query = numbers.Where(n => n > 1);

numbers.Add(10);
```

Later enumeration includes the new value because the query executes lazily. This surprises many developers who assume LINQ queries behave like snapshots. When predictable snapshot behavior is required, materialization should be used explicitly.

# Ranges and indices

Modern C# introduced ranges and indices to simplify working with slices of collections:
```cs
int[] values = [10, 20, 30, 40, 50];

int[] middle = values[1..4];
```

The `1..4` syntax creates a range.

Indices can also count from the end:
```cs
int last = values[^1];
```

This syntax improves readability significantly compared to manual index calculations. However, developers should understand that slicing arrays often creates new arrays and copies data. In performance-sensitive code, repeated slicing can increase allocations.

# Spans

`Span<T>` provides a high-performance way to work with contiguous memory without unnecessary allocations:
```cs
int[] values = [1, 2, 3, 4];

Span<int> slice = values[1..3];
```

Unlike array slicing, spans can reference existing memory directly without allocating new arrays.

`Span<T>` is heavily used in high-performance .NET libraries because it reduces copying, allocations, and garbage collection pressure. Spans can reference arrays, stack memory, and unmanaged memory. This makes them extremely powerful, but they also have restrictions.

Because spans may reference stack memory, they cannot safely outlive the current execution scope. As a result:
- Spans cannot be stored in normal heap objects
- Spans cannot be used as class fields
- Spans cannot cross await boundaries safely

These restrictions exist to preserve memory safety. Although spans improve performance dramatically in some scenarios, they also increase complexity. Most business applications do not require heavy span usage.

> **Prompt**: Explain `Span<T>` visually and show why it avoids allocations.

# Async streams and `IAsyncEnumerable<T>`

Traditional asynchronous methods return a single result using `Task<T>`. Modern C# also supports asynchronous streams using `IAsyncEnumerable<T>`:
```cs
async IAsyncEnumerable<int> GetNumbers()
{
    for (int i = 0; i < 5; i++)
    {
        await Task.Delay(100);

        yield return i;
    }
}
```

Consumers use `await foreach`:
```cs
await foreach (int number in GetNumbers())
{
    Console.WriteLine(number);
}
```

This allows asynchronous data to stream gradually rather than waiting for all results to complete first. Async streams are especially useful for network data, real-time feeds, database streaming, and large datasets.

# Async LINQ concepts

Many LINQ concepts also apply to asynchronous streams. Libraries such as `System.Linq.Async` provide asynchronous operators like `WhereAwait`, `SelectAwait`, and `ToListAsync`. These allow asynchronous transformation pipelines similar to ordinary LINQ.

However, asynchronous pipelines can introduce additional allocations, state machines, and scheduling overhead.

Asynchronous code is not automatically faster. It primarily improves scalability and responsiveness.

# `IEnumerable<T>` versus `IAsyncEnumerable<T>`

A common beginner mistake is assuming asynchronous streams should always replace ordinary collections. Use `IEnumerable<T>` when:
- Data is already in memory
- Operations are synchronous
- Asynchronous waiting is unnecessary

Use `IAsyncEnumerable<T>` when:
- Results arrive gradually over time
- Asynchronous operations occur between elements
- Streaming reduces memory usage

Choosing the wrong abstraction can increase complexity unnecessarily.

# Why LINQ is not always the fastest solution

LINQ prioritizes readability, composability, expressiveness, but not maximum raw performance:
```cs
var total = numbers
    .Where(n => n > 0)
    .Select(n => n * 2)
    .Sum();
```

This is concise and readable. But in extremely performance-sensitive scenarios, a manual loop may allocate less memory and execute faster:
```cs
int total = 0;

foreach (int number in numbers)
{
    if (number > 0)
    {
        total += number * 2;
    }
}
```

The difference is often small, but it can matter in:
- Game engines like Unity
- Numerical simulations
- High-frequency trading
- Real-time systems

> **Prompt**: Compare LINQ performance with manual loops in realistic scenarios.
