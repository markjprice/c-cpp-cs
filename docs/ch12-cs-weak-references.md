# Weak references and object handles

- [Weak references and object handles](#weak-references-and-object-handles)
- [Strong references](#strong-references)
- [Weak references](#weak-references)
- [Weak references in cache-like scenarios](#weak-references-in-cache-like-scenarios)
- [Weak references and subscriptions](#weak-references-and-subscriptions)
- [Object handles with GCHandle](#object-handles-with-gchandle)
- [Choosing between strong and weak references](#choosing-between-strong-and-weak-references)

In the [*Avoiding memory leaks in managed code*](ch12-cs-memory-leaks.md) section, you learned that managed-memory leaks usually happen because objects remain reachable. A static collection, event subscription, timer, closure, cache, or long-lived object graph can keep objects alive long after you intended to stop using them.

Most references in C# are strong references. A **strong reference** keeps an object alive. If an object can be reached through one or more strong references, the garbage collector must treat it as live.

Sometimes you want a different relationship. You might want to remember an object if it is still available, but you do not want that memory to be kept alive just because of your reference. That is where weak references are useful.

A **weak reference** allows your code to refer to an object without preventing the garbage collector from collecting it. This is a specialist tool. It is not a replacement for good ownership design, and it is not the first answer to most memory problems. But it is useful for understanding how managed memory can support optional, cache-like, or observer-like relationships.

This section also introduces `GCHandle`, an advanced API that can create handles to managed objects for interop and runtime-level scenarios. You will probably use `WeakReference<T>` occasionally and `GCHandle` rarely. The goal here is to understand when these tools exist, not to make them part of everyday code.

Before looking at weak references, it helps to compare them with the normal strong references you have used throughout the book.

# Strong references

A strong reference is the normal kind of reference in C#:
```cs
CrewMember officer = new CrewMember("Nyota Uhura");
```

The variable `officer` strongly refers to the `CrewMember` object. While that reference is active, the object is reachable and cannot be collected.

Strong references are also created when objects refer to other objects through fields, properties, arrays, collections, delegates, and events:
```cs
List<CrewMember> crew = new();

crew.Add(new CrewMember("Spock"));
crew.Add(new CrewMember("Leonard McCoy"));
```

The list strongly refers to the two `CrewMember` objects. If the list is reachable, then the objects in the list are reachable too.

This is the behavior you usually want. If you put an object into a list, you normally expect it to stay there until you remove it. If an object stores another object in a field, you normally expect that field to keep the object alive.

But this is also how managed-memory leaks happen. If the list lives for the lifetime of the application, then the objects inside the list also live until they are removed or the process ends:
```cs
public static class CrewArchive
{
    public static List<CrewMember> Members { get; } = new();
}
```

Every object added to `CrewArchive.Members` is strongly referenced by a static collection. The garbage collector cannot decide that an old crew member is “probably not needed.” The object is reachable, so it stays alive.

The fix is usually not to use weak references. The fix is usually to remove objects when they should no longer be kept:
```cs
CrewArchive.Members.Remove(member);
```

Clear ownership and removal rules should be your default approach. Weak references are for cases where you deliberately want a reference that does not imply ownership.

That brings us to `WeakReference<T>`.

# Weak references

A weak reference refers to an object without keeping it alive. In modern C#, you should usually use the generic `WeakReference<T>` type rather than the older non-generic `WeakReference` type:
```cs
CrewMember member = new CrewMember("Beverly Crusher");

WeakReference<CrewMember> weak = new WeakReference<CrewMember>(member);
```

At this point, there are two ways to reach the `CrewMember` object:
```
member -> CrewMember object       strong reference

weak   -> CrewMember object       weak reference
```

The strong reference keeps the object alive. The weak reference does not.

If the strong reference is removed, then the object may become eligible for collection:
```cs
member = null;
```

The weak reference still exists, but it does not prevent collection. After a future garbage collection, the target object might be gone.

To use a weak reference, call TryGetTarget:
```cs
if (weak.TryGetTarget(out CrewMember? target))
{
    Console.WriteLine(target.Name);
}
else
{
    Console.WriteLine("The crew member object has been collected.");
}
```

This pattern is important. You do not assume the target is still alive. You ask for it, and you handle both possibilities.

If `TryGetTarget` returns `true`, the target was available and the out variable refers to it. That local variable is now a strong reference for as long as it remains active. If `TryGetTarget` returns `false`, the target is no longer available. A weak reference is like saying: Use this object if it is still around, but do not keep it alive just for me.

This can be useful, but it also makes your code less predictable. A weakly referenced object can disappear between operations if no strong references keep it alive. That is why weak references should be used carefully and only when disappearing objects are part of the design.

The most common beginner-friendly example is a soft cache.

# Weak references in cache-like scenarios

A cache normally keeps objects alive so they can be reused. That is useful when the cached values are expensive to create and likely to be reused. But a cache can also cause memory problems if it grows without limits.

A weak-reference cache stores weak references to values. This means the cache can remember how to find an object if it is still alive, but it does not force the object to stay alive.

Here is a small example:
```cs
public sealed class ImageCache
{
    private readonly Dictionary<string, WeakReference<byte[]>> _images = new();

    public byte[] GetImage(string path)
    {
        if (_images.TryGetValue(path, out WeakReference<byte[]>? weak)
            && weak.TryGetTarget(out byte[]? cachedImage))
        {
            return cachedImage;
        }

        byte[] image = File.ReadAllBytes(path);
        _images[path] = new WeakReference<byte[]>(image);
        return image;
    }
}
```

The dictionary strongly references the `WeakReference<byte[]>` objects. But each `WeakReference<byte[]>` only weakly references the byte array. If the application is no longer using a particular byte array anywhere else, the garbage collector is allowed to collect it.

If the image is still available, the cache returns it. If it has been collected, the cache reloads it.

This example demonstrates the idea, but it is not a complete production cache. A real cache would need to think about file changes, error handling, maximum dictionary size, concurrency, and whether weak references actually improve behavior for the workload.

Weak-reference caches can be disappointing if you expect them to behave like normal caches. Because the cached object can disappear, the cache hit rate may be lower than you expect. Also, the dictionary can still grow because it stores keys and weak-reference objects. Even if the target objects are collected, the cache might still need cleanup for dead entries.

For example, you might periodically remove entries whose targets have gone:
```cs
public void RemoveCollectedEntries()
{
    foreach (string key in _images.Keys.ToList())
    {
        if (!_images[key].TryGetTarget(out _))
        {
            _images.Remove(key);
        }
    }
}
```

This is one reason many applications should use a normal bounded cache instead of a weak-reference cache. A bounded cache with clear eviction rules is usually easier to reason about.

Use weak references when it is acceptable for the object to vanish and be recreated. Do not use weak references when the object must remain available for correctness.

Weak references can also appear in observer-like patterns, although they are not a substitute for clear event lifetime management.

# Weak references and subscriptions

In the previous section, you learned that event subscriptions can cause leaks when a short-lived object subscribes to an event on a long-lived object. The usual fix is to unsubscribe.

Sometimes frameworks use a weak event pattern. In a weak event pattern, the publisher does not strongly keep the subscriber alive. Instead, it stores a weak reference to the subscriber or callback target.

With a weak event pattern, a subscriber can be collected if nothing else strongly references it. The event publisher does not keep it alive by accident.

However, weak events are more complex than normal events. The publisher must handle missing targets, remove dead entries, and avoid confusing behavior. The subscriber might disappear if the rest of the program does not hold a strong reference to it.

> **Good practice**: For most beginner and intermediate C# code, the better rule is still: If you subscribe to a longer-lived publisher, unsubscribe when the subscriber is finished.

Weak event patterns are useful in some UI frameworks and library designs, but they should not be your first tool for ordinary event handling.
This is a good example of how weak references fit into C# memory management. They are not there to excuse unclear ownership. They are there for designs where non-ownership is intentional.

> **Prompt**: Please explain when to use WeakReference<T> in C#. Give examples where it is appropriate, examples where it is a bad idea, and explain why weak references are not a substitute for clear ownership.

So far, the weak references you have seen are managed and type-safe. .NET also exposes lower-level object handles for advanced scenarios. These are much closer to runtime and interop work than everyday C# programming.

# Object handles with GCHandle

`GCHandle` is a `struct` in the `System.Runtime.InteropServices` namespace. It lets code create a handle associated with a managed object. This is mainly useful when interacting with unmanaged code or runtime-level APIs.

You should not use `GCHandle` for normal application object lifetime. If your code is not doing interop, pinning, or advanced runtime work, you probably do not need it.

A normal C# reference is enough for ordinary managed code. A `GCHandle` is different. It creates a handle that the runtime understands and that can be converted to or from an `IntPtr` for interop scenarios.

For example:
```cs
GCHandle handle = GCHandle.Alloc(member);

try
{
    IntPtr pointer = GCHandle.ToIntPtr(handle);

    // Pass pointer to unmanaged code that will later pass it back.
}
finally
{
    handle.Free();
}
```

This pattern is advanced. The handle must be freed. Forgetting to call `Free` can keep the object alive and create a leak. This is why `GCHandle` belongs in careful interop code, not casual application code.

A `GCHandle` can have different handle types. The main ones to know about are:
- `Normal`, which keeps the object alive
- `Weak`, which does not keep the object alive
- `WeakTrackResurrection`, which is a specialized weak handle related to finalization
- `Pinned`, which keeps the object alive and prevents the GC from moving it

A normal handle is like a strong reference held through the runtime handle table. It keeps the object alive until the handle is freed.

A weak handle is closer in spirit to `WeakReference<T>`, although most ordinary C# code should prefer `WeakReference<T>`.

A pinned handle is the one you are most likely to see in interop examples. It prevents the garbage collector from moving the object. This can be necessary when native code needs a stable address:
```cs
byte[] buffer = new byte[1024];

GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

try
{
    IntPtr address = handle.AddrOfPinnedObject();

    // Pass address to native code that expects a stable memory address.
}
finally
{
    handle.Free();
}
```

Pinning should be short-lived. The GC normally improves memory layout by moving objects during compaction. A pinned object cannot be moved, so too much pinning can make compaction less effective and increase fragmentation.

This connects back to the earlier explanation of compaction. Managed references allow the runtime to move objects and update references. Pinning says, “Do not move this object for now.” That should be used only when necessary and released as soon as possible.

If you need a stable memory address temporarily, C# also has the fixed statement, which you will see later in the high-performance memory section when unsafe code is introduced. For now, the main lesson is that object handles are advanced tools for crossing the boundary between managed and unmanaged memory.
Prompt: Please explain GCHandle in C# at a beginner-friendly level. Focus on why it exists for interop and pinning, why it must be freed, and why ordinary application code usually should not use it.

# Choosing between strong and weak references

Most of the time, use ordinary strong references. They are simple, safe, predictable, and exactly what you want when one object owns or uses another object.
Use a weak reference only when the object is optional and can be recreated, skipped, or ignored if it has been collected:
```cs
if (_lastPreview.TryGetTarget(out PreviewImage? preview))
{
    Show(preview);
}
else
{
    RegeneratePreview();
}
```

This makes sense because the preview is a convenience, not essential state.

> **Good practice**: Use a strong reference when you own or require the object. Use WeakReference<T> when the object is optional and should not be kept alive by this reference.
