using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    public class ContainsDuplicate
    {
        [TestMethod]
        public void TestMethod1()
        {
            var nums = new int[] { 1, 2, 3, 1 };
            bool result = HasDuplicates(nums);
            Assert.IsTrue(result);
        }

        private bool HasDuplicates(int[] nums)
        {
            var hashSet = new HashSet<int>(nums);
            return nums.Length != hashSet.Count;
        }
    }
}