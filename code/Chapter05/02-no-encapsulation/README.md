# 02 - No encapsulation

Demonstrates how public `struct` fields can be modified directly, bypassing validation logic.

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


