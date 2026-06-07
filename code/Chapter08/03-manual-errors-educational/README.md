# 03 Manual Errors Educational

    Runs safely by default but includes optional unsafe modes for memory debugging experiments.

    ## Build and run with g++

    ```bash
    g++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o manual_errors
    ./manual_errors
    ```

    ## Build and run with clang++

    ```bash
    clang++ -std=c++20 -Wall -Wextra -pedantic main.cpp -o manual_errors
    ./manual_errors
    ```

    ## Build and run with MSVC

    Open a Developer Command Prompt for Visual Studio, then run:

    ```cmd
    cl /std:c++20 /EHsc /W4 main.cpp /Fe:manual_errors.exe
    manual_errors.exe
    ```

    ## VS Code

    This folder contains `.vscode/tasks.json`. In VS Code, select **Terminal | Run Build Task** to compile the project, then **Terminal | Run Task | Run** to run it.

## Optional unsafe runs

```bash
./manual_errors leak
./manual_errors dangling
./manual_errors double-delete
./manual_errors mismatch
```

Use AddressSanitizer or Valgrind when running the unsafe modes.

