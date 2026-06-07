# 08-stack-overflow-demo

Demonstrates safe recursion and includes an optional unsafe mode that deliberately causes stack overflow.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o stack_overflow_demo
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o stack_overflow_demo
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c /Fe:stack_overflow_demo.exe
```

## Run

Linux, macOS, or MSYS2:

```bash
./stack_overflow_demo
```

Windows PowerShell:

```powershell
.\stack_overflow_demo.exe
```

## Optional unsafe version

Run this only if you deliberately want to trigger a stack overflow crash.

```bash
./stack_overflow_demo --unsafe
```

Windows PowerShell:

```powershell
.\stack_overflow_demo.exe --unsafe
```
