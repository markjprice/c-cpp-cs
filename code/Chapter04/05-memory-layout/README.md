# 05-memory-layout

Shows examples of values that live in different memory regions: code, data, stack, and heap. Exact addresses vary by platform.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o memory_layout
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o memory_layout
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c /Fe:memory_layout.exe
```

## Run

Linux, macOS, or MSYS2:

```bash
./memory_layout
```

Windows PowerShell:

```powershell
.\memory_layout.exe
```
