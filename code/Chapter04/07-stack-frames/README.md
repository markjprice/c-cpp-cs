# 07-stack-frames

Shows how nested function calls create separate stack frames. The exact addresses and stack growth direction are implementation details.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o stack_frames
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o stack_frames
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c /Fe:stack_frames.exe
```

## Run

Linux, macOS, or MSYS2:

```bash
./stack_frames
```

Windows PowerShell:

```powershell
.\stack_frames.exe
```
