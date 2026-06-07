# 13 Asan Valgrind Demo

    Provides optional unsafe modes for AddressSanitizer and Valgrind practice.

    ## Build and run with g++

    ```bash
    g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o memory_tools_demo
    ./memory_tools_demo
    ```

    ## Build and run with clang++

    ```bash
    clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o memory_tools_demo
    ./memory_tools_demo
    ```

    ## Build and run with MSVC

    Open a Developer Command Prompt for Visual Studio, then run:

    ```cmd
    cl /std:c++20 /EHsc /W4 main.cpp /Fe:memory_tools_demo.exe
    memory_tools_demo.exe
    ```

    ## VS Code

    This folder contains `.vscode/tasks.json`. In VS Code, select **Terminal | Run Build Task** to compile the project, then **Terminal | Run Task | Run** to run it.

## AddressSanitizer example

```bash
g++ -std=c++20 -Wall -Wextra -pedantic -g -fsanitize=address main.cpp -o memory_tools_demo
./memory_tools_demo use-after-free
```

## Valgrind example

```bash
g++ -std=c++20 -Wall -Wextra -pedantic -g main.cpp -o memory_tools_demo
valgrind --leak-check=full ./memory_tools_demo leak
```

