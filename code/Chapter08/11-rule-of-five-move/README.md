# 11 Rule Of Five Move

Extends the Rule of Three with move constructor and move assignment operator to transfer ownership efficiently.

## Build and run with g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o rule_of_five_move
./rule_of_five_move
```

## Build and run with clang++

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o rule_of_five_move
./rule_of_five_move
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, then run:

```cmd
cl /std:c++20 /EHsc /W4 main.cpp /Fe:rule_of_five_move.exe
rule_of_five_move.exe
```

## VS Code

This folder contains `.vscode/tasks.json`. In VS Code, select **Terminal | Run Build Task** to compile the project, then **Terminal | Run Task | Run** to run it.

