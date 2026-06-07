# 08 - Functions across multiple files

This project demonstrates function prototypes, a header file, a source file, and a separate `main.c` file.

## GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c math_utils.c -o math_example
./math_example
```

## Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c math_utils.c -o math_example
./math_example
```

## MSVC

```cmd
cl /std:c17 /W4 main.c math_utils.c /Fe:math_example.exe
math_example.exe
```
