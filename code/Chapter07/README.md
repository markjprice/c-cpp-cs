# Chapter 7: C++ Object-Oriented Programming code examples

This folder contains complete, runnable C++ projects for Chapter 7, **C++ Object-Oriented Programming**.

Each project is deliberately small and focused. Most projects use a single `main.cpp` file. A few use header and source files to show how real C++ projects separate class declarations from implementation.

## Requirements

You need a C++ compiler that supports C++20. The examples should work with:

- `g++` from GCC
- `clang++` from LLVM/Clang
- Microsoft Visual C++ (`cl`) from Visual Studio

## Recommended command

For single-file projects:

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o app
./app
```

For multi-file projects, compile all `.cpp` files together. For example:

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp User.cpp -o user_project
./user_project
```

## Projects

| Folder | Concept |
|---|---|
| `01-simple-class-object` | Defining a class and creating objects |
| `02-interface-implementation-files` | Splitting a class into `.hpp` and `.cpp` files |
| `03-encapsulation-bank-account` | Encapsulation and data hiding |
| `04-constructors-destructors-raii` | Constructors, destructors, and RAII |
| `05-operator-overloading-vector` | Operator overloading with a simple vector type |
| `06-static-members` | Static data members and static member functions |
| `07-composition-vs-inheritance` | Comparing has-a and is-a relationships |
| `08-inheritance-class-hierarchy` | Base and derived classes |
| `09-runtime-polymorphism` | Virtual functions and dynamic dispatch |
| `10-abstract-classes-interfaces` | Pure virtual functions and interface-like classes |
| `11-multiple-inheritance-diamond` | Multiple inheritance and the diamond problem |
| `12-friend-functions-classes` | Friend functions and friend classes |
| `13-this-pointer-method-chaining` | The `this` pointer and method chaining |
| `14-simple-banking-system` | End-of-chapter project combining OOP ideas |

## Notes for Windows users

If you are using MSYS2 UCRT64 or Git Bash, use commands like `./app`.

If you are using PowerShell or Command Prompt, run executables like this:

```powershell
.\app.exe
```
