using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    public class ReverseInteger
    {
        [TestMethod]
        public void TestMethod1()
        {
            var i = 123;
            var result = ReverseInt(i);
            Assert.AreEqual(321, result);
        }

        private object ReverseInt(int i)
        {
            int reverseInt = 0;
            while (i != 0)
            {
                int poppedInt = i % 10;
                i = i / 10;
                if (reverseInt > Int32.MaxValue / 10 || reverseInt < Int32.MinValue / 10)
                {
                    return 0;
                }
                reverseInt = reverseInt * 10 + poppedInt;
            }

            return reverseInt;
        }

        [TestMethod]
        public void TestMethod2()
        {
            var i = -123;
            var result = ReverseInt(i);
            Assert.AreEqual(-321, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var i = 120;
            var result = ReverseInt(i);
            Assert.AreEqual(21, result);
        }
    }
}