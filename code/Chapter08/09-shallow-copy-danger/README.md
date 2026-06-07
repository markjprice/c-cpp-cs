# 09 Shallow Copy Danger

Safely demonstrates why default shallow copying of owning pointers is dangerous without deliberately crashing.

## Build and run with g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o shallow_copy_danger
./shallow_copy_danger
```

## Build and run with clang++

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o shallow_copy_danger
./shallow_copy_danger
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, then run:

```cmd
cl /std:c++20 /EHsc /W4 main.cpp /Fe:shallow_copy_danger.exe
shallow_copy_danger.exe
```

## VS Code

This folder contains `.vscode/tasks.json`. In VS Code, select **Terminal | Run Build Task** to compile the project, then **Terminal | Run Task | Run** to run it.

