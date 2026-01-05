# 🧮 Math Gone Wild: Expression Calculator

A robust C# command-line utility for evaluating complex mathematical expressions. The engine converts standard infix notation into RPN (Reverse Polish Notation) for high-precision calculation.

## 🚀 Quick Start

**Prerequisites:** Visual Studio 2022+ 

1. Open the solution file in Visual Studio.
2. Build the project (**Ctrl+Shift+B**).
3. Run via CLI:

# Interactive mode
RpnOne

# Process a file
RpnOne [inFile]

# Help
RpnOne -h

## 🛠️ The Eval() Engine
The core logic resides in the `Eval()` method, which processes math expressions through a three-stage pipeline to ensure high precision:

1.  **Tokenize()**: Segments the input string into operands, operators, and functions.
2.  **InfixToPostFix()**: Converts standard notation into Reverse Polish Notation (RPN) using the Shunting-yard algorithm.
3.  **EvalPostFix()**: Executes the calculation by processing the RPN stack.

---

## 🔢 Operator Reference

| Category | Operators | Examples |
| :--- | :--- | :--- |
| **Basic** | `+`, `-`, `*`, `/`, `%`, `^`, `@` (Negate) | `15 % 3`, `3 ^ 2` |
| **Trig** | `SIN`, `COS`, `TAN`, `ACOS`, `ASIN`, `ATAN` | `COS(RAD(45))` |
| **Roots/Log** | `SR` (Sqrt), `CR` (Cube), `RT` (Nth), `LN`, `LG` | `RT(38, 4)` |
| **Theory** | `GCF`, `LCM`, `PD` (Prime Divisor), `!` | `GCF(3, 21)` |
| **Probability**| `NCR`, `NPR`, `ND`, `CDF`, `STU` | `NCR(6, 2)` |
| **Constants** | `PI`, `TAU`, `EN` (Euler's Number) | `6 * PI` |
| **Rounding** | `CL` (Ceiling), `FL` (Floor), `RD`, `I` (Int) | `CL(7.25)` |
| **Other** | `DEG`, `RAD`, `RAN` (Int), `RND` (0-1) | `RAD(180)` |

---

## 💻 Programmatic Binding
You can inject variables into expressions dynamically at the source level using the `Util` class. This is perfect for automation or templated math.

```csharp
var str = "A * B - C";
Util util = new Util();

// Bind values to placeholders
string result = util.Bind(str, "A", 22.1);
result = util.Bind(result, "B", 17.4);
result = util.Bind(result, "C", 66.45);

// Final output: "22.1 * 17.4 - 66.45"
