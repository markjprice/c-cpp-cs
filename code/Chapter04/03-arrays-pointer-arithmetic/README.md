# 03-arrays-pointer-arithmetic

Demonstrates that arrays are contiguous blocks of memory and that `numbers[i]` is equivalent to `*(numbers + i)`.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o arrays_pointer_arithmetic
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o arrays_pointer_arithmetic
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c /Fe:arrays_pointer_arithmetic.exe
```

## Run

Linux, macOS, or MSYS2:

```bash
./arrays_pointer_arithmetic
```

Windows PowerShell:

```powershell
.\arrays_pointer_arithmetic.exe
```
