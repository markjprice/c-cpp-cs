# 08 Smart Pointers Raii

Combines `std::vector` and `std::unique_ptr` to show RAII cleanup for multiple heap objects.

## Build and run with g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o smart_pointers_raii
./smart_pointers_raii
```

## Build and run with clang++

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o smart_pointers_raii
./smart_pointers_raii
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, then run:

```cmd
cl /std:c++20 /EHsc /W4 main.cpp /Fe:smart_pointers_raii.exe
smart_pointers_raii.exe
```

## VS Code

This folder contains `.vscode/tasks.json`. In VS Code, select **Terminal | Run Build Task** to compile the project, then **Terminal | Run Task | Run** to run it.

