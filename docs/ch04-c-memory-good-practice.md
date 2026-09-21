# Good practices for efficient memory management

- [Good practices for efficient memory management](#good-practices-for-efficient-memory-management)
- [Always initialize pointers](#always-initialize-pointers)
- [Free memory as soon as it's no longer needed](#free-memory-as-soon-as-its-no-longer-needed)
- [Avoid memory fragmentation](#avoid-memory-fragmentation)
- [Use smart debugging techniques](#use-smart-debugging-techniques)
  - [Check every allocation](#check-every-allocation)
  - [Use diagnostic tools](#use-diagnostic-tools)
  - [Add logging for pointer values](#add-logging-for-pointer-values)
  - [Use assertions](#use-assertions)
  - [Isolate and simplify problems](#isolate-and-simplify-problems)
  - [Be consistent with patterns](#be-consistent-with-patterns)
- [Key takeaway](#key-takeaway)


Writing correct C code is one thing. Writing efficient and reliable C code is another. Memory management is where the difference shows most clearly. Poor habits lead to subtle bugs, crashes, and performance issues that are difficult to diagnose. Good habits make your programs predictable, stable, and easier to maintain.

This section focuses on practical techniques that experienced C programmers rely on to avoid problems and improve efficiency.

# Always initialize pointers

As you learned earlier, an uninitialized pointer may contain an invalid address. Initialize pointers when you declare them, using `NULL` when they do not yet refer to valid memory:
```c
int* p = NULL;
```

Assign a valid address before dereferencing the pointer.

> **Prompt**: What is undefined behavior in C with examples related to pointers?

# Free memory as soon as it's no longer needed

One of the most common mistakes in C is holding onto memory longer than necessary. This increases memory usage and can lead to leaks in larger systems.

Bad pattern:
```c
int* p = malloc(sizeof(int));
// use p
// ... many lines later
free(p);
```

Better pattern:
```c
int* p = malloc(sizeof(int));
// use p
free(p);
p = NULL;
```

Why this matters:
- Reduces peak memory usage
- Minimizes the risk of forgetting to free memory
- Makes ownership and lifetime clearer

A useful rule: Allocate late, free early. That is, only allocate when you actually need memory, and release it immediately after you are done.

# Avoid memory fragmentation

Memory fragmentation occurs when free memory is broken into small, scattered blocks instead of one large contiguous block. Over time, this can prevent large allocations even when enough total memory exists.

Fragmentation typically happens when:
- Many allocations and deallocations of different sizes occur
- Memory is freed in unpredictable patterns

Example scenario:
1.	Allocate 100 bytes
2.	Allocate 200 bytes
3.	Free the first block
4.	Allocate 150 bytes

Now the memory is split into awkward pieces.

Strategies to reduce fragmentation:
- Use consistent allocation sizes where possible. Reusing similarly sized blocks helps keep memory organized.
- Reuse allocated memory instead of repeatedly allocating and freeing:

```c
// allocate once
int* buffer = malloc(100 * sizeof(int));

// reuse buffer multiple times

free(buffer);
```

- Avoid excessive allocation in tight loops:
```c
for (int i = 0; i < 1000; i++) {
    int* p = malloc(sizeof(int));
    free(p);
}
```

Instead, allocate once outside the loop if possible.

- Group related allocations together. This improves locality and reduces fragmentation over time.

While fragmentation is more noticeable in long-running systems, it is still worth understanding early.

# Use smart debugging techniques

Memory bugs are rarely obvious. They often appear far away from their actual cause. Developing a systematic debugging approach will save you a lot of time.

Let’s look at some smart debugging techniques:

## Check every allocation

To explicitly check that the variable is `NULL` and then handle the error:
```c
int* p = malloc(sizeof(int));
if (p == NULL) {
    // handle error
}
```

Even if failures are rare, handling them properly makes your code more robust.

## Use diagnostic tools

Tools like Valgrind can detect:
- Memory leaks
- Invalid memory access
- Use of uninitialized values

Run your program under a memory checker regularly, not just when something breaks.

## Add logging for pointer values

Tracking pointer values helps you see when memory changes unexpectedly:
```c
printf("Pointer address: %p\n", (void*)p);
```

## Use assertions
Assertions catch invalid assumptions early during development:
```c
#include <assert.h>

assert(p != NULL);
```

## Isolate and simplify problems

If a program crashes:
- Reduce it to the smallest reproducible example
- Remove unrelated code
- Focus on one pointer or allocation at a time

This mirrors how experienced developers debug complex systems.

## Be consistent with patterns

Use the same allocation and cleanup patterns throughout your code. Inconsistent styles are harder to debug and easier to break.

# Key takeaway
Efficient memory management is not just about avoiding crashes. It is about writing code that behaves predictably under pressure, scales well, and can be understood months later.

The habits in this section may seem small, but they compound. Most serious C bugs come from ignoring these basics, not from advanced concepts.
