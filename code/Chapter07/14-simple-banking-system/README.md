# Simple Banking System

End-of-chapter project showing encapsulation, inheritance, polymorphism, composition, `std::unique_ptr`, and separate header/source files.

## Build and run with g++ (GCC)

```bash
g++ -std=c++20 -Wall -Wextra -pedantic main.cpp Account.cpp SavingsAccount.cpp Bank.cpp -o banking_system
./banking_system
```

## Build and run with Clang

```bash
clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp Account.cpp SavingsAccount.cpp Bank.cpp -o banking_system
./banking_system
```

## Build and run with MSVC

Open a Developer Command Prompt for Visual Studio, move into this folder, and run:

```cmd
cl /std:c++20 /EHsc /W4 main.cpp Account.cpp SavingsAccount.cpp Bank.cpp /Fe:banking_system.exe
banking_system.exe
```

## Run from VS Code

Open this folder in VS Code, then use **Terminal | Run Build Task**. The included `.vscode/tasks.json` file builds the project with `g++`.


