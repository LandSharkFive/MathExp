using RpnOne;

namespace TestOne
{

    [TestClass]
    public class UnitTestTwo
    {

        [TestMethod]
        public void EvalMin2()
        {
            Util util = new Util();
            var str = "MIN(53, 39)";
            double result = util.Eval(str);
            Assert.AreEqual(39, result);
        }

        [TestMethod]
        public void EvalMax1()
        {
            Util util = new Util();
            var str = "MAX(53, 39)";
            double result = util.Eval(str);
            Assert.AreEqual(53, result);
        }

        [TestMethod]
        public void EvalMod1()
        {
            Util util = new Util();
            var str = "53 % 3";
            double result = util.Eval(str);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void EvalMod4()
        {
            Util util = new Util();
            var str = "53.343 % 3.117";
            double result = util.Eval(str);
            Assert.AreEqual(0.354, result, 0.001);
        }

        [TestMethod]
        public void EvalLog1()
        {
            Util util = new Util();
            var str = "LG(53.343)";
            double result = util.Eval(str);
            Assert.AreEqual(1.72707743, result, 1e-5);
        }

        [TestMethod]
        public void EvalLN3()
        {
            Util util = new Util();
            var str = "LN(153.453)";
            double result = util.Eval(str);
            Assert.AreEqual(5.03339433, result, 1e-5);
        }

        [TestMethod]
        public void EvalPD2()
        {
            Util util = new Util();
            var str = "PD(3839)";
            double result = util.Eval(str);
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void EvalRAD5()
        {
            Util util = new Util();
            var str = "RAD(22.34)";
            double result = util.Eval(str);
            Assert.AreEqual(0.389906554, result, 1e-5);
        }

        [TestMethod]
        public void EvalDEG8()
        {
            Util util = new Util();
            var str = "DEG(34.38)";
            double result = util.Eval(str);
            Assert.AreEqual(1969.8288996, result, 1e-5);
        }

        [TestMethod]
        public void EvalSign2()
        {
            Util util = new Util();
            var str = "S(-5)";
            double result = util.Eval(str);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void EvalSign3()
        {
            Util util = new Util();
            var str = "S(7)";
            double result = util.Eval(str);
            Assert.AreEqual(-7, result);
        }

        [TestMethod]
        public void EvalNegate3()
        {
            Util util = new Util();
            var str = "@7";
            double result = util.Eval(str);
            Assert.AreEqual(-7, result);
        }

        [TestMethod]
        public void EvalNegate4()
        {
            Util util = new Util();
            var str = "@7 + @4";
            double result = util.Eval(str);
            Assert.AreEqual(-11, result);
        }

        [TestMethod]
        public void EvalPower23()
        {
            Util util = new Util();
            var str = "P2(10)";
            double result = util.Eval(str);
            Assert.AreEqual(1024, result);
        }

        [TestMethod]
        public void EvalCombo1()
        {
            Util util = new Util();
            var str = "NCR(6,2)";
            double result = util.Eval(str);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void EvalPerm1()
        {
            Util util = new Util();
            var str = "NPR(6,2)";
            double result = util.Eval(str);
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void EvalCDF1()
        {
            Util util = new Util();
            var str = "CDF(0)";
            double result = util.Eval(str);
            Assert.AreEqual(0.5, result, 1e-4);
        }

        [TestMethod]
        public void EvalCDF2()
        {
            Util util = new Util();
            var str = "CDF(1)";
            double result = util.Eval(str);
            Assert.AreEqual(0.841344, result, 1e-4);
        }

        [TestMethod]
        public void EvalSTU1()
        {
            Util util = new Util();
            var str = "STU(1, 10)";
            double result = util.Eval(str);
            Assert.AreEqual(0.3409, result, 1e-4);
        }

        [TestMethod]
        public void EvalSTU2()
        {
            Util util = new Util();
            var str = "STU(0.5, 10)";
            double result = util.Eval(str);
            Assert.AreEqual(0.6279, result, 1e-4);
        }

    }
}