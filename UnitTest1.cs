using RpnOne;

namespace TestOne
{
    [TestClass]
    public class UnitTestOne
    {
        [TestMethod]
        public void TokenAddSub()
        {
            Util util = new Util();
            string exp = "((44.3 * 55) + (2 * 5) - 33.3)";
            var list = util.Tokenize(exp);
            Assert.AreEqual(15, list.Count);
            Assert.AreEqual("44.3", list[2]);
            Assert.AreEqual("55", list[4]);
            Assert.AreEqual("33.3", list[13]);
            string result = String.Join(" ", list.ToArray());
            Assert.AreEqual("( ( 44.3 * 55 ) + ( 2 * 5 ) - 33.3 )", result);
        }

        [TestMethod]
        public void TokenCosRad()
        {
            Util util = new Util();
            string exp = "COS(RAD(45))";
            var list = util.Tokenize(exp);
            Assert.AreEqual(7, list.Count);
            Assert.AreEqual("RAD", list[2]);
            Assert.AreEqual("COS", list[0]);
            Assert.AreEqual("45", list[4]);
            string result = String.Join(" ", list.ToArray());
            Assert.AreEqual("COS ( RAD ( 45 ) )", result);
        }

        [TestMethod]
        public void TokenNegMul1()
        {
            Util util = new Util();
            string exp = "-2 * 5";
            var list = util.Tokenize(exp);
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual("-", list[0]);
            Assert.AreEqual("2", list[1]);
            Assert.AreEqual("*", list[2]);
            Assert.AreEqual("5", list[3]);
            string result = String.Join(" ", list.ToArray());
            Assert.AreEqual("- 2 * 5", result);
        }


        [TestMethod]
        public void TokenMulNeg2()
        {
            Util util = new Util();
            string exp = "-2 * 5";
            var list = util.FixTokens(exp);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("-2", list[0]);
            Assert.AreEqual("*", list[1]);
            Assert.AreEqual("5", list[2]);
            string result = String.Join(" ", list.ToArray());
            Assert.AreEqual("-2 * 5", result);
        }

        [TestMethod]
        public void TokenNegPush1()
        {
            Util util = new Util();
            string exp = "-(2 * 5)";
            var list = util.FixTokens(exp);
            Assert.AreEqual(7, list.Count);
            Assert.AreEqual("0", list[0]);
            Assert.AreEqual("-", list[1]);
            Assert.AreEqual("(", list[2]);
            Assert.AreEqual("2", list[3]);
            Assert.AreEqual("*", list[4]);
            string result = String.Join(" ", list.ToArray());
            Assert.AreEqual("0 - ( 2 * 5 )", result);
        }

        [TestMethod]
        public void PostFixAddSubMul3()
        {
            Util util = new Util();
            string exp = "((44.3 * 55) + (2 * 5) - 33.3)";
            var list = util.Tokenize(exp);
            var postfix = util.InfixToPostfix(list);
            Assert.AreEqual(9, postfix.Count);
            Assert.AreEqual("44.3", postfix[0]);
            Assert.AreEqual("55", postfix[1]);
            Assert.AreEqual("33.3", postfix[7]);
            string result = String.Join(" ", postfix.ToArray());
            Assert.AreEqual("44.3 55 * 2 5 * + 33.3 -", result);
        }

        [TestMethod]
        public void EvalAddSubDiv1()
        {
            Util util = new Util();
            string str = "3 5 + 4 5 + * 4 /";
            var postfix = str.Split(" ").ToList();
            Stack<string> stack = new Stack<string>(postfix.Reverse<string>());
            double result = util.EvalPostFix(stack);
            Assert.AreEqual(18, result);
        }

        [TestMethod]
        public void EvalAddMulDiv3()
        {
            Util util = new Util();
            var str = "100.5 300.5 + 600 + 10 * 100 /";
            var postfix = str.Split(" ").ToList();
            Stack<string> stack = new Stack<string>(postfix.Reverse<string>());
            double result = util.EvalPostFix(stack);
            Assert.AreEqual(100.1, result);
        }

        [TestMethod]
        public void EvalLCM4()
        {
            Util util = new Util();
            var str = "13342 234334 LCM";
            var postfix = str.Split(" ").ToList();
            Stack<string> stack = new Stack<string>(postfix.Reverse<string>());
            double result = util.EvalPostFix(stack);
            Assert.AreEqual(1563242114, result);
        }

        [TestMethod]
        public void EvalPI5()
        {
            Util util = new Util();
            var str = "PI 6 *";
            var postfix = str.Split(" ").ToList();
            Stack<string> stack = new Stack<string>(postfix.Reverse<string>());
            double result = util.EvalPostFix(stack);
            Assert.AreEqual(6 * Math.PI, result, 0.001);
        }

        [TestMethod]
        public void EvalRadCos6()
        {
            Util util = new Util();
            var str = "45 RAD COS";
            var postfix = str.Split(" ").ToList();
            Stack<string> stack = new Stack<string>(postfix.Reverse<string>());
            double result = util.EvalPostFix(stack);
            Assert.AreEqual(0.70710, result, 0.001);
        }

        [TestMethod]
        public void EvalNegMul7()
        {
            Util util = new Util();
            var str = "2 @ 5 *";
            var postfix = str.Split(" ").ToList();
            Stack<string> stack = new Stack<string>(postfix.Reverse<string>());
            double result = util.EvalPostFix(stack);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        public void EvalNegMul8()
        {
            Util util = new Util();
            var str = "2 5 * @";
            var postfix = str.Split(" ").ToList();
            Stack<string> stack = new Stack<string>(postfix.Reverse<string>());
            double result = util.EvalPostFix(stack);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        public void EvalDiv9()
        {
            Util util = new Util();
            var str = "10 2 /";
            var postfix = str.Split(" ").ToList();
            Stack<string> stack = new Stack<string>(postfix.Reverse<string>());
            double result = util.EvalPostFix(stack);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void EvalSub10()
        {
            Util util = new Util();
            var str = "5 2 -";
            var postfix = str.Split(" ").ToList();
            Stack<string> stack = new Stack<string>(postfix.Reverse<string>());
            double result = util.EvalPostFix(stack);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void EvalSub11()
        {
            Util util = new Util();
            var str = "4 1 -";
            var postfix = str.Split(" ").ToList();
            Stack<string> stack = new Stack<string>(postfix.Reverse<string>());
            double result = util.EvalPostFix(stack);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void EvalSub12()
        {
            Util util = new Util();
            var str = "0 2 -";
            var postfix = str.Split(" ").ToList();
            Stack<string> stack = new Stack<string>(postfix.Reverse<string>());
            double result = util.EvalPostFix(stack);
            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void EvalNegSub13()
        {
            Util util = new Util();
            var str = "-1 3 -";
            var postfix = str.Split(" ").ToList();
            Stack<string> stack = new Stack<string>(postfix.Reverse<string>());
            double result = util.EvalPostFix(stack);
            Assert.AreEqual(-4, result);
        }

        [TestMethod]
        public void EvalNegPush14()
        {
            Util util = new Util();
            var str = "40-(1+2)";
            double result = util.Eval(str);
            Assert.AreEqual(37, result);
        }


        [TestMethod]
        public void BindABC1()
        {
            var str = "A * B - C";
            Util util = new Util();
            string result = util.Bind(str, "A", 22.1);
            result = util.Bind(result, "B", 17.4);
            result = util.Bind(result, "C", 66.45);
            Assert.AreEqual(result = "22.1 * 17.4 - 66.45", result);
        }
    }
}