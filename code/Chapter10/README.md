# Chapter 10: C# Object-Oriented Programming projects

This folder contains complete runnable projects for the Chapter 10 code examples.

Intended repository location:

```text
code/
  ch10-csharp-oop/
    01-classes-and-objects/
    02-encapsulation-properties/
    03-constructors-lifecycle/
    04-generic-types-collections/
    05-inheritance-polymorphism/
    06-interfaces-abstraction/
    07-structs-records-immutability/
    08-static-members-utility-types/
    09-composition-maintainable-design/
    10-banking-oop-project/
```

## Requirements

Install the .NET SDK. These projects target .NET 11 by default.

Check your SDK:

```bash
dotnet --version
```

If you are using .NET 10 or another supported SDK, change each `.csproj` file's `TargetFramework` value from `net11.0` to the framework you have installed, for example `net10.0`.

## Build and run a project

From any project folder:

```bash
dotnet build
dotnet run
```

From this chapter folder:

```bash
dotnet run --project 01-classes-and-objects/01-classes-and-objects.csproj
```

## Projects

| Project | Title | Purpose |
|---|---|---|
| `01-classes-and-objects` | Classes and objects | Demonstrates class definitions, object creation, instance data, instance methods, the `this` keyword, required members, and reference behavior. |
| `02-encapsulation-properties` | Encapsulation and properties | Shows access modifiers, properties, read-only setters, init-only properties, computed properties, validation, and expression-bodied properties. |
| `03-constructors-lifecycle` | Constructors and object lifecycle | Demonstrates default constructors, parameterized constructors, constructor overloading, constructor chaining, primary constructors, object initializers, collection initializers, static constructors, and finalizers. |
| `04-generic-types-collections` | Generic types and collections | Shows `List<T>`, `Dictionary<TKey,TValue>`, generic methods, multiple type parameters, generic constraints, and collection selection. |
| `05-inheritance-polymorphism` | Inheritance and polymorphism | Demonstrates base and derived classes, `protected`, constructor order, `base(...)`, `virtual`, `override`, runtime polymorphism, polymorphic collections, and sealed classes. |
| `06-interfaces-abstraction` | Interfaces and abstraction | Shows abstract classes, abstract methods, interfaces, multiple interface implementation, interface polymorphism, default interface methods, and dependency-injection-style design. |
| `07-structs-records-immutability` | Structs, records, immutability, and equality | Demonstrates structs, readonly structs, records, value equality, reference equality, and enums. |
| `08-static-members-utility-types` | Static members and utility types | Shows static fields, static methods, static constructors, static classes, utility functions, shared state, and the difference between instance and class-level behavior. |
| `09-composition-maintainable-design` | Composition and maintainable design | Demonstrates focused classes, composition, interfaces for loose coupling, constructor injection, and avoiding hard-coded dependencies. |
| `10-banking-oop-project` | Banking OOP project | A small complete banking example that combines encapsulation, inheritance, polymorphism, interfaces, records, collections, composition, and maintainable design. |

## Notes for readers

The projects are intentionally small. They are designed to match the examples and teaching points in the chapter, not to represent full production applications.

Type the examples yourself first when learning, then use these projects to compare, fix mistakes, and experiment.
