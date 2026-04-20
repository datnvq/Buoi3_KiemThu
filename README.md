# Black Box Testing Practice

This repository contains a small .NET console application and a custom test runner for black-box testing practice.

## Included exercises

1. Rectangle perimeter
2. Rectangle area
3. Quadratic equation solver
4. Days in a month
5. Prime check
6. Alternating sum `1 - 2 + 3 - 4 + ... + n`
7. Greatest common divisor
8. Sum of factorials `1! + 2! + ... + n!`

## Project structure

- `src/Buoi3KiemThu`: console application and reusable calculation methods
- `tests/Buoi3KiemThu.Tests`: custom test runner
- `tests/Buoi3KiemThu.AutoTests`: data-driven auto test generator
- `testcases/issue1-valid-cases.md`: valid black-box test cases
- `testcases/issue2-invalid-cases.md`: invalid, boundary and exception cases
- `results/test-results.txt`: saved output from the latest test run
- `results/auto-test-results.txt`: saved output from the auto runner

## How black-box testing was applied

For each exercise, the test design used three main ideas:

- equivalence partitioning to select representative valid inputs
- boundary value analysis for edge values such as 1, 0, leap-year February, and parity changes
- invalid-data testing to verify the program rejects or reports bad input

## Run the tests

```bash
dotnet run --project src/Buoi3KiemThu/Buoi3KiemThu.csproj
```

```bash
dotnet run --project tests/Buoi3KiemThu.Tests/Buoi3KiemThu.Tests.csproj
```

Run the auto-generated testcase version:

```bash
dotnet run --project tests/Buoi3KiemThu.AutoTests/Buoi3KiemThu.AutoTests.csproj
```

## Notes for GitHub workflow

The assignment asks for two issues:

- Issue 1: valid black-box test cases
- Issue 2: invalid, boundary and exception test cases

This repository is organized so those two sets can be committed separately if needed.