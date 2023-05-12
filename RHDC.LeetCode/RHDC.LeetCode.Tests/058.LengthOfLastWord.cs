using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    // https://leetcode.com/problems/length-of-last-word/
    public class LengthOfLastWord
    {
        [TestMethod]
        public void TestMethod1()
        {
            var s = "Hello World";
            var result = GetLengthOfLastWord(s);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var s = "   fly me   to   the moon  ";
            var result = GetLengthOfLastWord(s);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var s = "luffy is still joyboy";
            var result = GetLengthOfLastWord(s);
            Assert.AreEqual(6, result);
        }

        private int GetLengthOfLastWord(string s)
        {
            s = s.Trim();
            var wordArray = s.Split(" ");
            var lastWord = wordArray.Last();
            return lastWord.Length;
        }
    }
}
