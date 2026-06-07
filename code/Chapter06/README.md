# Chapter 6: C++ Fundamentals code projects

These projects accompany Chapter 6, **C++ Fundamentals**. Each folder is a complete small project that can be opened in VS Code or compiled from the command line.

The examples use C++20 as a practical modern baseline:

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o app
./app
```

Use `clang++` instead of `g++` if you prefer Clang. On Windows with MSVC, open a Developer Command Prompt for Visual Studio and use commands like:

```cmd
cl /std:c++20 /W4 /EHsc main.cpp /Fe:app.exe
app.exe
```

## Projects

| Folder | Purpose |
|---|---|
| `01-hello-modern-cpp` | First modern C++ program with `std::cout`. |
| `02-c-vs-cpp-greeting` | Rewrites a small C-style greeting as modern C++ using `std::string`. |
| `03-stream-input-output` | Demonstrates `std::cout`, `std::cin`, `std::getline`, `std::ws`, and `\n`. |
| `04-namespaces` | Shows how namespaces solve naming conflicts. |
| `05-string-basics` | Demonstrates assignment, copying, concatenation, length, and substring operations. |
| `06-vector-basics` | Demonstrates `std::vector`, `push_back`, `size`, `at`, `front`, `back`, and iteration. |
| `07-references-and-const` | Compares pass by value, reference, and const reference. |
| `08-returning-references` | Shows safe and unsafe reference-returning ideas without deliberately invoking undefined behavior. |
| `09-range-for-and-auto` | Demonstrates range-based loops, `auto`, references in loops, and const references. |
| `10-function-overloading` | Demonstrates overloaded functions. |
| `11-default-arguments-inline` | Demonstrates default arguments and an inline function split across a header and source file. |
| `12-casting-and-nullptr` | Demonstrates `static_cast` and `nullptr` overload resolution. |
| `13-cpp-danger-zones` | Demonstrates safer alternatives to common C++ danger zones. |
| `14-standard-library-types` | Demonstrates selected standard library types from the chapter tables. |
