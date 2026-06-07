# Chapter 3: C Fundamentals code examples

This folder contains complete, downloadable C projects for Chapter 3, **C Fundamentals**.
Each numbered folder is a separate project with its own `README.md`, source files, and optional VS Code build task.

## Before you begin

Install at least one C compiler, as described in Chapter 1:

- **GCC**, for example through MSYS2 UCRT64 on Windows, or through your package manager on Linux and macOS.
- **Clang**, available on macOS through Xcode Command Line Tools and on Windows/Linux through platform installers or package managers.
- **MSVC**, installed with Visual Studio or the Build Tools for Visual Studio on Windows.

Open a terminal and check one of the following commands works:

```bash
gcc --version
clang --version
cl
```

On Windows, use the **MSYS2 UCRT64** terminal for GCC, or the **Developer Command Prompt for Visual Studio** for MSVC.

## Building with GCC

From inside any project folder that contains `main.c`, run:

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o app
./app
```

On Windows PowerShell or Command Prompt, run the program as:

```powershell
.\app.exe
```

For projects split across multiple `.c` files, compile all source files together, for example:

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c game.c input.c -o guessing_game
./guessing_game
```

## Building with Clang

Use the same pattern as GCC:

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o app
./app
```

For multi-file projects:

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c game.c input.c -o guessing_game
./guessing_game
```

## Building with MSVC

Open a **Developer Command Prompt for Visual Studio**, move into the project folder, and run:

```cmd
cl /std:c17 /W4 main.c
main.exe
```

For multi-file projects:

```cmd
cl /std:c17 /W4 main.c game.c input.c /Fe:guessing_game.exe
guessing_game.exe
```

## Building from VS Code

1. Start VS Code.
2. Select **File | Open Folder**.
3. Open one of the numbered project folders, such as `01-hello-world`.
4. Open `main.c`.
5. Open the integrated terminal using **Terminal | New Terminal**.
6. Compile and run using the commands in that project’s `README.md`.
7. For projects that include `.vscode/tasks.json`, use **Terminal | Run Build Task**.

The VS Code tasks assume GCC is available on the terminal `PATH`. On Windows, this usually means opening VS Code from the MSYS2 UCRT64 environment or ensuring the MSYS2 UCRT64 `bin` folder is on your `PATH`.

## Projects

| Folder | Purpose |
|---|---|
| `01-hello-world` | Smallest complete C program. |
| `02-data-types-and-variables` | Primitive types, initialization, strings, structs, `typedef`, constants, and modifiers. |
| `03-operators-and-expressions` | Arithmetic, relational, logical, bitwise, assignment, and ternary operators. |
| `04-pointers-and-addresses` | The `&` address-of operator and a first pointer example. |
| `05-input-output-formatting` | `printf()`, `scanf()`, format specifiers, and escape sequences. |
| `06-control-flow` | `if`, `switch`, `for`, `while`, `do-while`, `break`, `continue`, and `goto`. |
| `07-functions-times-table` | Declaring and calling functions, parameters, return values, and reusable logic. |
| `08-functions-multiple-files` | Function prototypes, header files, and source files. |
| `09-number-guessing-game` | A complete multi-file chapter project. |

## Suggested warning flags

Use warnings from the start:

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o app
```

The flags mean:

- `-std=c17`: compile as C17.
- `-Wall`: enable many common warnings.
- `-Wextra`: enable more warnings.
- `-pedantic`: warn when code relies on non-standard extensions.

Treat warnings as problems to investigate, not as background noise.
