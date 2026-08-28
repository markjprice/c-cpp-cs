# Avoiding memory leaks in managed code

C# has garbage collection, but C# programs can still leak memory. The leak usually does not happen because memory is unreachable and the runtime fails to reclaim it. The leak happens because memory is still reachable when you did not intend it to be.

This is an important difference from C and C++. In C, a memory leak often means you allocated memory and forgot to call free. In C++, it can mean you used new and forgot delete, or you designed ownership incorrectly. In C#, a memory leak usually means some object is still holding a reference to another object, keeping it alive for too long.

The garbage collector is not allowed to guess that an object is no longer useful. If the object is reachable from a GC root, directly or indirectly, then the object must be treated as alive. That is true even if your program will never use the object again.

This section shows the most common ways that managed objects are kept alive accidentally. You will learn why static fields, long-lived collections, events, timers, captured variables, caches, and undisposed resources can all retain memory. 

Once you understand that managed leaks are usually unwanted references, the first pattern to watch for is long-lived state.
Many of the code examples in this section use the following class:
```cs
public class CrewMember
{
    public required string Name { get; set; }
    public string Role { get; set; } = "";
    public int Rank { get; set; }

    public CrewMember() { }
    public CrewMember(string name) => Name = name;
}
```

# Long-lived references

A short-lived object usually does not cause much trouble. It is created, used, becomes unreachable, and is eventually collected. Problems begin when a long-lived object refers to something that should have been short-lived.

Static fields are the simplest example. A `static` field can live for the lifetime of the application process:
```cs
public static class CrewRegistry
{
    public static List<CrewMember> Members { get; } = new();
}
```

This code is not automatically wrong. Sometimes global application-level data is appropriate. But any `CrewMember` added to the static list will remain reachable until it is removed or the process ends:
```cs
CrewRegistry.Members.Add(new CrewMember
{
    Name = "Nyota Uhura",
    Role = "Communications Officer"
});
```

The `CrewMember` object is now reachable through the static `Members` property. The GC cannot collect it while the list holds a reference to it.

Long-lived collections can cause the same issue even when they are not static. For example, a service object in a web application might live for the whole application lifetime. If it stores every request object it has ever seen, then memory use will grow over time:
```cs
public sealed class RequestLog
{
    private readonly List<RequestInfo> _requests = new();

    public void Add(RequestInfo request)
    {
        _requests.Add(request);
    }
}
```

If `_requests` is never trimmed, cleared, or bounded, it can grow forever. The garbage collector will not collect the `RequestInfo` objects because the list still refers to them.

A safer design is to store only what you need, limit how much you keep, or remove entries when they are no longer useful:
```cs
public sealed class RequestLog
{
    private readonly Queue<RequestInfo> _requests = new();
    private readonly int _maximumCount;

    public RequestLog(int maximumCount)
    {
        _maximumCount = maximumCount;
    }

    public void Add(RequestInfo request)
    {
        _requests.Enqueue(request);

        while (_requests.Count > _maximumCount)
        {
            _requests.Dequeue();
        }
    }
}
```

This version keeps a bounded history. It still uses memory, but the memory use has an intended limit.

The same principle applies to dictionaries, queues, lists, sets, and custom object graphs. A collection is often a memory leak waiting to happen if it grows without a policy for removing old data.

> **Good practice**: Before moving to more specific patterns, remember the practical rule: If an object lives for a long time, be careful what it references.

Static fields and long-lived collections are obvious once you know to look for them. Events are less obvious, because the reference is hidden behind a subscription.

# Event subscriptions

Events are a common source of managed-memory leaks. The problem is not the event itself. The problem is forgetting that an event subscription creates a reference from the publisher to the subscriber.

Suppose you have a long-lived publisher:
```cs
public sealed class AlertService
{
    public event EventHandler<string>? AlertRaised;

    public void RaiseAlert(string message)
    {
        AlertRaised?.Invoke(this, message);
    }
}
```

Now suppose a short-lived object subscribes to the event:
```cs
public sealed class AlertWindow
{
    public AlertWindow(AlertService alertService)
    {
        alertService.AlertRaised += OnAlertRaised;
    }

    private void OnAlertRaised(object? sender, string message)
    {
        Console.WriteLine(message);
    }
}
```

The `AlertService` now has a reference to the `AlertWindow` instance through the event handler. If `AlertService` lives for the whole application lifetime, the `AlertWindow` might also stay alive for the whole application lifetime, even if the user closed the window and you expected it to be collected.

The fix is to unsubscribe when the subscriber is finished:
```cs
public sealed class AlertWindow : IDisposable
{
    private readonly AlertService _alertService;

    public AlertWindow(AlertService alertService)
    {
        _alertService = alertService;
        _alertService.AlertRaised += OnAlertRaised;
    }

    private void OnAlertRaised(object? sender, string message)
    {
        Console.WriteLine(message);
    }

    public void Dispose()
    {
        _alertService.AlertRaised -= OnAlertRaised;
    }
}
```

Now the object that subscribes also knows how to unsubscribe. This makes the subscription part of the object’s resource lifetime. The object is not only using memory. It is also connected to a long-lived publisher, so it needs cleanup.

You can then use it with using when the lifetime is local:
```
using AlertWindow window = new AlertWindow(alertService);
```

In UI applications, the lifetime might instead be tied to a close event or a framework-specific disposal hook. The important idea is the same: if a short-lived object subscribes to an event on a long-lived object, it should usually unsubscribe.

This is not necessary in every event scenario. If the publisher and subscriber have the same lifetime, or if the publisher is shorter-lived than the subscriber, then the subscription might not create a leak. The risky pattern is:
```
Long-lived publisher -> event subscription -> short-lived subscriber
```

Events feel lightweight, but they are references. Once you see them that way, the leak pattern becomes much easier to understand.

A similar issue appears with timers and background callbacks.

# Timers and callbacks

Timers are useful because they let code run later or repeatedly. But a timer can also keep an object alive.

Consider this class:
```cs
public sealed class StatusPoller
{
    private readonly Timer _timer;

    public StatusPoller()
    {
        _timer = new Timer(
            callback: CheckStatus,
            state: null,
            dueTime: TimeSpan.Zero,
            period: TimeSpan.FromSeconds(10));
    }

    private void CheckStatus(object? state)
    {
        Console.WriteLine("Checking status...");
    }
}
```

The timer refers to the callback. The callback is an instance method. An instance method needs an instance, so the timer can keep the `StatusPoller` object alive.

This class also owns a disposable object: the timer. It should dispose it when polling is no longer needed:
```cs
public sealed class StatusPoller : IDisposable
{
    private readonly Timer _timer;

    public StatusPoller()
    {
        _timer = new Timer(
            callback: CheckStatus,
            state: null,
            dueTime: TimeSpan.Zero,
            period: TimeSpan.FromSeconds(10));
    }

    private void CheckStatus(object? state)
    {
        Console.WriteLine("Checking status...");
    }

    public void Dispose()
    {
        _timer.Dispose();
    }
}
```

This pattern should feel familiar from the *Cleaning up resources with IDisposable* section in the print book. If your type owns a disposable object, your type usually becomes disposable too.

Modern .NET also has timer-related APIs that are used with asynchronous code, such as `PeriodicTimer`. The same principle applies: if an object represents ongoing work, repeated callbacks, or a background resource, make its lifetime explicit.

Timers can be especially troublesome because they are easy to start and easy to forget. A timer that is no longer needed might continue firing. Even if the callback does very little, the timer can still keep objects alive and consume resources.

This pattern also appears in event loops, scheduling APIs, message subscriptions, observable streams, and framework callbacks. If something can call you later, ask what reference it holds to make that possible.

The next leak pattern is related but more subtle: captured variables in lambdas and local functions.

# Captured variables and closures

C# makes it easy to write lambdas and local functions that use variables from the surrounding scope. This is called capturing:
```cs
int minimumRank = 5;

Func<CrewMember, bool> isSenior =
    member => member.Rank >= minimumRank;
```

The lambda uses `minimumRank`, even though `minimumRank` was declared outside the lambda. The compiler makes that work by preserving the captured variable in an object called a **closure**.

Closures are not bad. They are one of the features that make modern C# expressive. You used lambda expressions and functional-style programming in earlier C# chapters, and they are useful throughout .NET. But a closure can accidentally keep more data alive than you intended.

For example:
```cs
public sealed class SearchService
{
    private Func<CrewMember, bool>? _lastSearch;

    public void Search(List<CrewMember> crew, int minimumRank)
    {
        _lastSearch = member => crew.Contains(member)
                              && member.Rank >= minimumRank;
    }
}
```

The lambda captures both `crew` and `minimumRank`. Because `_lastSearch` is stored in a field, the captured crew list may remain alive as long as the `SearchService` keeps the delegate.

That might be surprising. You might think the search operation is finished, but the delegate still refers to the captured variables. If crew is a large list, this can retain significant memory.

A better design is to avoid capturing large objects unnecessarily:
```cs
public sealed class SearchService
{
    private int _lastMinimumRank;

    public void Search(IEnumerable<CrewMember> crew, int minimumRank)
    {
        _lastMinimumRank = minimumRank;

        foreach (CrewMember member in crew)
        {
            if (member.Rank >= minimumRank)
            {
                Console.WriteLine(member.Name);
            }
        }
    }

    // Other code that uses _lastMinimumRank.
}
```

This version stores only the small piece of data it actually needs later.

Captures can also occur in event handlers:
```cs
public void Register(Button button, LargeReport report)
{
    button.Click += (_, _) => ShowReport(report);
}
```

The lambda captures `report`. If the button is long-lived, it can keep the large report alive too.

Again, the lesson is not “never use lambdas.” The lesson is to be aware of what a lambda captures, especially when the lambda is stored, subscribed, or passed to something long-lived.

C# gives you a useful clue: if a lambda uses variables from outside itself, ask whether those variables might be kept alive longer than expected.

> **Prompt**: Please explain closures in C# from a memory point of view. Show how a lambda can capture a large object accidentally and keep it alive longer than intended.

Closures can keep objects alive accidentally. Caches can do the same thing deliberately, which makes them useful and dangerous.

# Caches that never shrink

A cache stores data so that future operations can reuse it instead of recalculating it or reloading it. Caches can improve performance dramatically. They can also become memory leaks if they grow without limits.

Consider this simple cache:
```cs
public sealed class ProfileCache
{
    private readonly Dictionary<int, UserProfile> _profiles = new();

    public UserProfile GetProfile(int userId)
    {
        if (_profiles.TryGetValue(userId, out UserProfile? profile))
        {
            return profile;
        }

        profile = LoadProfile(userId);
        _profiles[userId] = profile;
        return profile;
    }

    private static UserProfile LoadProfile(int userId)
    {
        return new UserProfile(userId);
    }
}
```

This cache never removes anything. If the application sees millions of different users over time, the dictionary may eventually contain millions of profiles. The GC cannot collect them because the dictionary still holds references to them.

A better cache needs a policy. For example, it might have a maximum size, remove entries after a period of inactivity, use expiration times, or rely on a framework-provided cache that supports limits.

Here is a deliberately simple size-limited example:
```cs
public sealed class ProfileCache
{
    private readonly Dictionary<int, UserProfile> _profiles = new();
    private readonly Queue<int> _order = new();
    private readonly int _maximumCount;

    public ProfileCache(int maximumCount)
    {
        _maximumCount = maximumCount;
    }

    public UserProfile GetProfile(int userId)
    {
        if (_profiles.TryGetValue(userId, out UserProfile? profile))
        {
            return profile;
        }

        profile = LoadProfile(userId);

        _profiles[userId] = profile;
        _order.Enqueue(userId);

        while (_profiles.Count > _maximumCount)
        {
            int oldestUserId = _order.Dequeue();
            _profiles.Remove(oldestUserId);
        }

        return profile;
    }

    private static UserProfile LoadProfile(int userId)
    {
        return new UserProfile(userId);
    }
}
```

This example is not a production-quality cache. It does not update the order when an existing item is reused, and it is not thread-safe. But it demonstrates the important point: a cache should have an eviction policy.

In real applications, you would often use existing caching libraries or framework features rather than writing your own. For example, ASP.NET Core has memory caching support. The design question remains the same: how large can the cache grow, and when are entries removed?

A cache without limits is just a collection that grows forever with a more respectable name.

Caches are one way to keep memory alive intentionally. Undisposed resources are another way to keep resource-related objects alive longer than expected.

# Undisposed resources

The previous section explained IDisposable, so this section will not repeat the full disposal pattern. The memory-leak angle is simpler: if you do not dispose objects that should be disposed, you can retain resources and memory longer than necessary.

Consider this code:
```cs
static string ReadFirstLine(string path)
{
    StreamReader reader = new StreamReader(path);

    return reader.ReadLine() ?? "";
}
```

The method returns after reading one line, but the `StreamReader` is never disposed. Eventually, the object may become unreachable and the runtime may clean up some associated state. But you should not rely on eventual cleanup for file handles or other external resources.

The correct version uses using:
```cs
static string ReadFirstLine(string path)
{
    using StreamReader reader = new StreamReader(path);

    return reader.ReadLine() ?? "";
}
```

Undisposed resources are not always described as memory leaks, because the most immediate problem might be a file handle, socket, database connection, or native resource. But they often show up alongside memory symptoms. A resource-owning object might keep buffers alive. A database-related object might keep unmanaged state alive. A timer might keep callbacks alive. A stream might keep internal buffers alive.

A useful habit is to treat disposable ownership as part of memory design. If your code creates a disposable object, it should usually dispose it. If your class stores a disposable object in a field, your class probably needs to implement `IDisposable`.

You should also be careful with APIs that return disposable objects:
```cs
Stream stream = OpenLargeFile();
```

If `OpenLargeFile` returns a stream, the caller likely owns it and should dispose it:
```cs
using Stream stream = OpenLargeFile();
```

Disposal does not replace garbage collection. It complements it. `Dispose` releases resources promptly. The GC later reclaims the managed object’s memory when it is no longer reachable.

The next common issue is not forgetting disposal, but holding on to more data than you need.

# Keeping too much object graph alive

A single reference can keep a large object graph alive. This is easy to miss because the reference itself looks small:
```cs
Order order = LoadOrder(orderId);

_lastOrder = order;
```

The `_lastOrder` field stores one reference. But the `Order` object might refer to customer details, addresses, order lines, product records, discounts, audit entries, and other objects. Keeping one order alive can keep hundreds or thousands of related objects alive.

The same issue appears when you keep a small slice of a larger object. For example, you might store an object that contains a reference back to a parent object, which refers to a much larger graph:
```cs
OrderLine line = order.Lines[0];

_recentLine = line;
```

If `OrderLine` has a reference back to its `Order`, then storing one line might keep the whole order alive. This depends on how the model is designed.

This is not a reason to avoid object relationships. Object graphs are how useful programs represent complex data. But long-lived references should be intentional. If you only need a few values, copy those values into a smaller object instead of retaining the whole graph:
```cs
_recentLine = new RecentLineSummary
{
    OrderId = order.Id,
    ProductName = line.ProductName,
    Quantity = line.Quantity
};
```

This keeps only the data needed for the recent-line summary. It allows the larger order graph to become unreachable when the rest of the program no longer needs it.

This pattern is common in web applications, background services, and UI applications. A view model, cache entry, log item, or background task might accidentally hold an entire domain model when it only needs two or three values.

When memory use is higher than expected, ask not only “Which objects are alive?” but also “What is keeping this entire graph alive?”

This leads to one of the most important habits in managed code: design ownership and lifetime explicitly.

# Designing clear ownership and lifetime

Managed memory makes allocation easy, but it does not remove the need to think about ownership. Ownership answers the question: who is responsible for deciding how long this object should be kept?

In simple local code, ownership is obvious:
```cs
static void PrintReport()
{
    Report report = BuildReport();

    Console.WriteLine(report.Title);
}
```

The `report` is used inside the method. If it is not stored elsewhere, it can become unreachable after the method returns.

Ownership becomes less obvious when objects are stored, shared, subscribed, cached, or passed to background work.

For each long-lived reference, ask:
- Why is this object being stored?
- How long should it be stored?
- What removes it?
- Does it refer to a larger object graph?
- Does it own disposable resources?
- Does it subscribe to events or callbacks?
- Could this grow without limits?

You do not need heavy architecture for every small program. But even a simple naming or design convention helps. For example, a type named `RecentOrdersCache` should have cache-like behavior, including limits or expiration. A type named `ActiveConnections` should remove connections when they close. A type named `Subscriptions` should unsubscribe when the owning object is disposed.

Here is a simple example that makes lifetime explicit:
```cs
public sealed class ActiveUsers
{
    private readonly Dictionary<Guid, UserSession> _sessions = new();

    public void Add(UserSession session)
    {
        _sessions[session.Id] = session;
    }

    public void Remove(Guid sessionId)
    {
        _sessions.Remove(sessionId);
    }
}
```

The `Remove` method matters as much as the `Add` method. A collection that represents active data should usually have a way to remove inactive data.

In C#, you rarely say, “This object must be freed here.” But you should often say, “This object should no longer be reachable after this point.” That is the managed-memory version of lifetime design.

Once the intended lifetime is clear, you need a way to notice when the actual lifetime is wrong.

# Recognizing memory leaks

A memory leak in managed code often appears as memory use that grows over time and does not return to a stable level after the application finishes its work.
For example, a service might use more memory each hour, even when the number of users stays roughly the same. A desktop app might become slower after opening and closing the same window many times. A game might show increasing memory use each time the player changes level. A test suite might pass functionally but use more memory after each test case.

The important clue is repeated behavior. One large operation might legitimately need more memory. A leak usually shows up when the same operation is repeated and memory keeps increasing.

You can often create a simple manual test:
1.	Start the application.
2.	Perform an operation once.
3.	Return to the original state.
4.	Perform the same operation many times.
5.	Watch whether memory stabilizes or keeps growing.

For example, open and close the same window 50 times. Run the same import job 20 times. Send the same kind of request repeatedly. Load and unload the same game scene many times.

If memory grows at first and then stabilizes, that might be normal. The runtime, libraries, JIT compiler, caches, and connection pools may warm up. If memory grows steadily without stabilizing, investigate further.

Do not rely only on **Task Manager** or a single memory number. Managed memory, private bytes, working set, native memory, and committed memory are related but not identical. In *Chapter 13, x*, , you will learn about diagnostic tools that can show object counts, allocation stacks, GC behavior, and memory dumps.
Good practice: Recognize suspicious patterns. Repeated operation + memory keeps growing + objects remain reachable = likely managed leak.

Once you suspect a leak, start with the common causes from this section: static collections, event subscriptions, timers, closures, caches, undisposed resources, and unexpectedly large object graphs.

# Reducing the risk of managed leaks

You cannot prevent every memory problem by following a checklist, but you can reduce the risk with a few habits.

- Keep long-lived collections bounded or removable. If a collection is meant to represent current state, remove items when they are no longer current. If it is a cache, give it an eviction policy.
- Unsubscribe from events when a short-lived object subscribes to a long-lived publisher. If the subscription is part of the object’s lifetime, consider unsubscribing in `Dispose`.
- Dispose what you own. If your class creates or owns a disposable object, it should usually dispose it. If your class receives a disposable object from outside, be clear about whether ownership is transferred.
- Be cautious with lambdas that capture large objects. This matters most when the lambda is stored, returned, subscribed, or passed to a long-lived object.
Avoid storing whole object graphs when you only need a summary. Copy the small amount of data you need into a smaller object.
- Do not use static state as a convenient dumping ground. Static fields are easy to access, but they can also keep data alive until the application exits.
- Measure before making complex changes. A suspected leak should eventually be confirmed with diagnostic tools. Guessing can lead you to make code more complicated without fixing the real problem.

These habits do not replace the garbage collector. They help the garbage collector do its job by allowing objects to become unreachable when they are no longer needed.

You have now seen how strong references can keep objects alive accidentally. In some designs, you want to refer to an object without preventing it from being collected. The [*Weak references and object handles*](ch12-cs-weak-references.md) section introduces weak references and object handles, two more advanced tools for specialized memory-management scenarios.
