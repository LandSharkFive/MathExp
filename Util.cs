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
            var strDelimit = "()+-*/%^,@";
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
            if (op == "@")
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

            string str = "A ACOS ASIN ATAN ALG ALN CB COS CL CR DEG EN F";
            list.AddRange(str.Split(" ").ToList());

            str = "FL GCF I LCM LG LN MIN MAX P2 PI R RAD RAN";
            list.AddRange(str.Split(" ").ToList());

            str = "RD RND RT S SIN SQ SR AN TAU X2 X3";
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
                        break;
                    case "MAX":
                        result = Math.Max(numStk.Pop(), numStk.Pop());
                        break;
                    case "P2":
                        result = Math.Pow(2, numStk.Pop());
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
    }
}




