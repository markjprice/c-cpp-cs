# 10 - C to C++ preview

This project is a preview of the next part of the book. It compares the C pattern of `struct` plus separate functions with a simple C++ class that groups data and behavior.

## Build the C version with GCC

```bash
gcc -std=c17 -Wall -Wextra -pedantic user_c_version.c -o user_c_version
```

## Run the C version

```bash
./user_c_version
```

## Build the C++ preview with g++

```bash
g++ -std=c++20 -Wall -Wextra -pedantic user_cpp_preview.cpp -o user_cpp_preview
```

## Run the C++ preview

```bash
./user_cpp_preview
```

## Build with MSVC

From a Developer Command Prompt:

```cmd
cl /std:c17 /W4 user_c_version.c /Fe:user_c_version.exe
cl /std:c++20 /EHsc /W4 user_cpp_preview.cpp /Fe:user_cpp_preview.exe
```

The C++ example is not intended to teach all of C++. It simply previews why classes, encapsulation, constructors, and member functions matter.
