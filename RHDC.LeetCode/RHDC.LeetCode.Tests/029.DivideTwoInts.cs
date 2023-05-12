using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    public class DivideTwoInts
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dividend = 10;
            var divisor = 3;
            var result = Divide(dividend, divisor);
            var expected = 3;
            Assert.AreEqual(expected, result);
        }

        private int Divide(int dividend, int divisor)
        {
            var result = 0;

            if ((divisor > 0 && dividend > 0) || (divisor < 0 && dividend < 0 ))
            {
                if (divisor < 0 && dividend < 0)
                {
                    if (dividend <= int.MinValue)
                    {

                    }
                    divisor = Math.Abs(divisor);
                    dividend = Math.Abs(dividend);
                }
                while (dividend > 0)
                {
                    if (dividend < divisor)
                    {
                        return result;
                    }
                    else
                    {
                        dividend = dividend - divisor;
                        result++;
                        if (result == int.MaxValue)
                        {
                            return result;
                        }
                    }
                }
            }
            else if (divisor < 0 || dividend < 0)
            {
                if (dividend > 0)
                {
                    while (dividend > 0)
                    {
                        if (System.Math.Abs(dividend) < System.Math.Abs(divisor))
                        {
                            return result;
                        }
                        else
                        {
                            dividend = dividend + divisor;
                            result--;
                            if (result == int.MinValue)
                            {
                                return result;
                            }
                        }
                    }
                }
                else
                {
                    while (dividend < 0)
                    {
                        if (System.Math.Abs(dividend) < System.Math.Abs(divisor))
                        {
                            return result;
                        }
                        else
                        {
                            dividend = dividend + divisor;
                            result--;
                            if (result == int.MinValue)
                            {
                                return result;
                            }
                        }
                    }
                }
            }
            return result;
        }

        [TestMethod]
        public void TestMethod2()
        {
            var dividend = 7;
            var divisor = -3;
            var result = Divide(dividend, divisor);
            var expected = -2;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var dividend = -1;
            var divisor = 1;
            var result = Divide(dividend, divisor);
            var expected = -1;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var dividend = -1;
            var divisor = -1;
            var result = Divide(dividend, divisor);
            var expected = 1;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var dividend = -2147483648;
            var divisor = -1;
            var result = Divide(dividend, divisor);
            var expected = 1;
            Assert.AreEqual(expected, result);
        }
    }
}