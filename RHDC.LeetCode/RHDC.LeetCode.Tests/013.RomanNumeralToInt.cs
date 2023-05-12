using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    public class RomanToInteger
    {
        [TestMethod]
        public void TestMethod1()
        {
            var s = "III";
            var i = RomanToInt(s);
            Assert.AreEqual(3, i);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var s = "LVIII";
            var i = RomanToInt(s);
            Assert.AreEqual(58, i);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var s = "MCMXCIV";
            var i = RomanToInt(s);
            Assert.AreEqual(1994, i);
        }

        private int RomanToInt(string s)
        {
            int value = 0;
            char[] charArr = s.ToCharArray();
            for (int i = 0; i < charArr.Length; i++)
            {
                var c = charArr[i];
                var hasNext = i < charArr.Length - 1;
                switch (c)
                {
                    case 'I':
                        if (hasNext && (charArr[i + 1] == 'V' || charArr[i + 1] == 'X'))
                        {
                            value = value - 1;
                        }
                        else
                        {
                            value++;
                        }

                        break;

                    case 'V':
                        value = value + 5;
                        break;

                    case 'X':
                        if (hasNext && (charArr[i + 1] == 'L' || charArr[i + 1] == 'C'))
                        {
                            value = value - 10;
                        }
                        else
                        {
                            value = value + 10;
                        }
                        break;

                    case 'L':
                        value = value + 50;
                        break;

                    case 'C':
                        if (hasNext && (charArr[i + 1] == 'D' || charArr[i + 1] == 'M'))
                        {
                            value = value - 100;
                        }
                        else
                        {
                            value = value + 100;
                        }
                        break;

                    case 'D':
                        value = value + 500;
                        break;

                    case 'M':
                        value = value + 1000;
                        break;

                    default:
                        break;
                }
            }
            return value;
        }
    }
}