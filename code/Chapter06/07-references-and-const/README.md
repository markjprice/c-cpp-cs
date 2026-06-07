# 07 - References and const references

Compares pass by value, pass by reference, and pass by const reference.

## Build and run with GCC / g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o references
./references
```

## Build and run with Clang

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o references
./references
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, move into this folder, and run:

```cmd
cl /std:c++20 /W4 /EHsc main.cpp /Fe:references.exe
references.exe
```

## Run in VS Code

Open this folder in VS Code, then use **Terminal | Run Build Task** to build with `g++`. Use **Terminal | Run Task | Run** to build and run.

