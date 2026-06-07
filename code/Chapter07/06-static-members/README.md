# Static members

Shows class-level shared state using an inline static data member and a static member function.

## Build and run with g++ (GCC)

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o app
./app
```

## Build and run with Clang

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o app
./app
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, move into this folder, and run:

```cmd
cl /std:c++20 /EHsc /W4 main.cpp /Fe:app.exe
app.exe
```

## Run from VS Code

Open this folder in VS Code, then use **Terminal | Run Build Task**. The included `.vscode/tasks.json` file builds the project with `g++`.


