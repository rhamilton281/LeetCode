using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    public class ThreeSum
    {
        // Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such
        // that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
        // Notice that the solution set must not contain duplicate triplets.

        private IEnumerable<int[]> FindThreeSums(int[] numbers)
        {
            var answers = new List<int[]>();
            var sortedNumbers = numbers.OrderBy(x => x).ToList();
            for (int i = 0; i < sortedNumbers.Count(); i++)
            {
                // iterate through every combination, looking for a sum of 0
                var number1 = sortedNumbers[i];

                for (int ii = 0; ii < sortedNumbers.Count(); ii++)
                {
                    // skip when the second number is the same af the first
                    if (i == ii )
                    {
                        continue;
                    }
                    else
                    {
                        var number2 = sortedNumbers[ii];
                        var targetNumber = number1 + number2 * -1;
                        // another loop
                        // move left or right based on value of number2
                        // if targetNumber > 

                    }
                }

                var otherNumbers = new int[] { };
                // find any two other numbers which equal the target value


            }

            return answers;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var numbers = new int[] { -1, 0, 1, 2, -1, -4 };
            var result = FindThreeSums(numbers);
            var expected = new int[][] { new int[] { -1, -1, 2 }, new int[] { -1, 0, 1 } };
            Assert.AreEqual(expected, result);
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