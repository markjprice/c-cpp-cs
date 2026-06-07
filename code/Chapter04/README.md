# Chapter 4: C Memory Management

This folder contains complete C projects for Chapter 4, **C Memory Management**.

Each project is intentionally small. The goal is to make the memory behavior visible and easy to experiment with.

## Projects

| Project | Purpose |
|---|---|
| `01-pointers-basic` | Demonstrates the difference between a normal variable, its address, a pointer, and dereferencing a pointer. |
| `02-null-and-sizeof` | Shows how to initialize a pointer to `NULL`, check the result of `malloc()`, and use `sizeof` with types, variables, pointers, and dereferenced pointers. |
| `03-arrays-pointer-arithmetic` | Demonstrates that arrays are contiguous blocks of memory and that `numbers[i]` is equivalent to `*(numbers + i)`. |
| `04-struct-arrow-operator` | Shows when to use the dot operator (`.`) and when to use the arrow operator (`->`) with structs and pointers to structs. |
| `05-memory-layout` | Shows examples of values that live in different memory regions: code, data, stack, and heap. Exact addresses vary by platform. |
| `06-global-static-local` | Compares global variables, static local variables, and ordinary local variables. |
| `07-stack-frames` | Shows how nested function calls create separate stack frames. The exact addresses and stack growth direction are implementation details. |
| `08-stack-overflow-demo` | Demonstrates safe recursion and includes an optional unsafe mode that deliberately causes stack overflow. |
| `09-heap-malloc-array` | Allocates an array on the heap using `malloc()`, fills it, prints it, and frees it. |
| `10-calloc-and-realloc` | Shows how `calloc()` creates zero-initialized memory and how `realloc()` resizes a heap allocation safely using a temporary pointer. |
| `11-ownership-create-value` | Demonstrates a simple ownership rule: one function allocates memory, then another function consumes that ownership and frees it. |
| `12-memory-errors-educational` | Contains one safe example and several optional unsafe modes for demonstrating leaks, buffer overflow, and use-after-free with memory-checking tools. |
| `13-debugging-and-assertions` | Shows defensive memory-management habits: checking allocations, printing pointer values, using assertions, freeing memory, and setting pointers to `NULL`. |

## Recommended folder location

Use this structure in the book repository:

```text
code/
  ch04-c-memory/
    01-pointers-basic/
    02-null-and-sizeof/
    03-arrays-pointer-arithmetic/
    04-struct-arrow-operator/
    05-memory-layout/
    06-global-static-local/
    07-stack-frames/
    08-stack-overflow-demo/
    09-heap-malloc-array/
    10-calloc-and-realloc/
    11-ownership-create-value/
    12-memory-errors-educational/
    13-debugging-and-assertions/
```

## Build pattern for single-file projects

Most projects contain a single `main.c` file.

With GCC:

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o app
```

With Clang:

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o app
```

With MSVC from a Developer Command Prompt for Visual Studio:

```cmd
cl /std:c17 /W4 main.c /Fe:app.exe
```

## Run pattern

Linux, macOS, or MSYS2 on Windows:

```bash
./app
```

Windows PowerShell:

```powershell
.\app.exe
```

## Using VS Code

1. Open one of the project folders in VS Code.
2. Open `main.c`.
3. Open the integrated terminal with **Terminal | New Terminal**.
4. Run the build command from that project's `README.md`.
5. Run the executable.

Each project also includes a `.vscode/tasks.json` file for **Terminal | Run Build Task** and **Terminal | Run Task**.

## Memory-checking tools

On Linux, Valgrind is useful for detecting leaks and invalid memory access:

```bash
valgrind --leak-check=full ./app
```

On Windows, use Visual Studio Diagnostic Tools or Dr. Memory.

The project `12-memory-errors-educational` includes optional unsafe modes that are useful when experimenting with memory checkers.
