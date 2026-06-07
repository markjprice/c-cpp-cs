# 04 - Naming conflicts

Demonstrates prefix-based naming as a workaround for C's single global function namespace.

## Build with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c user_manager.c database_connection.c -o app
```

## Run

```bash
./app
```

## Build with Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c user_manager.c database_connection.c -o app
```

## Build with MSVC

```cmd
cl /std:c17 /W4 main.c user_manager.c database_connection.c /Fe:app.exe
```


## Experiment

Try renaming both initialization functions to `init`. The program will fail to link because C has no namespace feature for ordinary functions.

