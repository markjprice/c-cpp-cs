# 13 - C++ danger zones

Shows safe demonstrations of examples from the “Why C++ is more dangerous than C” section.

## Build and run with GCC / g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o danger_zones
./danger_zones
```

## Build and run with Clang

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o danger_zones
./danger_zones
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, move into this folder, and run:

```cmd
cl /std:c++20 /W4 /EHsc main.cpp /Fe:danger_zones.exe
danger_zones.exe
```

## Run in VS Code

Open this folder in VS Code, then use **Terminal | Run Build Task** to build with `g++`. Use **Terminal | Run Task | Run** to build and run.

