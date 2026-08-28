# Good practices for efficient memory management

- [Good practices for efficient memory management](#good-practices-for-efficient-memory-management)
- [Prefer stack allocation whenever possible](#prefer-stack-allocation-whenever-possible)
- [Minimize heap allocations](#minimize-heap-allocations)
- [Prefer standard library containers and types](#prefer-standard-library-containers-and-types)
- [Prefer smart pointers for dynamic allocation](#prefer-smart-pointers-for-dynamic-allocation)
- [Keep ownership simple and explicit](#keep-ownership-simple-and-explicit)
- [Design classes that manage their own resources](#design-classes-that-manage-their-own-resources)
- [Avoid premature optimization](#avoid-premature-optimization)
- [When advanced techniques make sense](#when-advanced-techniques-make-sense)
- [The big picture](#the-big-picture)


In this online-only section, you will look at good practices for efficient memory management, focusing on how to write modern C++ code that is safer, simpler, and less prone to errors from the start.

By this point, you have seen how memory works in C++, why manual management is error-prone, how RAII improves safety, and how tools can help you debug issues. The next step is to bring these ideas together into practical habits you can apply when writing real code.

Good memory management is less about memorizing rules and more about consistently making decisions that reduce risk, improve clarity, and avoid unnecessary complexity.

# Prefer stack allocation whenever possible

The simplest and safest form of memory management is automatic storage on the stack:
```cpp
int x = 10;
std::string name = "Alice";
```
These objects:
- Are created automatically
- Are destroyed automatically
- Cannot leak memory

Whenever possible, prefer stack allocation over heap allocation. It is faster, simpler, and avoids entire classes of bugs.

> **Good practice**: If an object does not need to outlive its scope, it should not be on the heap.

# Minimize heap allocations

Heap allocation is more expensive than stack allocation. It involves:
- Dynamic memory management
- Potential fragmentation
- Slower allocation and deallocation

Excessive heap usage can hurt performance, especially in performance-critical applications such as games or real-time systems.

Ways to reduce heap usage:
- Reuse objects where possible
- Prefer stack-based objects
- Use containers that manage memory efficiently

This is not about avoiding the heap entirely. It is about using it deliberately.

> **Prompt**: What is memory fragmentation and how does it affect performance?

# Prefer standard library containers and types

Modern C++ provides standard types that already manage memory correctly:
- `std::vector` for dynamic arrays
- `std::string` for text
- `std::array` for fixed-size arrays

For example:
```cpp
std::vector<int> numbers = {1, 2, 3};
```

You do not need to worry about allocating or freeing memory. The container handles it internally using RAII.

This has several benefits:
- Fewer bugs
- Clearer code
- Better performance optimizations built into the library

Reimplementing these structures manually is almost always unnecessary and error-prone.

# Prefer smart pointers for dynamic allocation

When you do need dynamic allocation, use smart pointers instead of new and delete.

As shown earlier in the chapter, smart pointers:
- Automatically release memory
- Encode ownership rules
- Reduce the chance of leaks and invalid access

A simple guideline:
- Use `std::unique_ptr` by default
- Use `std::shared_ptr` only when ownership must be shared
- Use `std::weak_ptr` to avoid cycles

This keeps ownership clear and prevents many common mistakes.

> **Prompt**: When should I use `unique_ptr` vs `shared_ptr` vs `weak_ptr`? Please include a drawing of an ownership decision tree diagram (unique vs shared vs weak) so that I can understand visually.

# Keep ownership simple and explicit

Complex ownership models lead to bugs. If multiple parts of a program are responsible for the same resource, it becomes difficult to reason about lifetime.

Prefer:
- Clear, single ownership
- Well-defined transfer of ownership
- Minimal sharing unless necessary

For example, passing ownership explicitly:

```cpp
std::unique_ptr<int> create()
{
    return std::make_unique<int>(42);
}
```

The caller clearly becomes the owner. Simple ownership models are easier to understand, maintain, and debug.

# Design classes that manage their own resources

If a class acquires a resource, it should also release it. This is the essence of RAII.

Instead of exposing raw resources:
```cpp
FILE* file;
```
wrap them in a class that manages lifetime automatically.

This ensures:
- Consistent cleanup
- Fewer leaks
- Safer code in the presence of errors

You should aim for designs where resource management is built into the structure of your classes, not scattered throughout your functions.

# Avoid premature optimization

Memory optimization is important, but it should not come at the cost of clarity and correctness.

For example:
- Replacing `std::vector` with manual allocation rarely improves performance
- Introducing complex memory pools too early increases risk

Start with clear, safe code using standard tools. Optimize only when you have identified a real performance bottleneck.

# When advanced techniques make sense

There are cases where more advanced memory management techniques are appropriate:
- Custom allocators
- Memory pools
- Low-level optimizations

> **Prompt**: What are custom allocators in C++ and when are they used?

These are typically used in:
- Game engines
- Embedded systems
- High-performance applications

> **Prompt**: How do game engines manage memory differently from normal apps?
However, they require a strong understanding of memory behavior and should be used carefully. For most applications, the standard library and RAII-based techniques are sufficient.

# The big picture

All of these practices reinforce a single idea: Memory management should be predictable, explicit, and automated where possible.

Modern C++ gives you the tools to achieve this. The challenge is using them consistently.

If you follow these practices:
- Your code becomes safer
- Your design becomes clearer
- Your debugging becomes easier
