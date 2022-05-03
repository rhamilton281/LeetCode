using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    public class ImplementstrStr
    {
        [TestMethod]
        public void TestMethod1()
        {
            var needle = "ll";
            var haystack = "hello";
            var result = StrStr(haystack, needle);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var needle = "bba";
            var haystack = "aaaaa";
            var result = StrStr(haystack, needle);
            Assert.AreEqual(-1, result);
        }

        private int StrStr(string haystack, string needle)
        {
            int result = -1;

            for (int hi = 0; hi < haystack.Length; hi++)
            {
                for (int ni = 0; ni < needle.Length; ni++)
                {
                    var needleChar = needle[ni];
                    var haystackChar = haystack[hi];

                    if (needleChar != haystackChar)
                    {
                        result = -1;
                        continue;
                    }
                    if (needleChar == haystackChar && result == -1)
                    {
                        result = hi;
                    }
                    else if (ni >= needle.Length - 1 && result != -1)
                    {
                        return result;
                    }
                }
            }

            return result;
        }
    }
}