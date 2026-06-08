# Namespaces and assemblies

This example uses two projects:

- `GameEngine.Core`: a class library compiled into its own assembly.
- `NamespaceAssemblyDemo`: a console app that references the class library.

It demonstrates namespaces, aliases, name collision avoidance, project references, assemblies, `internal`, and reflection.

## Build

From this folder:

```bash
dotnet build src/NamespaceAssemblyDemo/NamespaceAssemblyDemo.csproj
```

## Run

```bash
dotnet run --project src/NamespaceAssemblyDemo/NamespaceAssemblyDemo.csproj
```

## Notes

The app references the class library using this project reference:

```xml
<ProjectReference Include="../GameEngine.Core/GameEngine.Core.csproj" />
```

That project reference causes the class library to be built and made available to the console app.
