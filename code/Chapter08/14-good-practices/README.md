# 14 Good Practices

Brings together stack allocation, standard containers, `std::unique_ptr`, ownership transfer, and const references.

## Build and run with g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o good_practices
./good_practices
```

## Build and run with clang++

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o good_practices
./good_practices
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, then run:

```cmd
cl /std:c++20 /EHsc /W4 main.cpp /Fe:good_practices.exe
good_practices.exe
```

## VS Code

This folder contains `.vscode/tasks.json`. In VS Code, select **Terminal | Run Build Task** to compile the project, then **Terminal | Run Task | Run** to run it.

