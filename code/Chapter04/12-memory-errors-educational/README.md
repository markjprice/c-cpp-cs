# 12-memory-errors-educational

Contains one safe example and several optional unsafe modes for demonstrating leaks, buffer overflow, and use-after-free with memory-checking tools.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o memory_errors_educational
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o memory_errors_educational
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c /Fe:memory_errors_educational.exe
```

## Run

Linux, macOS, or MSYS2:

```bash
./memory_errors_educational
```

Windows PowerShell:

```powershell
.\memory_errors_educational.exe
```

## Optional unsafe demonstrations

```bash
./memory_errors_educational --leak
./memory_errors_educational --overflow
./memory_errors_educational --use-after-free
```

Windows PowerShell:

```powershell
.\memory_errors_educational.exe --leak
.\memory_errors_educational.exe --overflow
.\memory_errors_educational.exe --use-after-free
```

## Example Valgrind usage

```bash
valgrind --leak-check=full ./memory_errors_educational --leak
```
