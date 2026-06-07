# Chapter 8: C++ Memory Management

This folder contains complete C++ projects for Chapter 8, **C++ Memory Management**.

The examples focus on ownership, lifetime, RAII, smart pointers, copy/move behavior, and memory debugging tools.

## Recommended compiler command

For most examples, use:

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o app
./app
```

For multi-file projects, include all `.cpp` files:

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp File.cpp -o app
./app
```

## AddressSanitizer

Some projects include optional unsafe modes for learning. To use AddressSanitizer with GCC or Clang:

```bash
g++ -std=c++20 -Wall -Wextra -pedantic -g -fsanitize=address main.cpp -o app
./app
```

AddressSanitizer is especially useful for detecting out-of-bounds access, use-after-free, and double deletion.

## Valgrind

On Linux, you can run examples under Valgrind:

```bash
valgrind --leak-check=full ./app
```

Valgrind is slower than normal execution, but it is useful for memory leak detection and invalid memory access diagnostics.

## Projects

| Folder | Concept |
|---|---|
| `01-stack-heap-lifetime` | Stack vs heap and object lifetime |
| `02-manual-new-delete` | Legacy manual allocation with `new` and `delete` |
| `03-manual-errors-educational` | Optional unsafe examples: leak, dangling pointer, double delete, mismatch |
| `04-raii-file-wrapper` | RAII file wrapper that closes automatically |
| `05-raii-lock-guard` | RAII lock guard mental model |
| `06-unique-ptr-ownership` | Exclusive ownership and ownership transfer |
| `07-shared-weak-ptr` | Shared ownership, reference counts, and `weak_ptr` |
| `08-smart-pointers-raii` | Smart pointers as RAII objects |
| `09-shallow-copy-danger` | Why default shallow copying is dangerous for resource owners |
| `10-rule-of-three-buffer` | Correct resource copying with the Rule of Three |
| `11-rule-of-five-move` | Move constructor and move assignment |
| `12-standard-containers-memory` | Prefer `std::vector`, `std::string`, and `std::array` |
| `13-asan-valgrind-demo` | Memory tool demonstration with optional unsafe modes |
| `14-good-practices` | Modern memory management practices brought together |
