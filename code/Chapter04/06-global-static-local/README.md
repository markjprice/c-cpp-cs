# 06-global-static-local

Compares global variables, static local variables, and ordinary local variables.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o global_static_local
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o global_static_local
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c /Fe:global_static_local.exe
```

## Run

Linux, macOS, or MSYS2:

```bash
./global_static_local
```

Windows PowerShell:

```powershell
.\global_static_local.exe
```
