# Separating interface and implementation

Shows a class declared in a `.hpp` file and implemented in a `.cpp` file.

## Build and run with g++ (GCC)

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp User.cpp -o user_demo
./user_demo
```

## Build and run with Clang

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp User.cpp -o user_demo
./user_demo
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, move into this folder, and run:

```cmd
cl /std:c++20 /EHsc /W4 main.cpp User.cpp /Fe:user_demo.exe
user_demo.exe
```

## Run from VS Code

Open this folder in VS Code, then use **Terminal | Run Build Task**. The included `.vscode/tasks.json` file builds the project with `g++`.


