# 05 - Input, output, and formatting

This project demonstrates `printf()`, `scanf()`, format specifiers, field width, precision, and escape sequences.

## GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o io_formatting
./io_formatting
```

## Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o io_formatting
./io_formatting
```

## MSVC

MSVC warns that `scanf` is considered unsafe in Microsoft-specific C runtime guidance. For this beginner example, disable that warning by defining `_CRT_SECURE_NO_WARNINGS`:

```cmd
cl /std:c17 /W4 /D_CRT_SECURE_NO_WARNINGS main.c /Fe:io_formatting.exe
io_formatting.exe
```
