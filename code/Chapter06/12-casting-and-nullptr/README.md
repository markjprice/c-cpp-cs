# 12 - static_cast and nullptr

Demonstrates explicit conversion with `static_cast` and type-safe null pointer overload resolution with `nullptr`.

## Build and run with GCC / g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o casts_nullptr
./casts_nullptr
```

## Build and run with Clang

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o casts_nullptr
./casts_nullptr
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, move into this folder, and run:

```cmd
cl /std:c++20 /W4 /EHsc main.cpp /Fe:casts_nullptr.exe
casts_nullptr.exe
```

## Run in VS Code

Open this folder in VS Code, then use **Terminal | Run Build Task** to build with `g++`. Use **Terminal | Run Task | Run** to build and run.

