# 08 - Dynamic list manual container

Shows how a simple reusable container needs manual memory management, resizing, and bookkeeping in C.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c int_list.c -o app
```

## Run

```bash
./app
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c int_list.c -o app
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c int_list.c /Fe:app.exe
```


## Memory checking

```bash
valgrind --leak-check=full ./app
```

