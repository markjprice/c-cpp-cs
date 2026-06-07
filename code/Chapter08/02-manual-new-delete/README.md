# 02 Manual New Delete

Demonstrates legacy `new`, `delete`, `new[]`, and `delete[]` so readers recognize older C++ code.

## Build and run with g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o manual_new_delete
./manual_new_delete
```

## Build and run with clang++

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o manual_new_delete
./manual_new_delete
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, then run:

```cmd
cl /std:c++20 /EHsc /W4 main.cpp /Fe:manual_new_delete.exe
manual_new_delete.exe
```

## VS Code

This folder contains `.vscode/tasks.json`. In VS Code, select **Terminal | Run Build Task** to compile the project, then **Terminal | Run Task | Run** to run it.

