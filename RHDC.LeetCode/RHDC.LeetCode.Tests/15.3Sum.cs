using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    public class ThreeSum
    {
        [TestMethod]
        public void TestMethod1()
        {
            var numbers = new int[]{-1,0,1,2,-1,-4};
            var result = FindThreeSums(numbers);
            var expected = new int[][] { new int[]{ -1, -1, 2 }, new int[] { -1, 0, 1 } };
            Assert.AreEqual(expected, result);
        }

        private int[][] FindThreeSums(int[] numbers)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestMethod3()
        {
            var numbers = new int[] { 0};
            var result = FindThreeSums(numbers);
            var expected = new int[][] { };
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var numbers = new int[] {};
            var result = FindThreeSums(numbers);
            var expected = new int[][] {};
            Assert.AreEqual(expected, result);
        }
    }
}