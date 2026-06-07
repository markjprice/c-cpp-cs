# 09 - Range-based for loops and auto

Demonstrates range-based loops, `auto`, copies, references, const references, and a type inference gotcha.

## Build and run with GCC / g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o range_auto
./range_auto
```

## Build and run with Clang

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o range_auto
./range_auto
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, move into this folder, and run:

```cmd
cl /std:c++20 /W4 /EHsc main.cpp /Fe:range_auto.exe
range_auto.exe
```

## Run in VS Code

Open this folder in VS Code, then use **Terminal | Run Build Task** to build with `g++`. Use **Terminal | Run Task | Run** to build and run.

