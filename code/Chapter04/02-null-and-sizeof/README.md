# 02-null-and-sizeof

Shows how to initialize a pointer to `NULL`, check the result of `malloc()`, and use `sizeof` with types, variables, pointers, and dereferenced pointers.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o null_and_sizeof
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o null_and_sizeof
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c /Fe:null_and_sizeof.exe
```

## Run

Linux, macOS, or MSYS2:

```bash
./null_and_sizeof
```

Windows PowerShell:

```powershell
.\null_and_sizeof.exe
```
