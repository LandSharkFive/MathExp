# Math Expressions Calculator

This project contains a command line expression calculator.  The application reads one line at a time from the command line and calculates a result.  The result is printed to the screen.  The main function is called Eval().  Eval() takes the math expression and does three operations:  1. Tokenize() 2. InfixToPostFix() 3. EvalPostFix().  You can use Copy and Paste (Ctrl-C and Shift-Insert) on the command line.

## Install and Build

The is a C# Console-Mode Project. Use Visual Studio 2022 and above to compile. 

## Description:

  Command-Line Calculator.  Calculate one math expression per line.

## Usage:
	RpnOne 

 
## Exit Application

  Enter an empty line.

## Unit Tests

  Unit Tests are included.

## Operators

| Operator | Description |
| --- | --- |
| + | add|
| - | subtract |
| * | multiply |
| / | divide |
| % | modulus |
| ^ | power, a ^ b |
| ! | factorial |
| A |  absolute value |
| ACOS | anti-cosine |
| ASIN | anti-sine |
| ATAN | anti-tangent |
| CB | cube, a ^ 3 |
| CL | Ceiling |
| COS | Cosine in radians |
| CR | Cube root, EXP(a, 1 / 3) |
| DEG | radians to degrees |
| EN | Euler's Number 2.71 |
| F | fraction |
| FL | Floor |
| GCF | Greatest Common Factor |
| I | Integer |
| LCM | Least Common Multiple |
| LG | Base 10 Logarithm, 10 ^ a |
| LN | Natural Logarithm, e ^ a |
| P2 | power of two, 2 ^ a |
| PD | Prime Divisor |
| PI | half rotation in radians 3.14 |
| R | reciprocal, 1 / x |
| RAD | degrees to radians |
| RAN | Random Integer |
| RD | Round |
| RND | Random Double Between One and Zero |
| RT | Nth Root, EXP(a, 1 / b) |
| S | Change Sign |
| SIN | sine in radians |
| SR | square root, SQRT(a) |
| TAN | tangent in radians |
| TAU | full rotation in radians 6.28 |
| X2 | square, a * a |
| X3 | cube, a ^ 3 |

## EXAMPLES

### Add 1 and 2:  3

```
> 1 + 2
3
```

### Subtract 5 - 3:  2

```
> 5 - 3
2
```

### Multipy 4 and 5:  20

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








