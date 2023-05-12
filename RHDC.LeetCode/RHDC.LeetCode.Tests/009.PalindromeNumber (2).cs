using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    // https://leetcode.com/problems/palindrome-number/
    public class PalindromeNumber
    {
        [TestMethod]
        public void TestMethod1()
        {
            var x = 121;
            bool result = IsPalindrome(x);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var x = -121;
            bool result = IsPalindrome(x);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var x = 10;
            bool result = IsPalindrome(x);
            Assert.AreEqual(false, result);
        }


        private bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }
            else
            {
                int num = 0;
                while (x > num)
                {
                    num = num * 10 + x % 10;
                    x = x / 10;
                }
                //return true;
                return x == num || x == num / 10;
            }
        }
    }
}
