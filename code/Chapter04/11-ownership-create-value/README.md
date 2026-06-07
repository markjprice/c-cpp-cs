# 11-ownership-create-value

Demonstrates a simple ownership rule: one function allocates memory, then another function consumes that ownership and frees it.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o ownership_create_value
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o ownership_create_value
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c /Fe:ownership_create_value.exe
```

## Run

Linux, macOS, or MSYS2:

```bash
./ownership_create_value
```

Windows PowerShell:

```powershell
.\ownership_create_value.exe
```
