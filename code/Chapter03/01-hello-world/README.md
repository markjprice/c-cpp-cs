# 01 - Hello World

This project shows the smallest useful C program from Chapter 3.

## GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c -o hello
./hello
```

## Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c -o hello
./hello
```

## MSVC

```cmd
cl /std:c17 /W4 main.c /Fe:hello.exe
hello.exe
```
