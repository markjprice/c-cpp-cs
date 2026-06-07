# 06 Unique Ptr Ownership

Demonstrates exclusive ownership with `std::unique_ptr` and transfer using `std::move`.

## Build and run with g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o unique_ptr_ownership
./unique_ptr_ownership
```

## Build and run with clang++

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o unique_ptr_ownership
./unique_ptr_ownership
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, then run:

```cmd
cl /std:c++20 /EHsc /W4 main.cpp /Fe:unique_ptr_ownership.exe
unique_ptr_ownership.exe
```

## VS Code

This folder contains `.vscode/tasks.json`. In VS Code, select **Terminal | Run Build Task** to compile the project, then **Terminal | Run Task | Run** to run it.

