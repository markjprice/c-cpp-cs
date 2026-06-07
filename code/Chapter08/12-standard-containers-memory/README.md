# 12 Standard Containers Memory

Shows how `std::string`, `std::vector`, and `std::array` manage memory automatically.

## Build and run with g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o standard_containers
./standard_containers
```

## Build and run with clang++

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o standard_containers
./standard_containers
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, then run:

```cmd
cl /std:c++20 /EHsc /W4 main.cpp /Fe:standard_containers.exe
standard_containers.exe
```

## VS Code

This folder contains `.vscode/tasks.json`. In VS Code, select **Terminal | Run Build Task** to compile the project, then **Terminal | Run Task | Run** to run it.

