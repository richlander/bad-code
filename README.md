# Bad Code - LLM Eval for Broken C# Code

This repository contains intentionally broken C# code designed for evaluating LLM capabilities in detecting and fixing code issues.

> ⚠️ **None of the code in this repository compiles!** This is intentional.

## Purpose

Use this repository to evaluate how well LLMs can:
- Identify compilation errors and warnings
- Explain what's wrong with the code
- Suggest fixes for various C# issues

## Error Categories

### Compilation Errors

- Undefined variables and missing types
- Type mismatches and invalid assignments
- Return type mismatches
- Variables used before declaration
- Case sensitivity issues (e.g., wrong method names)
- Read-only property assignments
- Invalid generic type arguments

### Warnings

- Unused variables and fields
- Deprecated/obsolete method usage
- Null reference warnings
- Unreachable code
- Async methods without await
- Empty catch blocks
- Value type null comparisons

### Runtime Errors (if code could compile)

- Division by zero
- Array index out of bounds
- Invalid casts

## Projects

### BadCodeApp

A general-purpose broken application demonstrating database connectivity, JSON processing, and common coding mistakes.

### CveSearchApp

A .NET CVE search tool with two key migration challenges:

- **System.CommandLine breaking changes**: Uses an outdated API pattern (e.g., `Handler.SetHandler`) that no longer exists in the latest version. LLMs trained on older documentation may not know the new API.
- **AOT compatibility**: Has `PublishAot=true` but uses Newtonsoft.Json, which doesn't support Native AOT. Requires migration to System.Text.Json with source generators.

Both projects target .NET 10.0.

## Usage

Present this code to an LLM and ask it to:
1. Identify all compilation errors
2. Explain each issue
3. Propose fixes

## License

For evaluation purposes only.
