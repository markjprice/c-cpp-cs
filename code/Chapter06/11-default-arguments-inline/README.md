# 11 - Default arguments and inline functions

Demonstrates default arguments in a header and an inline function.

## Build and run with GCC / g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp math_utils.cpp -o defaults_inline
./defaults_inline
```

## Build and run with Clang

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp math_utils.cpp -o defaults_inline
./defaults_inline
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, move into this folder, and run:

```cmd
cl /std:c++20 /W4 /EHsc main.cpp math_utils.cpp /Fe:defaults_inline.exe
defaults_inline.exe
```

## Run in VS Code

Open this folder in VS Code, then use **Terminal | Run Build Task** to build with `g++`. Use **Terminal | Run Task | Run** to build and run.

