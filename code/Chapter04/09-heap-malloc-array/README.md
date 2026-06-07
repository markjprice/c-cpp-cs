# 09-heap-malloc-array

Allocates an array on the heap using `malloc()`, fills it, prints it, and frees it.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o heap_malloc_array
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o heap_malloc_array
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c /Fe:heap_malloc_array.exe
```

## Run

Linux, macOS, or MSYS2:

```bash
./heap_malloc_array
```

Windows PowerShell:

```powershell
.\heap_malloc_array.exe
```
