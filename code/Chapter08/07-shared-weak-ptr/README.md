# 07 Shared Weak Ptr

Shows shared ownership with `std::shared_ptr` and safe non-owning observation with `std::weak_ptr`.

## Build and run with g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o shared_weak_ptr
./shared_weak_ptr
```

## Build and run with clang++

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o shared_weak_ptr
./shared_weak_ptr
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, then run:

```cmd
cl /std:c++20 /EHsc /W4 main.cpp /Fe:shared_weak_ptr.exe
shared_weak_ptr.exe
```

## VS Code

This folder contains `.vscode/tasks.json`. In VS Code, select **Terminal | Run Build Task** to compile the project, then **Terminal | Run Task | Run** to run it.

