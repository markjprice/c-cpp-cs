# 06 - Ownership rules

Shows how C relies on documentation and discipline to define who owns allocated memory.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c user.c -o app
```

## Run

```bash
./app
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c user.c -o app
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c user.c /Fe:app.exe
```


## Memory checking

On Linux or WSL, you can check for leaks with:

```bash
valgrind --leak-check=full ./app
```

