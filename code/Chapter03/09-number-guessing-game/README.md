# 09 - Number guessing game

This is the complete multi-file project from the end of Chapter 3.

Files:

- `main.c`: program entry point.
- `game.h`: public declaration for the game module.
- `game.c`: guessing game logic.
- `input.h`: public declaration for the input module.
- `input.c`: integer input helper.

## GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic main.c game.c input.c -o guessing_game
./guessing_game
```

## Clang

```bash
clang -std=c17 -Wall -Wextra -pedantic main.c game.c input.c -o guessing_game
./guessing_game
```

## MSVC

MSVC warns that `scanf` is considered unsafe in Microsoft-specific C runtime guidance. For this beginner example, disable that warning by defining `_CRT_SECURE_NO_WARNINGS`:

```cmd
cl /std:c17 /W4 /D_CRT_SECURE_NO_WARNINGS main.c game.c input.c /Fe:guessing_game.exe
guessing_game.exe
```
