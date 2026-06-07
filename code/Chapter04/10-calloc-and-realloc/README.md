# 10-calloc-and-realloc

Shows how `calloc()` creates zero-initialized memory and how `realloc()` resizes a heap allocation safely using a temporary pointer.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o calloc_and_realloc
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o calloc_and_realloc
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c /Fe:calloc_and_realloc.exe
```

## Run

Linux, macOS, or MSYS2:

```bash
./calloc_and_realloc
```

Windows PowerShell:

```powershell
.\calloc_and_realloc.exe
```
