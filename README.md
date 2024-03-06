# Math Expressions Calculator

This project contains a command line expression calculator.  The application reads one line at a time from the command line and calculates a result.  The result is printed to the screen.  The main function is called Eval().  Eval() takes the math expression and does three operations:  1. Tokenize() 2. InfixToPostFix() 3. EvalPostFix().  You can use Copy and Paste (Ctrl-C and Shift-Insert) on the command line.  

## Install and Build

The is a C# Console-Mode Project. Use Visual Studio 2022 and above to compile. 

## Description:

  Command-Line Calculator.  Calculate one math expression per line.

## Usage:
Shell
```
RpnOne
```

Read File
```
RpnOne [inFile]
Input File is optional.
```

Do Math on Command-Line in PowerShell
```
echo "1 + 2" | ./rpnone
> 1 + 2
3
```

Do Math on Command-Line in CMD
```
echo 1 + 2 | rpnone
> 1 + 2
3
>
```

Help
```
RpnOne -h
```

 
## Exit Application
```
Enter an empty line.
```
   

## Unit Tests

  Unit Tests are included.

## Operators

| Operator | Description | Example |
| --- | --- | --- |
| + | Add | 1 + 2 |
| - | Subtract | 5 - 2 |
| * | Multiply | 2 * 7 |
| / | Divide | 30 / 3 |
| % | Modulus | 15 % 3 |
| ^ | Power, a ^ b | 3 ^ 2 |
| @ | Negate | -5 |
| ! | Factorial | 6! |
| A |  Asolute Value | A(-5) |
| ACOS | Anti-Cosine | ACOS(0.3) |
| ASIN | Anti-Sine | ASIN(0.4) |
| ATAN | Anti-Tangent | ATAN(0.5) |
| CB | Cube, a ^ 3 | CB(5) |
| CDF | Cumulative Density Function |  CDF(0.5) |
| CL | Ceiling | CL(7.25) |
| COS | Cosine in radians | COS(0.6) |
| CR | Cube root, EXP(a, 1 / 3) |  CR(15) |
| DEG | Radians To Degrees | DEG(45) |
| EN | Euler's Number 2.71 | EN |
| F | Fraction |  F(2.34) |
| FL | Floor |  FL(7.63) |
| GCF | Greatest Common Factor |  GCF(3, 21) |
| I | Integer |  I(72.34) |
| LCM | Least Common Multiple |  LCM(5, 125) |
| LG | Base 10 Logarithm, 10 ^ a |  LG(25) |
| LN | Natural Logarithm, e ^ a | LN(35) |
| NCR | Combinations | NCR(6, 2) |
| NPR | Permutations | NPR(6, 2) |
| P2 | Power of two, 2 ^ a | P2(6) |
| PD | Prime Divisor | PD(55555) |
| PI | Half rotation in radians 3.14 | PI |
| R | Reciprocal, 1 / x |  R(16.25) |
| RAD | Degrees To Rdians |  RAD(0.785) |
| RAN | Random Integer | RAN |
| RD | Round | RD(3.34) |
| RND | Random Double Between One and Zero | RND |
| RT | Nth Root, EXP(a, 1 / b) |  RT(38, 4)
| S | Change Sign | S(-5) |
| SIN | Sine in radians |  SIN(0.83) |
| SR | Square Root, SQRT(a) | SR(25) |
| STU | Student T-Distribution |  STU(1) |
| TAN | Tangent in radians | TAN(0.35) |
| TAU | Full rotation in radians 6.28 | TAU |
| X2 | Square, a * a |  X2(3) |
| X3 | Cube, a ^ 3 | X3(5) |

## EXAMPLES

### Add 1 and 2

```
> 1 + 2
3
```

### Subtract 5 - 3

```
> 5 - 3
2
```

### Multipy 4 and 5

```
> 4 * 5
20
```

### Add and Subtract Groups of Numbers

```
> ((44.3 * 55) + (2 * 5) - 33.3)
2413.2
```

### Get Cosine of 45 degrees

```
> COS(RAD(45))
0.7071067811865476
```

### Simple Negation

```
> -2 * 5
-10
```

### Negation for Groups

```
> -(2 * 5)
-10
```

### Least Common Multiple

```
> LCM(13342, 234334)
1563242114
```


### Greatest Common Factor

```
> GCF(13342, 234334)
2
```

### Pi

```
> 6 * PI
18.84955592153876
```

### Eulers Number

```
> EN
2.718281828459045
```

### Simple Math

```
> 40-(1+2)
37
```

### Random Number

```
> RND
0.3398089438635673
```

## Binding Variables

  Variables can be bound at the source code level.  Use the Bind() function.

```
 var str = "A * B - C";
 Util util = new Util();
 string result = util.Bind(str, "A", 22.1);
 result = util.Bind(result, "B", 17.4);
 result = util.Bind(result, "C", 66.45);
 Assert.AreEqual("22.1 * 17.4 - 66.45", result);
```








