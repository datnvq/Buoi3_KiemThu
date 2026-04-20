# Issue 1 - Valid black-box test cases

This file lists valid-input test cases using equivalence partitioning and boundary value analysis.

## 1. Rectangle perimeter

| ID | Input | Expected output | Technique |
|---|---|---|---|
| RP-01 | length = 3, width = 4 | 14 | Equivalence class, normal value |
| RP-02 | length = 0.5, width = 0.5 | 2 | Boundary-style small positive values |

## 2. Rectangle area

| ID | Input | Expected output | Technique |
|---|---|---|---|
| RA-01 | length = 3, width = 4 | 12 | Equivalence class |
| RA-02 | length = 0.5, width = 0.5 | 0.25 | Boundary-style small positive values |

## 3. Quadratic equation

Equation: ax^2 + bx + c = 0

| ID | Input | Expected output | Technique |
|---|---|---|---|
| QE-01 | a = 1, b = -5, c = 6 | Two roots: 2 and 3 | Equivalence class |
| QE-02 | a = 1, b = 2, c = 1 | One double root: -1 | Boundary on discriminant = 0 |

## 4. Days in a month

| ID | Input | Expected output | Technique |
|---|---|---|---|
| DM-01 | month = 1, year = 2026 | 31 | Equivalence class |
| DM-02 | month = 2, year = 2024 | 29 | Leap-year boundary |

## 5. Prime check

| ID | Input | Expected output | Technique |
|---|---|---|---|
| PR-01 | n = 17 | true | Equivalence class |
| PR-02 | n = 1 | false | Boundary value |

## 6. Alternating sum

| ID | Input | Expected output | Technique |
|---|---|---|---|
| AS-01 | n = 5 | 3 | Equivalence class |
| AS-02 | n = 6 | -3 | Boundary on parity change |

## 7. Greatest common divisor

| ID | Input | Expected output | Technique |
|---|---|---|---|
| GCD-01 | a = 48, b = 18 | 6 | Equivalence class |
| GCD-02 | a = 0, b = 18 | 18 | Boundary with zero operand |

## 8. Sum of factorials

| ID | Input | Expected output | Technique |
|---|---|---|---|
| SF-01 | n = 4 | 33 | Equivalence class |
| SF-02 | n = 1 | 1 | Boundary value |