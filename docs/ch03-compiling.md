# Creating, compiling, and running a C project

Before you write larger examples, it is worth slowing down and making sure you know how to create a real C project folder, open it in VS Code, compile it with a command-line compiler, and run it.

In Chapter 1, you installed the tools needed to compile C programs. In this chapter, we will use those tools to build small but complete C projects.

A C project does not need to be complicated. At its simplest, it is just a folder containing one or more `.c` source files. As your programs grow, you will also add `.h` header files.

## Creating a project folder

Create a folder for this chapter’s examples. For example:

```text
c-cpp-cs
└── code
    └── Chapter03
```

Inside that folder, create a project folder named:

```text
01-hello-world
```

Your folder structure should look like this:

```text
c-cpp-cs
└── code
    └── Chapter03
        └── 01-hello-world
```

## Opening the folder in VS Code

To open the project in VS Code:

1. Start VS Code.
2. Select **File | Open Folder**.
3. Open the `01-hello-world` folder.
4. Create a new file named `main.c`.

Add the following code to `main.c`:

```c
#include <stdio.h>

int main(void)
{
  printf("Hello, World!\n");
  return 0;
}
```

Save the file.

## Opening the integrated terminal

To compile the program, you need a terminal.

In VS Code, navigate to **Terminal** | **New Terminal**.

The terminal opens at the bottom of the VS Code window.

Make sure the terminal is in the same folder as `main.c`. You can check by running:

```bash
ls
```

On Windows Command Prompt, use:

```cmd
dir
```

You should see:

```text
main.c
```

## Compiling with GCC

If you are using GCC, compile the program like this:

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o hello
```

This command means:

| Part        | Meaning                                  |
| ----------- | ---------------------------------------- |
| `gcc`       | Runs the GCC compiler                    |
| `-std=c17`  | Compiles using the C17 language standard |
| `-Wall`     | Enables many common warnings             |
| `-Wextra`   | Enables extra warnings                   |
| `-pedantic` | Warns about non-standard C code          |
| `main.c`    | The source file to compile               |
| `-o hello`  | Names the output program `hello`         |

If compilation succeeds, GCC creates an executable program.

On Linux, macOS, or MSYS2 on Windows, run it like this:

```bash
./hello
```

On Windows PowerShell or Command Prompt, run it like this:

```powershell
.\hello.exe
```

You should see:

```text
Hello, World!
```

## Compiling with Clang

If you are using Clang, the command is almost identical:

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o hello
```

Run it in the same way:

```bash
./hello
```

Or on Windows:

```powershell
.\hello.exe
```

Clang and GCC support many of the same command-line options, which makes it easy to switch between them for beginner examples.

## Compiling with MSVC

If you are using Microsoft’s C compiler, open a **Developer Command Prompt for Visual Studio**.

Move into the folder that contains `main.c`, then run:

```cmd
cl /std:c17 /W4 main.c /Fe:hello.exe
```

This command means:

| Part            | Meaning                                  |
| --------------- | ---------------------------------------- |
| `cl`            | Runs the Microsoft C/C++ compiler        |
| `/std:c17`      | Compiles using the C17 language standard |
| `/W4`           | Enables a high warning level             |
| `main.c`        | The source file to compile               |
| `/Fe:hello.exe` | Names the output program `hello.exe`     |

Run the program:

```cmd
hello.exe
```

You should see:

```text
Hello, World!
```

## Using VS Code build tasks

You can also ask VS Code to run the build command for you.

Inside your project folder, create a folder named `.vscode`.

Inside `.vscode`, create a file named `tasks.json`.

Add the following content:

```json
{
  "version": "2.0.0",
  "tasks": [
    {
      "label": "Build with GCC",
      "type": "shell",
      "command": "gcc -std=c17 -Wall -Wextra -pedantic main.c -o hello",
      "group": {
        "kind": "build",
        "isDefault": true
      },
      "problemMatcher": ["$gcc"]
    },
    {
      "label": "Run",
      "type": "shell",
      "command": "./hello",
      "dependsOn": "Build with GCC",
      "problemMatcher": []
    }
  ]
}
```

To build the project:

1. Select **Terminal | Run Build Task**.
2. Choose **Build with GCC** if prompted.

To run the project:

1. Select **Terminal | Run Task**.
2. Choose **Run**.

On Windows PowerShell or Command Prompt, you might need to change the run command from:

```json
"./hello"
```

to:

```json
".\\hello.exe"
```

If you are using MSYS2 UCRT64 on Windows, `./hello` should usually work.

## Compiling projects with multiple source files

A larger C program is often split across multiple `.c` files. For example, later in this chapter, the number guessing game uses these files:

```text
main.c
game.c
game.h
input.c
input.h
```

The `.h` files contain declarations. The `.c` files contain implementation code.

When compiling, you usually compile the `.c` files together:

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c game.c input.c -o guessing_game
```

Then run the program:

```bash
./guessing_game
```

With Clang, use:

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c game.c input.c -o guessing_game
```

With MSVC, use:

```cmd
cl /std:c17 /W4 main.c game.c input.c /Fe:guessing_game.exe
```

Notice that you do not compile the `.h` files directly. Header files are included by source files using `#include`.

## Downloading the complete code examples

All the code examples for this chapter are available as complete projects in the book’s GitHub repository.

You can find them here:

```text
https://github.com/markjprice/c-cpp-cs/tree/main/code/ch03-c-fundamentals
```

Each project folder contains:

| File or folder        | Purpose                                    |
| --------------------- | ------------------------------------------ |
| `main.c`              | The main source file for simple examples   |
| Additional `.c` files | Extra source files for multi-file projects |
| `.h` files            | Header files containing declarations       |
| `README.md`           | Compile and run instructions               |
| `.vscode/tasks.json`  | Optional VS Code build task                |

This means you can either type the code yourself or download the complete working version and compare it with your own.

Typing the code yourself is still valuable because it builds muscle memory. Downloading the code is useful when you want to check your work, fix mistakes, or experiment without retyping everything.
