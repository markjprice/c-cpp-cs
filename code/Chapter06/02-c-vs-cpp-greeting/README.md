# 02 - C-style greeting rewritten in C++

Uses `std::string` and `std::getline` instead of a fixed-size `char` buffer and `scanf`.

## Build and run with GCC / g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o greeting
./greeting
```

## Build and run with Clang

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o greeting
./greeting
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, move into this folder, and run:

```cmd
cl /std:c++20 /W4 /EHsc main.cpp /Fe:greeting.exe
greeting.exe
```

## Run in VS Code

Open this folder in VS Code, then use **Terminal | Run Build Task** to build with `g++`. Use **Terminal | Run Task | Run** to build and run.

Example input: `Alice Smith`

