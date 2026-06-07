# Chapter 5: C Limitations

These projects accompany Chapter 5, **C Limitations**.

The chapter is mostly conceptual, but it contains many small examples that are easier to understand when you can compile, run, and modify them. Each folder is a complete C project with its own `README.md`.

## Projects

| Folder | Topic |
|---|---|
| `01-struct-and-functions` | Data in a `struct`, behavior in separate functions |
| `02-no-encapsulation` | Direct field access and invalid object state |
| `03-duplicated-admin-user` | Repetition when a similar type appears |
| `04-naming-conflicts` | Prefix naming as a workaround for C's global function namespace |
| `05-global-state` | Why global variables become risky |
| `06-ownership-rules` | Memory ownership must be documented and followed manually |
| `07-no-function-overloading` | Type-specific function names instead of overloads |
| `08-dynamic-list-manual-container` | Building a reusable container manually |
| `09-c-style-module-boundary` | A more disciplined C module with an opaque struct |
| `10-c-to-cpp-preview` | A side-by-side C and C++ preview showing why C++ is next |

## Compiler commands

Most projects can be compiled with GCC like this:

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o app
./app
```

For projects with multiple source files, compile all `.c` files:

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c user.c -o app
./app
```

With Clang:

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c user.c -o app
./app
```

With MSVC from a Developer Command Prompt:

```cmd
cl /std:c17 /W4 main.c user.c /Fe:app.exe
app.exe
```

Project `10-c-to-cpp-preview` includes both a C and a C++ version. Compile the C++ version with:

```bash
g++ -std=c++20 -Wall -Wextra -pedantic user_cpp_preview.cpp -o user_cpp_preview
./user_cpp_preview
```

or with MSVC:

```cmd
cl /std:c++20 /EHsc /W4 user_cpp_preview.cpp /Fe:user_cpp_preview.exe
user_cpp_preview.exe
```

## VS Code

Most folders include `.vscode/tasks.json` with a default GCC build task.

In VS Code:

1. Open the project folder.
2. Select **Terminal | Run Build Task**.
3. Run the executable from the integrated terminal.

On Windows PowerShell, use `.\app.exe`. On Linux, macOS, or MSYS2, use `./app`.
