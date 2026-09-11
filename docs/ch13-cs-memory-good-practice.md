- [Good practices for efficient memory usage](#good-practices-for-efficient-memory-usage)
- [Prefer clear code first](#prefer-clear-code-first)
- [Design clear object lifetimes](#design-clear-object-lifetimes)
- [Dispose what you own](#dispose-what-you-own)
- [Be careful with static state and long-lived collections](#be-careful-with-static-state-and-long-lived-collections)
- [Treat subscriptions as references](#treat-subscriptions-as-references)
- [Store only what you need](#store-only-what-you-need)
- [Choose between struct and class deliberately](#choose-between-struct-and-class-deliberately)
- [Avoid unnecessary allocation in hot paths](#avoid-unnecessary-allocation-in-hot-paths)
- [Be careful with large objects and buffers](#be-careful-with-large-objects-and-buffers)
- [Avoid premature pooling](#avoid-premature-pooling)
- [Use spans and memory types where they fit naturally](#use-spans-and-memory-types-where-they-fit-naturally)
- [Avoid calling GC.Collect() in normal application code](#avoid-calling-gccollect-in-normal-application-code)
- [Measure before and after changes](#measure-before-and-after-changes)


# Good practices for efficient memory usage

*Chapter 13* focused on allocation-aware C#: spans, memory buffers, pooling, unsafe code, diagnostics, and practical habits for measuring before optimizing. *Chapter 12* covered managed memory, garbage collection, disposal, and managed-memory leaks. The most important question is what you should do differently when writing C#.

Efficient memory usage is not about making every line of code as low-level as possible. Most C# code should be clear, readable, and idiomatic. The .NET runtime is good at allocating and collecting short-lived objects, so trying to eliminate every allocation usually makes code worse rather than better.
The better goal is to write code that is clear by default and allocation-aware where it matters. You should know which objects you are keeping alive, release resources promptly, avoid accidental growth, and measure before making complicated optimizations.

This online-only section summarizes the habits that matter most in everyday C# development. These are not separate tricks. They are ways of cooperating with the runtime.

# Prefer clear code first

Start with code that is simple, correct, and readable. Do not turn every loop into span-based buffer manipulation just because you learned that spans exist. Do not pool every object just because allocation has a cost. Do not avoid LINQ everywhere just because LINQ can allocate.
For example, this code is clear and appropriate in many applications:
```cs
var seniorOfficers = crew
    .Where(member => member.Rank >= 5)
    .OrderBy(member => member.Name)
    .ToList();
```

It may allocate iterator objects, delegates, and a list, but that is not automatically a problem. If this code runs occasionally, or if the collection is small, the readable version is probably the best version.
In a hot path, you might later replace it with a loop after measurement shows that the allocation matters:
```cs
List<CrewMember> seniorOfficers = new();

foreach (CrewMember member in crew)
{
    if (member.Rank >= 5)
    {
        seniorOfficers.Add(member);
    }
}

seniorOfficers.Sort(
    (first, second) => string.Compare(
        first.Name,
        second.Name,
        StringComparison.Ordinal));
```

The loop gives you more control, but it is also more verbose. It should earn its place.

> **Good practice**: Write clear code first. Optimize the measured hot path later.

The rest of this section assumes that principle. Memory-aware C# is not about writing uglier code everywhere. It is about knowing when clarity, lifetime, allocation, and performance need to be balanced.

Once your code is clear, the next habit is to make object lifetimes clear too.

# Design clear object lifetimes

The garbage collector can reclaim unreachable objects, but it cannot decide what your program meant to keep. If a long-lived object holds a reference, the referenced object stays alive.
This means you should design object lifetime deliberately. Ask how long an object should live and who is responsible for keeping it.
For local objects, lifetime is usually obvious. For shared objects, lifetime needs more thought:
```cs
public sealed class MissionControl
{
    private readonly List<Mission> _missions = new();

    public void Add(Mission mission)
    {
        _missions.Add(mission);
    }
}
```

This class can add missions, but it has no way to remove them. If MissionControl lives for the whole application lifetime, every mission added to it may also live for the whole application lifetime.

A better design makes removal explicit:
```cs
public sealed class MissionControl
{
    private readonly Dictionary<Guid, Mission> _missions = new();

    public void Add(Mission mission)
    {
        _missions[mission.Id] = mission;
    }

    public bool Remove(Guid missionId)
    {
        return _missions.Remove(missionId);
    }
}
```

Now the class has a clear way to stop keeping a mission alive.

This matters most for static fields, caches, singletons, long-lived services, UI objects, background workers, and game systems. The longer an object lives, the more careful you should be about what it references.

Designing lifetime clearly makes it easier for the GC to do useful work. It also prepares you for the next habit: releasing resources promptly.

# Dispose what you own

The garbage collector manages managed memory. It does not guarantee prompt cleanup of external resources. If an object owns a file, stream, socket, timer, database connection, graphics handle, native handle, or similar resource, it should usually be disposed.

When you create a disposable object for short-term use, wrap it in `using`:
```cs
using StreamReader reader = File.OpenText("captains.txt");

string contents = reader.ReadToEnd();
```

When your class owns a disposable field, your class should usually implement `IDisposable`:
```cs
public sealed class MissionLog : IDisposable
{
    private readonly StreamWriter _writer;

    public MissionLog(string path)
    {
        _writer = new StreamWriter(path);
    }

    public void Write(string message)
    {
        _writer.WriteLine(message);
    }

    public void Dispose()
    {
        _writer.Dispose();
    }
}
```

Ownership is the key idea. If your class creates the disposable object and keeps it, your class normally owns it. If a disposable object is passed into your class, decide whether ownership is transferred and make that clear.

For example, this class probably does not own the writer:
```cs
public sealed class ReportFormatter
{
    private readonly TextWriter _writer;

    public ReportFormatter(TextWriter writer)
    {
        _writer = writer;
    }

    public void WriteTitle(string title)
    {
        _writer.WriteLine($"# {title}");
    }
}
```

The caller passed the `TextWriter` in, so the caller probably controls its lifetime.

Disposal is not mainly about memory optimization. It is about correct resource lifetime. But correct disposal often prevents memory symptoms too, because resource-owning objects may hold buffers, native state, callbacks, or handles alive.

Once resource ownership is clear, the next habit is to avoid keeping data alive accidentally through static state and long-lived collections.

# Be careful with static state and long-lived collections

Static fields are convenient, but they can keep objects alive until the application exits. Long-lived collections can do the same.

This is risky:
```cs
public static class GlobalMessages
{
    public static List<string> AllMessages { get; } = new();
}
```

If the application adds messages forever and never removes them, memory usage will grow forever.

A better design depends on the intention. If you only need recent messages, keep a bounded collection:
```cs
public sealed class RecentMessages
{
    private readonly Queue<string> _messages = new();
    private readonly int _maximumCount;

    public RecentMessages(int maximumCount)
    {
        _maximumCount = maximumCount;
    }

    public void Add(string message)
    {
        _messages.Enqueue(message);

        while (_messages.Count > _maximumCount)
        {
            _messages.Dequeue();
        }
    }
}
```

The important difference is not the use of `Queue<T>` instead of `List<T>`. The important difference is that the collection has a memory policy.

Every long-lived collection should have an answer to at least one of these questions:

- When are items removed?
- What is the maximum size?
- When does the owning object itself go away?

If there is no answer, the collection may become an accidental memory leak.

Static state also makes testing harder because state can survive between operations or tests. That is not just a design issue; it can hide memory problems because objects stay reachable in ways that are not obvious from local code.

A good default is to avoid static mutable collections unless they represent intentional application-wide state. If you do use them, make their growth and cleanup rules explicit.

Collections are not the only way to hold references too long. Subscriptions and callbacks need the same care.

# Treat subscriptions as references

An event subscription is a reference. A timer callback is a reference. A delegate stored in a field is a reference. A lambda passed to a long-lived service may become a reference. If the publisher or callback owner lives longer than the subscriber, the subscriber can be kept alive unexpectedly.

This pattern is risky:
```cs
public sealed class StatusPanel
{
    public StatusPanel(AlertService alerts)
    {
        alerts.AlertRaised += OnAlertRaised;
    }

    private void OnAlertRaised(object? sender, string message)
    {
        Console.WriteLine(message);
    }
}
```

If `AlertService` lives for the whole application lifetime, it can keep the `StatusPanel` alive through the event subscription.

A safer version unsubscribes:
```cs
public sealed class StatusPanel : IDisposable
{
    private readonly AlertService _alerts;

    public StatusPanel(AlertService alerts)
    {
        _alerts = alerts;
        _alerts.AlertRaised += OnAlertRaised;
    }

    private void OnAlertRaised(object? sender, string message)
    {
        Console.WriteLine(message);
    }

    public void Dispose()
    {
        _alerts.AlertRaised -= OnAlertRaised;
    }
}
```

The same principle applies to timers:
```cs
public sealed class Heartbeat : IDisposable
{
    private readonly Timer _timer;

    public Heartbeat()
    {
        _timer = new Timer(
            callback: _ => Console.WriteLine("Still running..."),
            state: null,
            dueTime: TimeSpan.Zero,
            period: TimeSpan.FromSeconds(1));
    }

    public void Dispose()
    {
        _timer.Dispose();
    }
}
```

If something can call your object later, something probably has a reference to your object now.

This does not mean every event subscription must be wrapped in `IDisposable`. If the publisher and subscriber have the same lifetime, it may not matter. The risky case is a short-lived subscriber attached to a long-lived publisher.

Thinking of subscriptions as references makes memory behavior easier to reason about. The next habit is similar: do not keep large object graphs when small summaries would do.

# Store only what you need

A single reference can keep a large graph of objects alive. This is easy to miss because the reference itself looks small:
```cs
_lastOrder = order;
```

That field stores one reference. But the order might refer to a customer, address, order lines, products, discounts, audit entries, and other related objects. Keeping the order alive may keep the whole graph alive.

If you only need to display a summary, store a summary:
```cs
_lastOrder = new OrderSummary
{
    OrderId = order.Id,
    CustomerName = order.Customer.Name,
    Total = order.Total
};
```
The summary keeps only the values needed for the next operation. The larger object graph can become unreachable when the rest of the program stops using it.

This habit is useful in UI applications, web applications, background services, caches, logs, and game systems. For example, a game might not need to keep a whole level object alive just to display the name of the previous level. A web application might not need to keep a full request object just to record a status code and duration.

> **Good practice**: Do not keep an object graph alive when a small value object would do.

This also connects to choosing between classes and structs. Small immutable value types can be useful for compact summaries, but they should be used deliberately.

# Choose between struct and class deliberately

Value types and reference types have different memory behavior. A value type directly contains its data. A reference type variable contains a reference to an object. That affects copying, allocation, identity, and performance.

Use a class when the type represents an entity with identity, shared state, inheritance, or a longer lifetime:
```cs
public sealed class Customer
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
}
```

Two customers with the same values might still be different conceptual objects. A class is a good fit.

Use a `struct` for small values that behave like a single piece of data:
```cs
public readonly struct Coordinate
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }
}
```

A coordinate is naturally a value. If two coordinates have the same `X` and `Y`, they can usually be treated as equal values.

Prefer immutable or readonly structs. Mutable structs can surprise readers because assigning them copies the value:
```cs
Coordinate first = new Coordinate(10, 20);
Coordinate second = first;
```

The assignment copies the coordinate. That is fine for a small immutable value. It becomes confusing for larger mutable structs.

Avoid large structs unless you have a measured reason. Copying a large struct copies all its fields, which can become expensive. Passing large structs around can cost more than using a reference type.

> **Good practice**: Use classes for objects with identity. Use small, immutable structs for simple values.

Do not choose struct only because you think it will avoid heap allocation. The real behavior depends on where and how the value is used. Boxing, interface conversions, arrays, fields, generics, and closures can all affect allocation and copying. Use design semantics first, then measure if performance matters.

After choosing the right type shape, the next habit is to avoid unnecessary allocation in repeated code.

# Avoid unnecessary allocation in hot paths

A hot path is code that runs frequently enough for small inefficiencies to matter. Examples include a game update loop, a parser loop, a high-traffic web endpoint, a serializer, a rendering method, or a data-processing pipeline.

This code is usually fine if it runs occasionally:
```cs
string message = $"Processed item {item.Id}";
logger.Log(message);
```

If it runs millions of times, the repeated string allocations may matter.

Similarly, this code is readable and often appropriate:
```cs
return values
    .Where(value => value.IsValid)
    .Select(value => value.Score)
    .Average();
```

If profiling shows this query is on a hot path and allocates too much, a loop might be better:
```cs
int count = 0;
double total = 0;

foreach (Value value in values)
{
    if (value.IsValid)
    {
        total += value.Score;
        count++;
    }
}

return count == 0 ? 0 : total / count;
```

The loop is less expressive, but it gives more control.

Common allocation sources in hot paths include:
- String concatenation in loops
- LINQ queries that run repeatedly
- Lambdas that capture variables
- Temporary arrays
- Boxing value types
- Creating new collections without setting a useful capacity
- Repeated large buffer allocation

A simple improvement is to set collection capacity when the approximate size is known:
```cs
List<int> numbers = new(capacity: expectedCount);
```

Another is to use `StringBuilder` for repeated string building. For more advanced hot paths, consider spans, stack allocation, and pooling. But use those tools because measurement shows the path matters, not because every allocation must be avoided.

Avoiding unnecessary allocation is most useful when the code is repeated often. For occasional code, clarity usually wins.

The next habit is about larger allocations, where the cost can matter even if they happen less often.

# Be careful with large objects and buffers

Large arrays and buffers deserve more attention than small short-lived objects. Repeatedly allocating large arrays can put pressure on the Large Object Heap and may lead to more expensive garbage collection.

This pattern can become expensive if it happens frequently:
```cs
byte[] buffer = new byte[100_000];
```

If the buffer is created occasionally, that may be fine. If it is created for every request, every file chunk, every frame, or every message, you should consider another approach.

Sometimes the best solution is to process data in smaller chunks:
```cs
byte[] buffer = new byte[16 * 1024];
```

Sometimes it is to reuse a buffer:
```cs
byte[] buffer = new byte[100_000];

foreach (string path in filePaths)
{
    ProcessFile(path, buffer);
}
```

Sometimes it is to rent a buffer from ArrayPool<T>:
```cs
byte[] buffer = ArrayPool<byte>.Shared.Rent(100_000);

try
{
    Process(buffer.AsSpan(0, 100_000));
}
finally
{
    ArrayPool<byte>.Shared.Return(buffer);
}
```

Pooling is useful when the allocation pattern justifies the extra complexity. It is not a default replacement for new.

Also be aware of sensitive data. If a buffer contains passwords, tokens, keys, personal data, or confidential content, clear it before reuse or before returning it to a pool:
```cs
ArrayPool<byte>.Shared.Return(buffer, clearArray: true);
```

This has a cost, but correctness and privacy matter more than a small performance gain.

Large objects are not bad. Many applications need large arrays, buffers, images, documents, and data blocks. The good practice is to make large allocation intentional and measured.

That leads to a more general warning: pooling can help, but premature pooling can hurt.

# Avoid premature pooling

Pooling sounds efficient because it reuses objects. But pooling also keeps objects alive. A pool can increase baseline memory usage, complicate ownership, introduce threading issues, and create bugs if objects are not reset correctly.

Do not pool ordinary small objects like this:
```cs
// Usually unnecessary.
Customer customer = customerPool.Get();
```

The .NET garbage collector is optimized for short-lived small objects. Creating a small object and letting it die young is often cheaper and safer than managing a pool yourself.

Pooling is more reasonable for large arrays, expensive objects, reusable buffers, parser instances, serializer state, or objects used at high frequency in a hot path.

A pooled object must be reset before reuse:
```cs
Parser parser = parserPool.Get();

try
{
    parser.Parse(input);
}
finally
{
    parser.Reset();
    parserPool.Return(parser);
}
```

If `Reset` misses a field, the next user of the object might see stale state. That can create subtle bugs.

A returned object must not still be used by the caller:
```cs
parserPool.Return(parser);

// Do not use parser after this point.
```

The pool owns the object again. Another part of the application might receive it.

Pooling is most useful when all of these are true:
- The object is expensive to allocate or initialize
- The object can be reset safely
- The object is used frequently
- Profiling shows allocation pressure matters

If those conditions are not true, prefer ordinary allocation.

Pooling is one example of a broader principle: advanced memory features should be introduced only when they make the code measurably better.

# Use spans and memory types where they fit naturally

`Span<T>`, `ReadOnlySpan<T>`, `Memory<T>`, and `ReadOnlyMemory<T>` are powerful, but they are not meant to replace arrays, strings, and lists everywhere.

Use spans when you want to work with a slice of existing data without copying it:
```cs
static bool HasPrefix(string value, string prefix)
{
    return value.AsSpan().StartsWith(prefix);[al9.1]
}
```

Use spans for APIs that write into caller-provided memory:
```cs
static bool TryWriteCode(int number, Span<char> destination)
{
    return number.TryFormat(destination, out _);
}
```

Use `Memory<T>` or `ReadOnlyMemory<T>` when the memory needs to be stored or used by asynchronous APIs:
```cs
static Task WriteAsync(Stream stream, ReadOnlyMemory<byte> buffer)
{
    return stream.WriteAsync(buffer).AsTask();
}
```

Do not use these types merely to make code look advanced. For example, if you need a string, create a string. If you need a list, use a list. If the data is naturally long-lived, do not force it into a short-lived span-based design.

The best span-based code usually appears at boundaries:
- Parsing text
- Processing buffers
- Formatting values
- Working with protocols
- Avoiding substring or subarray allocation
- Writing high-throughput library APIs

For ordinary domain logic, classes, records, lists, and strings are often more appropriate.

This is the same pattern again: use the higher-level C# feature by default, and use lower-level memory features when the problem justifies them.

# Avoid calling GC.Collect() in normal application code

C# lets you request a garbage collection by calling `GC.Collect()`. That does not mean you should.

The garbage collector already decides when collection is useful based on runtime conditions. Forcing a collection can make performance worse. It can do expensive work at the wrong time, promote objects that would otherwise have died young, and hide the real allocation problem.

Calling `GC.Collect()` is sometimes seen in test code, demos, or highly specialized scenarios. It might also appear in diagnostic experiments when you are trying to force a collection before taking a measurement. But it should not be part of ordinary application logic.

If memory is high because objects are still reachable, forcing a collection will not fix the problem. The objects are alive. You need to remove the references by keeping them alive.

If memory is high because of allocation pressure, forcing collection may reduce memory briefly while making throughput worse. You need to reduce unnecessary allocation or change the workload.

If memory is high because of unmanaged resources, forcing GC is the wrong tool. You need correct disposal.

> **Good practice**: Do not manage the garbage collector manually. Manage your object lifetimes and allocation patterns.

This rule fits the larger journey of the book. In C, you manually release memory. In C++, you use deterministic ownership patterns. In C#, you cooperate with the runtime and intervene only when you have evidence.

The final habit is the one that keeps all the others honest: measure changes.

# Measure before and after changes

Memory optimization without measurement is guesswork. You might improve performance, but you might also make code more complicated while changing nothing important.

Before changing code, decide what problem you are solving. For example:
- The application uses more memory after every import
- The game pauses every few seconds during play
- The API allocates heavily under load
- Opening and closing a window repeatedly leaves old view models alive

Then choose a measurement. Use dotnet-counters, Visual Studio memory tools, dotnet-gcdump, dotnet-dump, PerfView, or a third-party profiler. Capture enough information to understand the current behavior.

After making the change, repeat the same test. The same workload matters. If the before-and-after tests are different, the result is less useful.
The decision might be that the optimization worked. It might be that the code became more complex without enough benefit. It might be that the real problem was somewhere else.

Memory-aware C# is not about rejecting the garbage collector. It is about understanding it well enough to write code that fits it. Let short-lived objects die. Release external resources promptly. Remove references when objects should no longer be kept. Avoid unnecessary allocation in hot paths. Use spans and pooling when the evidence supports them. Measure before and after.

These habits complete the memory-management journey from C to C++ to C#. In C, you controlled memory directly. In C++, you used language features and RAII to make ownership safer. In C#, the runtime manages most memory cleanup for you, but you still design lifetimes, release resources, control allocation pressure, and verify behavior with diagnostics.

In *Chapter 14*, you will apply C# in a different context: building games with Unity. Games make memory behavior visible because allocation, pauses, assets, object lifetimes, and frame rates are tightly connected. The memory habits from *Chapter 13* will help you write Unity code that is not only correct, but smooth and responsive.
