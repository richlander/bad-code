---
name: dotnet-scope
description: Use dotnet-scope to diagnose .NET build errors. When a dotnet build fails, pipe the output to `dotnet-scope diagnose` to get enriched diagnostics with source context, documentation links, and suggestions for common errors like typos in method names.
---

# dotnet-scope

A diagnostic instrument for .NET source code. Use this tool when working with C# projects that have build errors or when you need to understand what external APIs a codebase uses.

## Installation

```bash
dotnet tool install -g dotnet-scope
```

## Commands

### diagnose - Analyze build errors

Pipe build output to get enriched diagnostics:

```bash
dotnet build 2>&1 | dotnet-scope diagnose
```

This provides:
- Source context with line numbers
- Links to Microsoft documentation (for humans)
- Raw GitHub markdown links (for LLM consumption)
- Suggestions for common errors (e.g., case-sensitive method name typos)

### symbols - Show symbols at a location

```bash
dotnet-scope symbols Program.cs:42 -c 2
```

Shows symbols in scope at a specific line with classification (UserDefined, Framework, External, Undefined).

### scan - Discover external APIs

```bash
dotnet-scope scan src/ --packages
```

Lists which NuGet package APIs are used in the codebase.

### docs - Generate API documentation

```bash
dotnet-scope docs src/
```

Shows documentation for packages used, with follow-up commands for deeper investigation.

## Example Workflow

When a build fails:

1. Run: `dotnet build 2>&1 | dotnet-scope diagnose`
2. Review the enriched output with source context
3. For CS0117/CS1061 errors (member not found), check the "Did you mean?" suggestions
4. Use the Raw: links to fetch full documentation if needed
5. Fix the issues and rebuild

## Supported Error Codes

dotnet-scope includes documentation for ~3,700 diagnostic codes:
- CS* - C# compiler (1969 codes)
- MSB* - MSBuild (692 codes)
- CA* - Code analysis (315 codes)
- NETSDK* - SDK (201 codes)
- SYSLIB* - Runtime (170 codes)
- And 14 more prefixes (Razor, ASP.NET, Blazor, Aspire, etc.)
