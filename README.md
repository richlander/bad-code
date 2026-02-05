# Bad Code - LLM Eval for Broken C# Code

This repository contains intentionally broken C# code designed for evaluating LLM capabilities in detecting and fixing code issues.

> ⚠️ **None of the code in this repository compiles!** This is intentional.

## Purpose

Use this repository to evaluate how well LLMs can:
- Identify compilation errors and warnings
- Explain what's wrong with the code
- Suggest fixes for various C# issues

## Projects

All projects target .NET 10.0 and use themed names (scary movies, nostalgic TV shows, sci-fi classics).

### Large Error Apps (16-250+ errors)

| Project | Errors | Error Codes | Theme | Description |
|---------|--------|-------------|-------|-------------|
| BadCodeApp | ~10 | Various | Generic | Database connectivity, JSON processing, common mistakes |
| BadWolf | 2 (masks 15) | CS8345, CS8350 | Doctor Who | Span/ref struct violations, stackalloc misuse |
| BattleBeyondTheStars | 56 | CS1100, CS1103, CS1106, CS1109 | 1980 sci-fi | Extension method definition errors |
| BlairWitch | 252 | CS0214, CS0233 | Found footage horror | Unsafe/pointer code without unsafe context |
| Browncoat | 86 | CS0310, CS0311, CS0315, CS0452, CS0453 | Firefly | Generic constraint violations |
| DangerBay | 86 | CS8600-CS8625 | 80s Canadian TV | Nullable reference type errors |
| DarkChannel | 16 | CS0834, CS8122, CS8514 | Spy/covert | Expression tree LINQ errors |
| EnterTheRing | 29 | CS0029, CS1929, CS4014 | The Expanse | Async/await misuse |
| Upload | 42 | CS0104, CS4012, CS8345, CS9244 | Amazon Prime | 61 packages, Span/async/ambiguous errors |
| Wilderpeople | 80 | CS8852, CS9035 | NZ film | Init-only and required member errors |
| ZeroDaySearch | 51 | Various | Security | System.CommandLine breaking API changes |

### Small Error Apps (2-5 errors)

| Project | Errors | Error Codes | Theme | Description |
|---------|--------|-------------|-------|-------------|
| Ghostbusters | 4 | CS0534 | 80s comedy | Abstract members not implemented |
| Gremlins | 5 | CS0305 | 80s horror | Wrong number of type arguments |
| GroundhogDay | 4 | CS0191 | Time loop comedy | Readonly field assignment outside constructor |
| Multiplicity | 3 | CS0101, CS0111 | Clone comedy | Duplicate type and method definitions |
| Ouroboros | 4 | CS0146 | Mythological | Circular base class dependencies |
| Poltergeist | 5 | CS0120, CS0176 | 80s horror | Static/instance member confusion |
| Terminator | 3 | CS0509 | Sci-fi action | Inheriting from sealed classes |
| TwinPeaks | 2 | CS0121 | Mystery TV | Ambiguous method calls |
| Vanishing | 4 | CS0161 | Thriller | Missing return statements |
| XFiles | 5 | CS0122 | 90s TV | Accessibility/protection level violations |

## Error Categories

### Compilation Errors

- **Type system**: Generic constraints, sealed inheritance, circular dependencies
- **Members**: Abstract not implemented, readonly assignment, missing returns
- **Accessibility**: Private/protected member access violations
- **Definitions**: Duplicate types/methods, wrong type argument counts
- **Modern C#**: Nullable refs, init-only properties, required members
- **Async**: Missing await, Task<T> misuse, async in wrong contexts
- **Unsafe**: Pointers without unsafe context, Span violations
- **Extensions**: Non-static class, nested class, wrong parameter position
- **Expression trees**: Unsupported C# features in LINQ expressions

### Warnings (in some projects)

- AOT compatibility (IL2026, IL3050) with Newtonsoft.Json
- Nullable reference warnings

## Usage

Present this code to an LLM and ask it to:
1. Identify all compilation errors
2. Explain each issue
3. Propose fixes

The small error apps (2-5 errors) are good for focused testing. The large error apps test handling of complex, multi-file issues.

## Building

```bash
# Build all projects (all will fail)
dotnet build

# Build a specific project
cd Terminator && dotnet build

# Count errors in a project
dotnet build 2>&1 | grep "error CS" | wc -l
```

## License

For evaluation purposes only.
