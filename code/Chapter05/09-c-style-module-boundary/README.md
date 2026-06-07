# 09 - C-style module boundary

Shows a disciplined C pattern using an opaque struct to hide implementation details. This is a workaround for C's lack of built-in encapsulation.

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


