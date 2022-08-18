using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    public class ThreeSum
    {
        [TestMethod]
        public void TestMethod1()
        {
            var numbers = new int[] { -1, 0, 1, 2, -1, -4 };
            var result = FindThreeSums(numbers);
            var expected = new int[][] { new int[] { -1, -1, 2 }, new int[] { -1, 0, 1 } };
            Assert.AreEqual(expected, result);
        }

        private IEnumerable<int[]> FindThreeSums(IEnumerable<int> numbers)
        {
            var answers = new List<int[]>();
            if (numbers.Count() < 3)
            {
                return answers;
            }
            numbers = numbers.Select(x => x).Distinct();
            var targetResult = 0;
            foreach (var number in numbers)
            {
            }

            return answers;
        }

        [TestMethod]
        public void TestMethod2()
        {
            var numbers = new int[] { 0, 1, 1 };
            var result = FindThreeSums(numbers);
            var expected = new int[][] { };
            Assert.IsTrue(Enumerable.SequenceEqual(expected, result));
        }

        [TestMethod]
        public void TestMethod3()
        {
            var numbers = new int[] { 0, 0, 0 };
            var result = FindThreeSums(numbers).ToArray();
            var expected = new int[][] { };
            Assert.IsTrue(Enumerable.SequenceEqual(expected, result));
        }
    }
}