using System.Collections.Generic;
using System.Text;


namespace RpnOne
{

    public class Util
    {
        private static Random rnd = new Random();

        private List<string> opList;

        public Util()
        {
            opList = GetOpList();
        }

        public double Eval(string str)
        {
            var list = FixTokens(str);
            var postFix = InfixToPostfix(list);
            Stack<string> stack = new Stack<string>(postFix.Reverse<string>());
            return EvalPostFix(stack);
        }


        public List<string> Tokenize(string a)
        {
            var strDelimit = "()+-*/%^,@!";
            var delimiters = strDelimit.ToCharArray();
            var buffer = string.Empty;
            var result = new List<string>();
            string b = RemoveWhiteSpace(a).ToUpper();

            foreach (var ch in b)
            {
                if (delimiters.Contains(ch))
                {
                    if (buffer.Length > 0)
                    {
                        result.Add(buffer);
                    }
                    result.Add(ch.ToString());
                    buffer = string.Empty;
                }
                else
                {
                    buffer += ch;
                }
            }

            if (buffer.Length > 0)
            {
                result.Add(buffer);
            }

            return result;
        }

        public List<string> FixTokens(string a)
        {
            var list = Tokenize(a);
            FixNegateStart(list);
            FixNegateMiddle(list);
            return list;
        }


        public List<string> InfixToPostfix(List<string> exp)
        {
            List<string> result = new List<string>();
            Stack<string> opStk = new Stack<string>();

            foreach (var token in exp)
            {
                if (IsOperator(token))
                {
                    opStk.Push(token);
                    continue;
                }

                if (IsNumber(token))
                {
                    result.Add(token);
                    continue;
                }

                if (IsAlphaNumeric(token))
                {
                    result.Add(token);
                    continue;
                }

                switch (token)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "%":
                    case "^":
                    case "@":
                    case "!":
                        while (opStk.Count > 0 && Precedence(token) <= Precedence(opStk.Peek()))
                        {
                            string op = opStk.Pop();
                            if (op != "(")
                            {
                                result.Add(op);
                            }
                        }
                        opStk.Push(token);
                        break;
                    case "(":
                        opStk.Push("(");
                        break;
                    case ")":
                        while (opStk.Count > 0 && opStk.Peek() != "(")
                        {
                            result.Add(opStk.Pop());
                        }
                        if (opStk.Count > 0 && opStk.Peek() == "(")
                        {
                            opStk.Pop();
                        }
                        break;
                }
            }

            while (opStk.Count > 0)
            {
                result.Add(opStk.Pop());
            }

            return result;
        }

        public int Precedence(string op)
        {
            if (op == "@" || op == "!")
                return 4;
            if (op == "^")
                return 3;
            if (op == "*" || op == "/" || op == "%")
                return 2;
            if (op == "+" || op == "-")
                return 1;
            return -1;
        }

        public bool IsAlphaNumeric(string a)
        {
            return a.All(ch => Char.IsLetterOrDigit(ch) || ch == '.');
        }

        public bool IsNumber(string a)
        {
            if (Double.TryParse(a, out double b))
            {
                return true;
            }

            return false;
        }

        public bool IsOperator(string op)
        {
            return opList.Contains(op);
        }

        // Get Operator List
        List<string> GetOpList()
        {
            List<string> list = new List<string>();

            string str = "A ACOS ASIN ATAN ALG ALN CB CDF COS CL CR DEG EN F";
            list.AddRange(str.Split(" ").ToList());

            str = "FL GCF I LCM LG LN MIN MAX NCR NPR PD P2 PI R RAD RAN";
            list.AddRange(str.Split(" ").ToList());

            str = "RD RND RT S SIN SQ SR STU TAN TAU X2 X3";
            list.AddRange(str.Split(" ").ToList());

            return list;
        }

        public string RemoveWhiteSpace(string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var ch in str)
            {
                if (!char.IsWhiteSpace(ch))
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString();
        }

        public double EvalPostFix(Stack<string> tokens)
        {
            if (tokens.Count == 0)
            {
                return 0;
            }

            double x, y;
            string msg;

            Stack<double> numStk = new Stack<double>();
            double result = 0;

            while (tokens.Count > 0)
            {
                string token = tokens.Pop();
                if (Double.TryParse(token, out result))
                {
                    numStk.Push(result);
                    continue;
                }

                // operator
                switch (token)
                {
                    case "+":
                        result = numStk.Pop() + numStk.Pop();
                        numStk.Push(result);
                        break;
                    case "-":
                        x = numStk.Pop();  
                        y = numStk.Pop();
                        result = y - x;
                        numStk.Push(result);
                        break;
                    case "*":
                        result = numStk.Pop() * numStk.Pop();
                        numStk.Push(result);
                        break;
                    case "/":
                        x = numStk.Pop();
                        y = numStk.Pop();
                        result = y / x;
                        numStk.Push(result);
                        break;
                    case "^":
                        x = numStk.Pop();
                        y = numStk.Pop();
                        result = Math.Pow(y, x);
                        numStk.Push(result);
                        break;
                    case "%":
                        x = numStk.Pop();
                        y = numStk.Pop();
                        result = y % x;
                        numStk.Push(result);
                        break;
                    case "@":
                        result = -numStk.Pop();
                        numStk.Push(result);
                        break;
                    case "!":
                        result = Factorial(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "A":
                        result = Math.Abs(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "ACOS":
                        result = Math.Acos(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "ASIN":
                        result = Math.Asin(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "ATAN":
                        result = Math.Atan(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "ALG":
                        result = Math.Pow(10, numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "ALN":
                        result = Math.Exp(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "CB":
                        result = numStk.Pop();
                        result = result * result * result;
                        numStk.Push(result);
                        break;
                    case "CDF":
                        result = numStk.Pop();
                        result = CumDensity(result);
                        numStk.Push(result);
                        break;
                    case "CL":
                        result = Math.Ceiling(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "COS":
                        result = Math.Cos(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "CR":
                        result = Math.Cbrt(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "DEG":
                        result = Degrees(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "EN":
                        result = Math.E;
                        numStk.Push(result);
                        break;
                    case "F":
                        result = numStk.Pop();
                        result = result - Math.Truncate(result);
                        numStk.Push(result);
                        break;
                    case "FL":
                        result = Math.Floor(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "GCF":
                        result = GCF(numStk.Pop(), numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "I":
                        result = Math.Floor(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "LCM":
                        result = LCM(numStk.Pop(), numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "LG":
                        result = Math.Log10(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "LN":
                        result = Math.Log(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "MIN":
                        result = Math.Min(numStk.Pop(), numStk.Pop());
                        numStk.Push(result);    
                        break;
                    case "MAX":
                        result = Math.Max(numStk.Pop(), numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "NCR":
                        y = numStk.Pop();
                        x = numStk.Pop();
                        result = Combinations(x, y);
                        numStk.Push(result);
                        break;
                    case "NPR":
                        y = numStk.Pop();
                        x = numStk.Pop();
                        result = Permutations(x, y);
                        numStk.Push(result);
                        break;
                    case "P2":
                        result = Math.Pow(2, numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "PD":
                        result = PrimeDivisor(Clamp(numStk.Pop()));
                        numStk.Push(result);
                        break;
                    case "PI":
                        result = Math.PI;
                        numStk.Push(result);
                        break;
                    case "R":
                        result = 1 / numStk.Pop();
                        numStk.Push(result);
                        break;
                    case "RAD":
                        result = Radians(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "RAN":
                        result = rnd.Next();
                        numStk.Push(result);
                        break;
                    case "RD":
                        result = Math.Round(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "RND":
                        result = rnd.NextDouble();
                        numStk.Push(result);
                        break;
                    case "RT":
                        x = numStk.Pop();
                        y = numStk.Pop();
                        result = Math.Pow(y, 1.0 / x);
                        numStk.Push(result);
                        break;
                    case "S":
                        result = -numStk.Pop();
                        numStk.Push(result);
                        break;
                    case "SIN":
                        result = Math.Sin(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "SQ":
                        result = numStk.Pop();
                        result = result * result;
                        numStk.Push(result);
                        break;
                    case "SR":
                        result = Math.Sqrt(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "STU":
                        y = numStk.Pop();
                        x = numStk.Pop();
                        result = Student(x, y);
                        numStk.Push(result);
                        break;
                    case "TAN":
                        result = Math.Tan(numStk.Pop());
                        numStk.Push(result);
                        break;
                    case "TAU":
                        result = Math.Tau;
                        numStk.Push(result);
                        break;
                    case "X2":
                        result = numStk.Pop();
                        result = result * result;
                        numStk.Push(result);
                        break;
                    case "X3":
                        result = numStk.Pop();
                        result = result * result * result;
                        numStk.Push(result);
                        break;
                    default:
                        msg = String.Format("Operator not found: {0}", token);
                        throw new Exception(msg);
                }
            }

            return result;
        }

        private static double Radians(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        private static double Degrees(double radians)
        {
            return 180.0 * radians / Math.PI;
        }

        // Clamp.
        // Return Int32.
        private static int Clamp(double x)
        {
            if (Int32.MinValue < x && x < Int32.MaxValue)
            {
                return Convert.ToInt32(x);
            }

            return 0;
        }

        private void FixNegateStart(List<string> a)
        {
            if (a.Count < 2)
                return;

            if (a[0] == "-" && IsNumber(a[1]))
            {
                a[0] = String.Concat("-", a[1]);  
                a.RemoveAt(1);
            }
            else if (a[0] == "-" && a[1] == "(")
            {
                a.Insert(0, "0");
            }
        }

        private void FixNegateMiddle(List<string> a)
        {
            for (int i = 1; i < a.Count - 1; i++)
            {
                if (a[i] == "-" && IsNumber(a[i + 1]))
                {
                    if (a[i - 1] == "(" || a[i - 1] == ",")
                    {
                        a[i] = String.Concat("-", a[i + 1]);
                        a.RemoveAt(i + 1);
                    }
                }
            }
        }

        public string Bind(string str, string name, double value)
        {
            return str.Replace(name, value.ToString());
        }

        public double Factorial(double value)
        {
            if (value <= 1.0)
            {
                return 1.0;
            }
            if (value > 170.0)
            {
                return 0.0;
            }

            double result = 1.0;
            for (int i = 1; i <= value; i++)
            {
                result *= i;
            }

            return result;
        }

        private static int GCF(double a, double b)
        {
            int x = Clamp(a);
            int y = Clamp(b);
            return GCFInner(x, y);
        }

        private static int LCM(double a, double b)
        {
            int x = Clamp(a);
            int y = Clamp(b);
            return LCMInner(x, y);
        }


        // GCF - Greatest Common Factor.
        private static int GCFInner(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        // LCM - Least Common Multiple.
        private static int LCMInner(int a, int b)
        {
            return (a / GCF(a, b)) * b;
        }

        // Prime Divisor.
        // If prime, return 0.
        private int PrimeDivisor(int n)
        {
            // By definition, zero and one are not prime numbers.
            if (n < 2)
            {
                return 0;
            }

            int max = (int)Math.Sqrt(n);
            for (int i = 2; i <= max; i++)
            {
                if (n % i == 0)
                {
                    return i;
                }
            }

            return 0;
        }

        private double Combinations(double n, double r)
        {
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        private double Permutations(double n, double r)
        {
            return Factorial(n) / Factorial(n - r);
        }

        /// <summary>
        /// CDF - Cumulative Density Function for the Standard Normal Distribution.
        /// </summary>
        /// <param name="z">z-score</param>
        /// <returns>cumulative probability density</returns>
        // Output is always between zero and one.  Z-Score is generally between -4.0 and 4.0.
        // When z is above 4.0, cdf is one. When z is below -4.0, cdf is zero.  
        private static double CumDensity(double z)
        {
            double p = 0.3275911;
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;

            int sign = 1;
            if (z < 0.0)
            {
                sign = -1;
            }

            double x = Math.Abs(z) / Math.Sqrt(2.0);
            double t = 1.0 / (1.0 + p * x);
            double erf = 1.0 - (((((a5 * t + a4) * t) + a3)
              * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * erf);
        } // CumDensity()


        /// <summary>
        /// Student's T-Distribution
        /// </summary>
        /// <param name="t">t-score</param>
        /// <param name="df">degrees of freedom</param>
        /// <returns>2-tail probability</returns>

        private static double Student(double t, double df)
        {
            // for large int df or double df

            // Adapted from ACM algorithm 395
            // Returns 2-tail probability.
            // For 1-tail probability, divide by two.

            double n = df; // to sync with ACM parameter name
            double a, b, y;

            t = t * t;
            y = t / n;
            b = y + 1.0;
            if (y > 1.0E-6)
            {
                y = Math.Log(b);
            }
            a = n - 0.5;
            b = 48.0 * a * a;
            y = a * y;

            y = (((((-0.4 * y - 3.3) * y - 24.0) * y - 85.5) /
              (0.8 * y * y + 100.0 + b) +
                y + 3.0) / b + 1.0) * Math.Sqrt(y);

            return 2.0 * Gauss(-y);
        } // Student

        /// <summary>
        /// Gaussian Probability Density Function
        /// </summary>
        /// <param name="z">z-score</param>
        /// <returns>probability density</returns>
        private static double Gauss(double z)
        {
            // input = z-value (-inf to +inf)
            // output = p under Normal curve from -inf to z
            // e.g., if z = 0.0, function returns 0.5000
            // ACM Algorithm #209
            double y; // 209 scratch variable
            double p; // result. called 'z' in 209
            double w; // 209 scratch variable

            if (z == 0.0)
            {
                p = 0.0;
            }
            else
            {
                y = Math.Abs(z) / 2;
                if (y >= 3.0)
                {
                    p = 1.0;
                }
                else if (y < 1.0)
                {
                    w = y * y;
                    p = ((((((((0.000124818987 * w
                      - 0.001075204047) * w + 0.005198775019) * w
                      - 0.019198292004) * w + 0.059054035642) * w
                      - 0.151968751364) * w + 0.319152932694) * w
                      - 0.531923007300) * w + 0.797884560593) * y * 2.0;
                }
                else
                {
                    y = y - 2.0;
                    p = (((((((((((((-0.000045255659 * y
                      + 0.000152529290) * y - 0.000019538132) * y
                      - 0.000676904986) * y + 0.001390604284) * y
                      - 0.000794620820) * y - 0.002034254874) * y
                      + 0.006549791214) * y - 0.010557625006) * y
                      + 0.011630447319) * y - 0.009279453341) * y
                      + 0.005353579108) * y - 0.002141268741) * y
                      + 0.000535310849) * y + 0.999936657524;
                }
            }

            if (z > 0.0)
            {
                return (p + 1.0) / 2;
            }
            else
            {
                return (1.0 - p) / 2;
            }
        } // Gauss()


    }
}




