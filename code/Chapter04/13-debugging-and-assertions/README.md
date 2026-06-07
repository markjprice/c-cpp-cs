# 13-debugging-and-assertions

Shows defensive memory-management habits: checking allocations, printing pointer values, using assertions, freeing memory, and setting pointers to `NULL`.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o debugging_and_assertions
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o debugging_and_assertions
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c /Fe:debugging_and_assertions.exe
```

## Run

Linux, macOS, or MSYS2:

```bash
./debugging_and_assertions
```

Windows PowerShell:

```powershell
.\debugging_and_assertions.exe
```
