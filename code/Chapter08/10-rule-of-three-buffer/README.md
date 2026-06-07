# 10 Rule Of Three Buffer

Implements destructor, copy constructor, and copy assignment operator for a class that owns a dynamic array.

## Build and run with g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o rule_of_three_buffer
./rule_of_three_buffer
```

## Build and run with clang++

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o rule_of_three_buffer
./rule_of_three_buffer
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, then run:

```cmd
cl /std:c++20 /EHsc /W4 main.cpp /Fe:rule_of_three_buffer.exe
rule_of_three_buffer.exe
```

## VS Code

This folder contains `.vscode/tasks.json`. In VS Code, select **Terminal | Run Build Task** to compile the project, then **Terminal | Run Task | Run** to run it.

