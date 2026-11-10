**Command lines for *C, C++, and C# Programming for Beginners***

- [Chapter 1 - Introducing C, C++, and C#](#chapter-1---introducing-c-c-and-c)
  - [Installing the GCC and Clang compilers on Windows](#installing-the-gcc-and-clang-compilers-on-windows)
  - [Installing the .NET SDK for C# on Windows](#installing-the-net-sdk-for-c-on-windows)
    - [Linux and macOS instructions](#linux-and-macos-instructions)
  - [Installing VS Code extensions](#installing-vs-code-extensions)
  - [Using JetBrains IDEs](#using-jetbrains-ides)
  - [Trying out a simple C program](#trying-out-a-simple-c-program)
  - [Trying out a simple C++ program](#trying-out-a-simple-c-program-1)
    - [Trying out the C++ program on macOS or Linux](#trying-out-the-c-program-on-macos-or-linux)
    - [Compiling with clang++](#compiling-with-clang)
  - [Trying out a simple C# program](#trying-out-a-simple-c-program-2)
- [Chapter 3 - C Fundamentals](#chapter-3---c-fundamentals)
  - [Compiling and running a C program](#compiling-and-running-a-c-program)
  - [Understanding compiler switches](#understanding-compiler-switches)
    - [The -std=c17 switch](#the--stdc17-switch)
    - [The -o switch](#the--o-switch)
  - [Compiling more than one source file](#compiling-more-than-one-source-file)
  - [Compiling the project](#compiling-the-project)
- [Chapter 4 - C Memory Management](#chapter-4---c-memory-management)
  - [Detecting memory leaks using tools](#detecting-memory-leaks-using-tools)
- [Chapter 9 - C# Fundamentals](#chapter-9---c-fundamentals)
  - [Compiling and running a C# program](#compiling-and-running-a-c-program-1)
  - [How the project file controls compilation](#how-the-project-file-controls-compilation)
  - [Adding package references](#adding-package-references)
  - [Creating, building, and running an example project](#creating-building-and-running-an-example-project)
- [Chapter 13 - C# High-Performance Memory and Diagnostics](#chapter-13---c-high-performance-memory-and-diagnostics)
  - [Starting with lightweight monitoring](#starting-with-lightweight-monitoring)
  - [Capturing GC heap information with dotnet-gcdump](#capturing-gc-heap-information-with-dotnet-gcdump)
  - [Capturing and analyzing dumps with dotnet-dump](#capturing-and-analyzing-dumps-with-dotnet-dump)
- [Chapter 15 - Building the Puzzle Arcade Shell](#chapter-15---building-the-puzzle-arcade-shell)
  - [Creating the Blazor WebAssembly project](#creating-the-blazor-webassembly-project)

# Chapter 1 - Introducing C, C++, and C#

## Installing the GCC and Clang compilers on Windows

Update packages:
```shell
pacman -Syu
```

Install GCC:
```shell
pacman -S mingw-w64-ucrt-x86_64-gcc
```

Verify installation of GCC:
```shell
gcc --version
```

Install Clang:
```shell
pacman -S mingw-w64-clang-x86_64-clang
```

Verify installation of Clang:
```shell
clang --version
```

## Installing the .NET SDK for C# on Windows

Verify installation by opening a terminal and running:
```shell
dotnet --version
```

### Linux and macOS instructions

For Linux (Ubuntu/Debian), install GCC, Clang, and .NET:
```shell
sudo apt update
```

```shell
sudo apt install build-essential clang
```

For macOS, install Xcode Command Line Tools (includes Clang):
```shell
xcode-select --install
```

For macOS, install GCC (optional, via Homebrew):
```shell
brew install gcc
```

## Installing VS Code extensions

Install the C/C++ Extension Pack extension, enter the following in the command prompt:
```shell
code --install-extension ms-vscode.cpptools-extension-pack
```

## Using JetBrains IDEs

On macOS, install the **Xcode Command Line Tools** before using CLion or Rider:
```shell
xcode-select --install
```

On Linux, install GCC, G++, GDB, and CMake using your distribution’s package manager. On Ubuntu or Debian, enter the following:
```shell
sudo apt update
```

```shell
sudo apt install build-essential gdb cmake
```

## Trying out a simple C program

Change to the `Chapter01` directory. For example, on Windows:
```shell
cd c:/c-cpp-cs/Chapter01
```

Compile the C code file using the GCC compiler and output a file named `hello.exe`:
```shell
gcc -std=c17 hello.c -o hello
```

Run the executable that is now in the current directory:
```shell
./hello
```

## Trying out a simple C++ program

Change to the Chapter01 directory. For example, on Windows:
```shell
cd c:/c-cpp-cs/Chapter01
```

Compile the C++ code file using the Microsoft C++ compiler and output a file named `hello.exe`:
```shell
cl hello.cpp
```

Run the executable that is now in the current directory:
```shell
hello
```

### Trying out the C++ program on macOS or Linux

Change to the Chapter01 directory:
```shell
cd ~/c-cpp-cs/Chapter01
```

Compile the program:
```shell
g++ -std=c++20 -Wall -Wextra -pedantic hello.cpp
```

Run the program:
```shell
./hello
```

### Compiling with clang++

Change to the `Chapter01` directory:
```shell
cd ~/c-cpp-cs/Chapter01
```

Compile the program:
```shell
clang++ -std=c++20 -Wall -Wextra -pedantic hello.cpp -o hello
```

Run the program:
```shell
./hello
```

## Trying out a simple C# program

Change to the `Chapter01` directory. For example, on Windows:
```shell
cd c:/c-cpp-cs/Chapter01
```

Compile and run the C# code file using the `dotnet` CLI and its Roslyn C# compiler:
```shell
dotnet hello.cs
```

# Chapter 3 - C Fundamentals

## Compiling and running a C program

Start UCRT64, and then in your terminal:
```shell
gcc -std=c17 hello.c -o hello
```

On Linux, macOS, or Windows (MSYS2 terminal):
```shell
./hello
```

## Understanding compiler switches

When you first compiled a C program, you used a command like this:
```shell
gcc hello.c -o hello
```

In the real world, you are more likely to use a more complex command like this:
```shell
gcc -std=c17 -Wall -Wextra -pedantic hello.c -o hello
```

### The -std=c17 switch

Once you are comfortable with the examples in this book, you can experiment with newer standards
such as C23 by changing the compiler switch:
```shell
gcc -std=c23 -Wall -Wextra -pedantic main.c -o hello
```

### The -o switch

Using `-o` makes the command clearer because you choose the name yourself.
For example:
```shell
gcc main.c -o greeting
```

This creates a program named `greeting`.

## Compiling more than one source file

The same switches work when your project has multiple .c files. For example:
```shell
gcc -std=c17 -Wall -Wextra -pedantic main.c game.c input.c -o guessing_game
```

## Compiling the project

In the terminal, use:
```shell
gcc main.c game.c input.c -o guessing_game
```

To run the game’s executable:
```shell
./guessing_game
```

# Chapter 4 - C Memory Management

## Detecting memory leaks using tools

Typical usage:
```shell
valgrind ./program
```

# Chapter 9 - C# Fundamentals

## Compiling and running a C# program

You can create and run a console project using the .NET CLI:
```shell
dotnet new console
```

```shell
dotnet run
```

## How the project file controls compilation

When you run this command:
```shell
dotnet build
```
the .NET SDK reads the `.csproj` file and uses it to decide how to compile the project.

## Adding package references

If you add a package using the .NET CLI:
```shell
dotnet add package Newtonsoft.Json
```
the project file is updated to include a `PackageReference` element in an `ItemGroup`:
```xml
<ItemGroup>
  <PackageReference Include="Newtonsoft.Json" Version="13.0.4" />
</ItemGroup>
```

## Creating, building, and running an example project

Create a new folder and a new console project:
```shell
mkdir ProjectFileExample
```

```shell
cd ProjectFileExample
```

```shell
dotnet new console
```

Build the project:
```shell
dotnet build
```

Now run the project:
```shell
dotnet run --no-build
```

The `--no-build` option tells the .NET CLI to run the already compiled version of the project. If you omit
this option, `dotnet run` checks whether the project needs to be built first, and builds it first if needed.

# Chapter 13 - C# High-Performance Memory and Diagnostics

## Starting with lightweight monitoring

List running .NET processes:
```shell
dotnet-counters ps
```

Then monitor a process:
```shell
dotnet-counters monitor --process-id 12345 System.Runtime
```

Replace `12345` with the process ID of your application.

## Capturing GC heap information with dotnet-gcdump

Install the tool if needed:
```shell
dotnet tool install --global dotnet-gcdump
```

List .NET processes:
```shell
dotnet-gcdump ps
```

Then collect a GC dump:
```shell
dotnet-gcdump collect --process-id 12345 --output app.gcdump
```

## Capturing and analyzing dumps with dotnet-dump

Install the tool if needed:
```shell
dotnet tool install --global dotnet-dump
```

List processes:
```shell
dotnet-dump ps
```

Collect a dump:
```shell
dotnet-dump collect --process-id 12345 --output app.dmp
```

Analyze it:
```shell
dotnet-dump analyze app.dmp
```

Inside the analysis session, you can use commands to inspect managed heap information. For example:
```shell
dumpheap -stat
```

# Chapter 15 - Building the Puzzle Arcade Shell

## Creating the Blazor WebAssembly project

Create the project in Visual Studio from a command prompt or terminal starting in the `c-cpp-cs` folder:
```shell
mkdir Chapter15
```

```shell
cd Chapter15
```

```shell
dotnet new slnx -n Chapter15
```

```shell
dotnet new blazorwasm -n PuzzleArcade
```

```shell
dotnet sln add PuzzleArcade
```

Start the PuzzleArcade project from a command prompt or terminal:
```shell
cd PuzzleArcade
```

```shell
dotnet run
```

