# 📚 Full Operator & Function Reference

This document provides a comprehensive list of all mathematical operators and functions supported by the **Math Gone Wild** engine.

## 🟢 Basic Arithmetic
| Op | Name | Description | Example |
| :--- | :--- | :--- | :--- |
| `+` | Add | Standard addition | `1 + 2` |
| `-` | Subtract | Standard subtraction | `5 - 2` |
| `*` | Multiply | Standard multiplication | `2 * 7` |
| `/` | Divide | Standard division | `30 / 3` |
| `%` | Modulus | Remainder of division | `15 % 3` |
| `^` | Power | $a$ raised to power $b$ | `3 ^ 2` |
| `@` | Negate | Unary negation | `@5` (evals to -5) |
| `S` | Sign | Change sign | `S(-5)` (evals to 5) |

## 🔵 Advanced Algebra & Roots
| Op | Name | Description | Example |
| :--- | :--- | :--- | :--- |
| `SR` | Square Root | $\sqrt{a}$ | `SR(25)` |
| `CR` | Cube Root | $\sqrt[3]{a}$ | `CR(15)` |
| `RT` | Nth Root | $\sqrt[b]{a}$ | `RT(38, 4)` |
| `X2` | Square | $a^2$ | `X2(3)` |
| `X3` | Cube | $a^3$ | `X3(5)` |
| `CB` | Cube | Alias for $a^3$ | `CB(5)` |
| `P2` | Power of 2 | $2^a$ | `P2(6)` |

## 🟡 Trigonometry & Logs
| Op | Name | Description | Example |
| :--- | :--- | :--- | :--- |
| `SIN` | Sine | Sine (radians) | `SIN(0.83)` |
| `COS` | Cosine | Cosine (radians) | `COS(0.6)` |
| `TAN` | Tangent | Tangent (radians) | `TAN(0.35)` |
| `ACOS` | Anti-Cosine | Arccosine | `ACOS(0.3)` |
| `ASIN` | Anti-Sine | Arcsine | `ASIN(0.4)` |
| `ATAN` | Anti-Tangent| Arctangent | `ATAN(0.5)` |
| `DEG` | To Degrees | Rad to Deg | `DEG(45)` |
| `RAD` | To Radians | Deg to Rad | `RAD(0.785)` |
| `LN` | Nat Log | Base $e$ logarithm | `LN(35)` |
| `LG` | Log 10 | Base 10 logarithm | `LG(25)` |

## 🟣 Theory & Statistics
| Op | Name | Description | Example |
| :--- | :--- | :--- | :--- |
| `!` | Factorial | $n!$ | `6!` |
| `GCF` | GCF | Greatest Common Factor | `GCF(3, 21)` |
| `LCM` | LCM | Least Common Multiple | `LCM(5, 125)` |
| `NCR` | Combinations | $n$ choose $r$ | `NCR(6, 2)` |
| `NPR` | Permutations | $n$ P $r$ | `NPR(6, 2)` |
| `PD` | Prime Divisor| Find prime divisors | `PD(55555)` |
| `ND` | Normal Dist | Normal Distribution | `ND(0.25, 0, 1)` |
| `CDF` | Cumul Density| CDF Function | `CDF(0.5)` |
| `STU` | Student-T | T-Distribution | `STU(1, 10)` |

## ⚪ Logic & Constants
| Op | Name | Description | Example |
| :--- | :--- | :--- | :--- |
| `PI` | Pi | $\approx 3.14159$ | `PI` |
| `TAU` | Tau | $\approx 6.28318$ | `TAU` |
| `EN` | Euler | $\approx 2.71828$ | `EN` |
| `A` | Absolute | $|a|$ | `A(-5)` |
| `CL` | Ceiling | Round up | `CL(7.25)` |
| `FL` | Floor | Round down | `FL(7.63)` |
| `RD` | Round | Round to nearest | `RD(3.34)` |
| `I` | Integer | Truncate to int | `I(72.34)` |
| `F` | Fraction | Get decimal part | `F(2.34)` |
| `RAN` | Random Int | Random integer | `RAN` |
| `RND` | Random Dbl | Random $(0.0, 1.0)$ | `RND` |