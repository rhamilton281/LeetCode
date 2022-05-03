using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    public class LongestCommonPrefix
    {
        [TestMethod]
        public void TestMethod1()
        {
            var strs = new string[] { "flower", "flow", "flight" };
            var result = FindLongestCommonPrefix(strs);
            Assert.AreEqual("fl", result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var strs = new string[] { "dog", "racecar", "car" };
            var result = FindLongestCommonPrefix(strs);
            Assert.AreEqual("", result);
        }


        private string FindLongestCommonPrefix(string[] strs)
        {
            var sb = new StringBuilder();
            Array.Sort(strs);
            var first = strs[0];
            var last = strs[strs.Length - 1];

            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != last[i])
                {
                    break;
                }
                else
                {
                    sb.Append(first[i]);
                }
            }
            return sb.ToString();
         
        }
    }
}